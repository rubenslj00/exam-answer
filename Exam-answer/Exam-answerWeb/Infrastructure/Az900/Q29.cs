using DAL.Entities;
using System.Collections.Generic;

namespace Exam_answerWeb.Infrastructure.Questions
{
    public partial class Az900
    {
        /// <summary>
        /// 14
        /// </summary>
        public static QuestionEntity Q29Instance = new QuestionEntity()
        {
            Order = 29,
            Section = "Understand Core Azure Services",
            Contents = new List<ContentEntity>()
            {
                new ContentEntity()
                {
                    Text = "You plan to map a network drive from several computers that run Windows 10 to Azure Storage. You need to create a storage solution in Azure for the planned mapped drive.",
                },
                new ContentEntity()
                {
                    Text = "What should you create?"
                },               
            },
            Answers = new List<AnswerEntity>()
            {
                new AnswerEntity()
                {
                    Text = "An Azure SQL database.",
                },
                new AnswerEntity()
                {
                    Text = "A virtual machine data disk."
                },
                new AnswerEntity()
                {
                    Text = "A Files service in a storage account.",
                },
                new AnswerEntity()
                {
                    Text = "A Blobs service in a storage account."
                },
            },
            Explanations = new List<ExplanationEntity>()
            {
                
            },
            References = new List<ReferenceEntity>()
            {
                
            }
        };
    }
}