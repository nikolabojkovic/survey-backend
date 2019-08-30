using Survey.Domain.Users;
using System.Collections.Generic;

namespace Survey.Domain.Survey
{
    public class Response : Entity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public IEnumerable<ResponseOption> ResponseOptions { get; set; }
    }
}