using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Domain.Survey
{
    public class ResponseCheckBoxOption : ResponseOption
    {
        public bool IsSelected { get; set; }

        public override object GetValue()
        {
            return IsSelected;
        }
    }
}
