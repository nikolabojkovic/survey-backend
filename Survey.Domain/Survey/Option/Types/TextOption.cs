using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Domain.Survey
{
    public class TextOption : Option
    {
        public string Text { get; set; }

        public override object GetValue()
        {
            return Text;
        }
    }
}
