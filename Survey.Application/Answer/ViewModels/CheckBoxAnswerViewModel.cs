using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application
{
    public class CheckBoxAnswerViewModel : AnswerViewModel
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
