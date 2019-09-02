using System;
using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class Answer : Entity
    {
        public int OrderIndex { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public virtual object GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
