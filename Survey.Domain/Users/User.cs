using Survey.Domain.Survey;
using System.Collections.Generic;

namespace Survey.Domain.Users
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<FormUser> UserForms { get; }
        public IEnumerable<Response> Responses { get; set; }
    }
}
