using System;
using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class Option : Entity
    {
        public int OrderIndex { get; set; }
        public OptionType Type { get; set; }

        public int AnswerId { get; set; }
        public Answer Answer { get; set; }

        public IEnumerable<ResponseOption> ResponsOptions { get; set; }

        public virtual object GetValue()
        {
            throw new NotImplementedException();
        }
    }
}
