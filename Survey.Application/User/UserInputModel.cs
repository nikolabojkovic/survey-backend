using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application
{
    public class UserInputModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<int> Forms { get; set; }
    }
}
