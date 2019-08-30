using Survey.Domain.Users;

namespace Survey.Domain.Survey
{
    public class FormUser
    {
        public int FormId { get; set; }
        public Form Form { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}