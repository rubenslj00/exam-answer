using DAL.Entities;
using System.Collections.Generic;

namespace Exam_answerWeb.Infrastructure.Questions
{
    public partial class Az900
    {
        public static QuestionEntity Q109Instance = new QuestionEntity()
        {
            QuestionType = QuestionType.CheckBox,
            Order = 109,
            Section = "",
            Contents = new List<ContentEntity>()
            {               
                new ContentEntity()
                {
                    Text = "Choose all that apply.",
                },
            },

            Answers = new List<AnswerEntity>()
            {
                new AnswerEntity()
                {
                    Text = "To achieve a hybrid cloud model, a company must always migrate from a private cloud model.",
                    IsCorrect = false
                },
                new AnswerEntity()
                {
                    Text = "A company can extend the capacity of its internal network by using the public cloud.",
                    IsCorrect = true
                },
                new AnswerEntity()
                {
                    Text = "In a public cloud model, only guest users at your company can access the resources in the cloud.",
                    IsCorrect = false
                },
            },

            //Explanations = new List<ExplanationEntity>()
            //{
            //    new ExplanationEntity()
            //    {
            //        Text = "The Domain Name System is a hierarchy of domains. The hierarchy starts from the 'root' domain, whose name is simply '.'. Below this come top-level domains, such as 'com', 'net', 'org', 'uk' or 'jp'. Below these are second-level domains, such as 'org.uk' or 'co.jp'. The domains in the DNS hierarchy are globally distributed, hosted by DNS name servers around the world.",
            //    },
            //    new ExplanationEntity()
            //    {
            //        Text = "A domain name registrar is an organization that allows you to purchase a domain name, such as 'contoso.com'. Purchasing a domain name gives you the right to control the DNS hierarchy under that name, for example allowing you to direct the name www.contoso.com to your company web site. The registrar may host the domain in its own name servers on your behalf, or allow you to specify alternative name servers."
            //    },
            //    new ExplanationEntity()
            //    {
            //        Text = "Azure DNS provides a globally distributed, high-availability name server infrastructure, which you can use to host your domain. By hosting your domains in Azure DNS, you can manage your DNS records with the same credentials, APIs, tools, billing, and support as your other Azure services."
            //    },
            //    new ExplanationEntity()
            //    {
            //        Text = "The NS record set at the zone apex is automatically created with each DNS zone. It contains the names of the Azure DNS name servers assigned to the zone. You can add additional name servers to this NS record set, to support co-hosting domains with more than one DNS provider. You can also modify the TTL and metadata for this record set. However, you cannot remove or modify the pre-populated Azure DNS name servers."
            //    },
            //    new ExplanationEntity()
            //    {
            //        Text = "Modify the Name Server (NS) record."
            //    },
            //},

            //References = new List<ReferenceEntity>()
            //{
            //    new ReferenceEntity()
            //    {
            //        Text = "Tutorial: Host your domain in Azure DNS",
            //        Url = "https://docs.microsoft.com/en-us/azure/dns/dns-delegate-domain-azure-dns",
            //    },
            //},
        };
    }
}