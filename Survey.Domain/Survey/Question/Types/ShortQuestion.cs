using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class ShortQuestion : Question
    {
        public ShortQuestion()
        {
            Type = QuestionType.Short;
            Answer = new Answer
            {
                Options = new List<Option>
                {
                    new TextOption { Type = OptionType.Text }
                }
            };
        }
    }
}
