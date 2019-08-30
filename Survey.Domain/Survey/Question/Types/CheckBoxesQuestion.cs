using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class CheckBoxesQuestion : Question
    {
        public void AddOption(Option option)
        {
            (Answer.Options as List<Option>).Add(option);
        }

        public void RemoveOption(Option option)
        {
            (Answer.Options as List<Option>).Remove(option);
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
                Answer = new Answer
                {
                    Options = new List<Option>
                    {
                        new CheckBoxOption { Name = "Options 1", Type = OptionType.CehckBox },
                        new CheckBoxOption { Name = "Options 2", Type = OptionType.CehckBox },
                        new CheckBoxOption { Name = "Options 3", Type = OptionType.CehckBox }
                    }
                },
            };

            question.QuestionSections.Add(new SectionQuestion { QuestionId = question.Id, SectionId = sectionId });

            return question;
        }
    }
}
