
using System;

namespace Survey.Domain.Survey
{
    public class ResponseOption : Entity
    {
        public int OptionId { get; set; }
        public Option Option { get; set; }

        public int ResponseId { get; set; }
        public Response Response { get; set; }

        public virtual object GetValue()
        {
            throw new NotImplementedException();
        }

    }
}