using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class RadioButtonsQuestion : Question
    {
        public RadioButtonsQuestion()
        {
            Type = QuestionType.SingleChoice;
            Answer = new Answer
            {
                Options = new List<Option>
                {
                    new RadioButtonOption { Name = "Option 1", Type = OptionType.RadioButton },
                    new RadioButtonOption { Name = "Option 2", Type = OptionType.RadioButton },
                    new RadioButtonOption { Name = "Option 3", Type = OptionType.RadioButton }
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
