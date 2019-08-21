using DAL.Entities;
using System.Collections.Generic;

namespace Exam_answerWeb.Infrastructure.Questions
{
    public partial class Az900
    {
        public static QuestionEntity Q6Instance = new QuestionEntity()
        {
            Order = 6,
            Section = "Understand Core Azure Services",
            Contents = new List<ContentEntity>()
            {
                new ContentEntity()
                {
                    Text = "You have an Azure environment that contains 10 virtual networks and 100 virtual machines.",
                },
                new ContentEntity()
                {
                    Text = "You need to limit the amount of inbound traffic to all the Azure virtual networks."
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
                    Text = "One network security group (NSG).",
                },
                new AnswerEntity()
                {
                    Text = "10 virtual network gateways."
                },
                new AnswerEntity()
                {
                    Text = "10 Azure ExpressRoute circuits.",
                },
                new AnswerEntity()
                {
                    Text = "One Azure firewall.",
                    IsCorrect = true
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