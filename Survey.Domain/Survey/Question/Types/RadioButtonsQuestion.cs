using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class RadioButtonsQuestion : Question
    {
        private RadioButtonsQuestion()
        {
     
        }

        public static RadioButtonsQuestion Create(int sectionId, string text, string description, bool isReqired, string customErrorMessage)
        {
            var question = new RadioButtonsQuestion
            {
                Type = QuestionType.SingleChoice,
                Text = text,
                Description = description,
                IsRequired = isReqired,
                CustomErrorMessage = customErrorMessage,
                Answers = new List<Answer>
                {
                    new RadioButtonAnswer { Name = "Option 1" },
                    new RadioButtonAnswer { Name = "Option 2" },
                    new RadioButtonAnswer { Name = "Option 3" }
                },
                QuestionSections = new List<SectionQuestion>()
            };

            question.QuestionSections.Add(new SectionQuestion { QuestionId = question.Id, SectionId = sectionId });

            return question;
        }

        public void AddOption(Answer option)
        {
            Answers.Add(option);
        }

        public void RemoveOption(Answer option)
        {
            Answers.Remove(option);
        }
    }
}
