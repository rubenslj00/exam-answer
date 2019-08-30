
using DAL.Entities;
using System.Collections.Generic;

namespace Exam_answerWeb.Infrastructure.Questions
{
    public partial class Az900
    {
        public static QuestionEntity Q64Instance = new QuestionEntity()
        {
            QuestionType = QuestionType.RadioButon,
            Order = 177,
            Section = "Understand Security, Privacy, Compliance and Trust",
            Contents = new List<ContentEntity>()
            {
                new ContentEntity()
                {
                    Text = "Resource groups provide organizations with the ability to manage the compliance of Azure resources across multiple subscriptions.",
                },
                new ContentEntity()
                {
                    Text = "Instructions: Review the underlined text. If it makes the statement correct, select \"No change is needed\". If the statement is incorrect, select the answer choice that makes the statement correct.",
                },
            },

            Answers = new List<AnswerEntity>()
            {
                new AnswerEntity()
                {
                    Text = "No change is needed.", 
                    IsCorrect = false
                },
                new AnswerEntity()
                {
                    Text = "Management groups.", 
                    IsCorrect = false
                },
                new AnswerEntity()
                {
                    Text = "Azure policies.", 
                    IsCorrect = true
                },
                new AnswerEntity()
                {
                    Text = "Azure App Service plans.", 
                    IsCorrect = false
                },
            },

            Explanations = new List<ExplanationEntity>()
            {
                new ExplanationEntity()
                {

                },
                new ExplanationEntity()
                {

                },
                new ExplanationEntity()
                {

                },
                new ExplanationEntity()
                {

                },
            },

            References = new List<ReferenceEntity>()
            {
                new ReferenceEntity()
                {
                    Text ="",
                    Url = ""
                },
                new ReferenceEntity()
                {
                    Text ="",
                    Url = ""
                }
            },                
        };
    }
}
