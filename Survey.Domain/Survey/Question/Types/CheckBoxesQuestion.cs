using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class CheckBoxesQuestion : Question
    {
        private CheckBoxesQuestion()
        {

        }

        public void AddOption(Answer option)
        {
            Answers.Add(option);
        }

        public void RemoveOption(Answer option)
        {
            Answers.Remove(option);
        }

        public static CheckBoxesQuestion Create(int sectionId, string text, string description, bool isReqired, string customErrorMessage)
        {
            var question = new CheckBoxesQuestion
            {
                Type = QuestionType.MultipleChoice,
                Text = text,
                Description = description,
                IsRequired = isReqired,
                CustomErrorMessage = customErrorMessage,
                Answers = new List<Answer>
                {
                    new CheckBoxAnswer { Name = "Options 1" },
                    new CheckBoxAnswer { Name = "Options 2" },
                    new CheckBoxAnswer { Name = "Options 3" }
                },
                QuestionSections = new List<SectionQuestion>()
            };

            question.QuestionSections.Add(new SectionQuestion { QuestionId = question.Id, SectionId = sectionId });

            return question;
        }
    }
}
