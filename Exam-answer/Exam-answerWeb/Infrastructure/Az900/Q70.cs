using DAL.Entities;
using System.Collections.Generic;

namespace Exam_answerWeb.Infrastructure.Questions
{
    public partial class Az900
    {
        public static QuestionEntity Q70Instance = new QuestionEntity()
        {
            QuestionType = QuestionType.RadioButon,
            Order = 70,
            Section = "",
            Contents = new List<ContentEntity>()
            {
                new ContentEntity()
                {
                    Text = "You have an Azure subscription named Subscription1 that contains an Azure Log Analytics workspace named Workspace1.",
                },
                new ContentEntity()
                {
                    Text = "You need to view the error events from a table named Event.",
                },
                new ContentEntity()
                {
                    Text = "Which query should you run in Workspace1?",
                },
            },

            Answers = new List<AnswerEntity>()
            {
                new AnswerEntity()
                {
                    Text = "Get-Event Event | where ($_.EventType –eq \"error\").",
                    IsCorrect = false
                },
                new AnswerEntity()
                {
                    Text = "Get-Event Event | where ($_.EventType == \"error\").",
                    IsCorrect = false
                },
                new AnswerEntity()
                {
                    Text = "Search in (Event) * | where EventType –eq \"error\".",
                    IsCorrect = false
                },
                new AnswerEntity()
                {
                    Text = "Search in (Event) \"error\".",
                    IsCorrect = true
                },
                new AnswerEntity()
                {
                    Text = "Select *from Event where EventType == \"error\".",
                    IsCorrect = false
                },
                new AnswerEntity()
                {
                    Text = "Event | where EventType is \"error\".",
                    IsCorrect = false
                },
            },

            Explanations = new List<ExplanationEntity>()
            {
                new ExplanationEntity()
                {
                    Text = "Table scoping: To search a term in a specific table, add in (table-name) just after the search operator:"
                },
                new ExplanationEntity()
                {
                    Text = "Search in table Event: search in (Event) \"error\"| take 100"
                },
                new ExplanationEntity()
                {
                    Text = "Search in multiple tables: search in (Event, SecurityEvent) \"error\"| take 100"
                }
            },

            References = new List<ReferenceEntity>()
            {
                new ReferenceEntity()
                {
                    Text = "Search queries in Azure Monitor logs",
                    Url = "https://docs.microsoft.com/en-us/azure/azure-monitor/log-query/search-queries",
                },
                new ReferenceEntity()
                {
                    Text = "Get started with Log Analytics in Azure Monitor",
                    Url = "https://docs.microsoft.com/en-us/azure/azure-monitor/log-query/get-started-portal",
                },
            },
        };
    }
}