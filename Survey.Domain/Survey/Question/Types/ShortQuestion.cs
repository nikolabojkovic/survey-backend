using Survey.Application.Strategy;
using System;
using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class ShortQuestion : Question, IQuestionType
    {
        public ShortQuestion() { }

        public override QuestionType Type { get => QuestionType.Short; protected set { } }

        public Question Create(int sectionId, string text, string description, bool isReqired, string customErrorMessage, bool hasOtherOption, IEnumerable<string> names)
        {
            var question = new ShortQuestion
            {
                Text = text,
                Description = description,
                IsRequired = isReqired,
                CustomErrorMessage = customErrorMessage,
                Answers = new List<Answer>
                {
                    new TextAnswer { CreateAt = DateTime.Now, ModifiedAt = DateTime.Now }
                },
                QuestionSections = new List<SectionQuestion>()
            };

            question.QuestionSections.Add(new SectionQuestion { QuestionId = question.Id, SectionId = sectionId });

            return question;
        }
    }
}
