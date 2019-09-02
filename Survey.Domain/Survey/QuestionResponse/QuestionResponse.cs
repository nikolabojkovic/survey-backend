using Survey.Domain.Users;

namespace Survey.Domain.Survey
{
    public class QuestionResponse : Entity
    {
        public int UserId { get; set; }
        public int FormId { get; set; }
        public int QuestionId { get; set; }

        public User User { get; set; }
        public Form Form { get; set; }
        public Question Question { get; set; }
    }
}