using Survey.Application.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survey.Domain.Survey
{
    public class CheckBoxesQuestion : Question, IQuestionType
    {
        public CheckBoxesQuestion() { }

        public override QuestionType Type { get => QuestionType.MultipleChoice; protected set { } }

        public void AddOption(Answer option)
        {
            Answers.Add(option);
        }

        public void RemoveOption(Answer option)
        {
            Answers.Remove(option);
        }

        public Question Create(int sectionId, string text, string description, bool isReqired, string customErrorMessage, bool hasOtherOption, IEnumerable<string> names)
        {
            var question = new CheckBoxesQuestion
            {
                Text = text,
                Description = description,
                IsRequired = isReqired,
                CustomErrorMessage = customErrorMessage,
                Answers = names.Select(name => new CheckBoxAnswer { Name = name, CreateAt = DateTime.Now, ModifiedAt = DateTime.Now }).ToArray(),
                QuestionSections = new List<SectionQuestion>()
            };

            question.QuestionSections.Add(new SectionQuestion { QuestionId = question.Id, SectionId = sectionId });

            return question;
        }
    }
}
