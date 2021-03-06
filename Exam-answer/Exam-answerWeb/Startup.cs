﻿using AutoMapper;
using DAL.Entities;
using DotnetThoughts.AspNetCore;
using Exam_answerWeb.Extensions;
using Exam_answerWeb.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Exam_answerWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment HostingEnvironment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Optimal;
            });

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Clear();
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();

                var mimeTypes = ResponseCompressionDefaults.MimeTypes;
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "document", "text/html", "image/x-icon" });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMemoryCache();

            services.AddOutputCaching();

            // Add MVC services to the services container.
            services
                .AddMvc(options => options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddDbContext<ExamAnswerContext>(options => options.UseInMemoryDatabase(databaseName: "ExamAnswerContext"));

            // very importan for AMP
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            //services
            //    .AddDistributedMemoryCache()
            //    .AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");

            HostingEnvironment = env;
            if (env.EnvironmentName == "Development")
            {
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseDeveloperExceptionPage();

            app.UseStatusCodePagesWithRedirects("/error?id={0}");

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                IExceptionHandlerPathFeature feature = context.Features.Get<IExceptionHandlerPathFeature>();
                Exception exception = feature.Error;
                var result = await Task.FromResult(0);
            }));

            app.UseHttpsRedirection();

            app.UseCookiePolicy();

            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/url-rewriting?view=aspnetcore-2.2
            if (env.EnvironmentName != "Development")
            {
                //Very problematic. !!!could lead to error: This site can't be reached
                app.UseRewriter(new RewriteOptions()
                .AddRedirect("(.*)/$", "$1", (int)HttpStatusCode.MovedPermanently) // Strip trailing slash
                .AddRedirectToWww() //Very problematic. !!!could lead to error: This site can't be reached
                .AddRedirectToHttps()
                .Add(new RedirectLowerCaseRule())
                );
            }

            app.UseResponseCompression();

            FileExtensionContentTypeProvider provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".webmanifest"] = "application/manifest+json";

            //if (env.EnvironmentName != "Development")
            //{
            //    app.UseHTMLMinification();
            //}

            app.UseStaticFiles(new StaticFileOptions()
            {
                ContentTypeProvider = provider
            });

            app.UseOutputCaching();

            app.Use(
                       next =>
                       {
                           return async context =>
                           {
                               Stopwatch stopWatch = Stopwatch.StartNew();
                               context.Response.OnStarting(
                                   () =>
                                   {
                                       stopWatch.Stop();
                                       context.Response.Headers.Add("X-ResponseTime-Ms", stopWatch.ElapsedMilliseconds.ToString());

                                       return Task.CompletedTask;
                                   });

                               await next(context);
                           };
                       });

            app.Use(
                       next =>
                       {
                           return async context =>
                           {
                               IMemoryCache cache = context.RequestServices.GetRequiredService<IMemoryCache>();
                               string urlPath = context.Request.Path;
                               bool isMobile = context.IsMobileBrowser();
                               string cachedHtml = cache.Get<string>(context.Request.Path.ToString() + "_IsMobile_" + isMobile.ToString());
                               byte[] byteArray = cache.Get<byte[]>(context.Request.Path.ToString() + "_IsMobile_" + isMobile.ToString() + "compressedBr");

                               string[] browserSupportedCompressionTypes = context.Request.Headers["Accept-Encoding"].ToString().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                               if (browserSupportedCompressionTypes.Contains("br") && byteArray != null)
                               {
                                   context.Response.ContentType = "text/html";
                                   context.Response.Headers.Add("Content-Encoding", new[] { "br" });
                                   await context.Response.Body.WriteAsync(byteArray, 0, byteArray.Length);// .WriteAsync(compressedString);
                               }
                               else if (!string.IsNullOrEmpty(cachedHtml))
                               {
                                   await context.Response.WriteAsync(cachedHtml);
                               }
                               else
                               {
                                   await next(context);
                               }

                               //if (!string.IsNullOrEmpty(cachedHtml))
                               //{

                               //// convert string to stream
                               //byte[] byteArray = Encoding.ASCII.GetBytes(cachedHtml);

                               //using (MemoryStream fs = new MemoryStream(byteArray))
                               //using (var ms = new MemoryStream())
                               //{
                               //    using (var bs = new BrotliSharpLib.BrotliStream(ms, System.IO.Compression.CompressionMode.Compress))
                               //    {
                               //        bs.SetQuality(11);
                               //        fs.Position = 0;
                               //        fs.CopyTo(bs);

                               //        bs.Dispose();
                               //        byte[] compressed = ms.ToArray();
                               //        var compressedString = Encoding.ASCII.GetString(compressed);

                               //        context.Response.ContentType = "text/html";
                               //        context.Response.Headers.Add("Content-Encoding", new[] { "br" });
                               //        await context.Response.Body.WriteAsync(compressed, 0, compressed.Length);// .WriteAsync(compressedString);

                               //    }
                               //}
                               //context.Response.Headers["Content-Encoding"] = "br";
                               //await context.Response.WriteAsync(cachedHtml);
                               //await context.Response.WriteAsync(cachedHtml);
                               //}
                               //else
                               //{
                               //    await next(context);
                               //}
                           };
                       });


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}