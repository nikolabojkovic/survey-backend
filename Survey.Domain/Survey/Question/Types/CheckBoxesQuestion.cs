using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class CheckBoxesQuestion : Question
    {
        public CheckBoxesQuestion()
        {
            Type = QuestionType.MultipleChoice;
            Answer = new Answer
            {
                Options = new List<CheckBoxOption>
                {
                    new CheckBoxOption { Name = "Options 1", Type = OptionType.Cehckbox },
                    new CheckBoxOption { Name = "Options 2", Type = OptionType.Cehckbox },
                    new CheckBoxOption { Name = "Options 3", Type = OptionType.Cehckbox }
                }
            };
        }

        public void AddOption(Option option)
        {
            (Answer.Options as List<Option>).Add(option);
        }

        public void RemoveOption(Option option)
        {
            (Answer.Options as List<Option>).Remove(option);
        }
    }
}
