using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application
{
    public class RadioButtonOptionViewModel : OptionViewModel
    {
        public string Name { get; set; }
        public bool IsSelected { get; private set; }
        public int GoToSection { get; private set; }
    }
}
