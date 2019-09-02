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

        public ICollection<FormUser> UserForms { get; set;  }
        public ICollection<QuestionResponse> QuestionResponses { get; set; }

        public static User Create(string email, string password, string firstName, string lastName)
        {
            var user = new User
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName
            };

            user.UserForms = new List<FormUser>();

            return user;
        }

        public void AddForm(int formId)
        {
            UserForms.Add(new FormUser { UserId = Id, FormId = formId });
        }
    }
}
