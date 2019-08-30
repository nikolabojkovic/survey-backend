using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Domain.Survey
{
    public class RadioButtonOption : Option
    {
        public string Name { get; set; }
        public bool IsSelected { get; private set; }
        public int GoToSection { get; private set; }

        public override object GetValue()
        {
            return IsSelected;
        }
    }
}
