using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class ShortQuestion : Question
    {
        private ShortQuestion()
        {
            
        }

        public static ShortQuestion Create(int sectionId, string text, string description, bool isReqired, string customErrorMessage)
        {
            var question = new ShortQuestion
            {
                Type = QuestionType.Short,
                Text = text,
                Description = description,
                IsRequired = isReqired,
                CustomErrorMessage = customErrorMessage,
                Answers = new List<Answer>
                {
                    new TextAnswer { }
                },
                QuestionSections = new List<SectionQuestion>()
            };
            
            question.QuestionSections.Add(new SectionQuestion { QuestionId = question.Id, SectionId = sectionId });

            return question;
        }
    }
}
