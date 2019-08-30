﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Domain.Survey
{
    public class CheckBoxOption : Option
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }

        public override object GetValue()
        {
            return IsSelected;
        }
    }
}
