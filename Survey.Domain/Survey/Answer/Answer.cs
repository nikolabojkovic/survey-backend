using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Domain.Survey
{
    public class Answer : Entity
    {
        public int QuestionId { get; set; }

        public Question Question { get; set; }
        public ICollection<Option> Options { get; set; }
    }
}
