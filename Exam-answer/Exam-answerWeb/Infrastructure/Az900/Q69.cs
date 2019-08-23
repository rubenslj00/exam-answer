
using DAL.Entities;
using System.Collections.Generic;

namespace Exam_answerWeb.Infrastructure.Questions
{
    public partial class Az900
    {
        public static QuestionEntity Q68Instance = new QuestionEntity()
        {
            QuestionType = QuestionType.RadioButon,
            Order = 190,
            Section = "",
            Contents = new List<ContentEntity>()
            {
                new ContentEntity()
                {
                    Text = "Note: This question is part of a series of questions that present the same scenario. Each question in the series contains a unique solution that might.",
                },
                new ContentEntity()
                {
                    Text = "Meet the stated goals. Some question sets might have more than one correct solution, while others might not have a correct solution.",
                },
                new ContentEntity()
                {
                    Text = "After you answer a question in this section, you will NOT be able to return to it. As a result, these questions will not appear in the review screen.",
                },
                new ContentEntity()
                {
                    Text = "You have an Azure Active Directory (Azure AD) tenant named Adatum and an Azure Subscription named Subscription1. Adatum contains a group named.",
                },
                new ContentEntity()
                {
                    Text = "Developers. Subscription1 contains a resource group named Dev.",
                },
                new ContentEntity()
                {
                    Text = "You need to provide the Developers group with the ability to create Azure logic apps in the Dev resource group.",
                },
                new ContentEntity()
                {
                    Text = "Solution: On Dev, you assign the Logic App Contributor role to the Developers group.",
                },
                new ContentEntity()
                {
                    Text = "Does this meet the goal?",
                },
            },

            Answers = new List<AnswerEntity>()
            {
                new AnswerEntity()
                {
                    Text = "Yes.", 
                    IsCorrect = true
                },
                new AnswerEntity()
                {
                    Text = "No.", 
                    IsCorrect = false
                },
            },

            Explanations = new List<ExplanationEntity>()
            {
                new ExplanationEntity()
                {
                    Text = "The Logic App Contributor role lets you manage logic app, but not access to them. It provides access to view, edit, and update a logic app."
                },
            },

            References = new List<ReferenceEntity>()
            {
                new ReferenceEntity()
                {
                    Url = "https://docs.microsoft.com/en-us/azure/role-based-access-control/built-in-roles",
                },
                new ReferenceEntity()
                {
                    Url = "https://docs.microsoft.com/en-us/azure/logic-apps/logic-apps-securing-a-logic-app",
                },
            },           
        };
    }
}
