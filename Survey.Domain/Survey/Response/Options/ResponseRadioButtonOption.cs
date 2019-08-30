using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Domain.Survey
{
    public class ResponseRadioButtonOption : ResponseOption
    {
        public bool IsSelected { get; private set; }

        public override object GetValue()
        {
            return IsSelected;
        }
    }
}
