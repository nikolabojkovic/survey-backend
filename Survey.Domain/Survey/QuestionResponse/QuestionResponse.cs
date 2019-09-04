using Survey.Domain.Survey.Result;
using Survey.Domain.Users;
using System;

namespace Survey.Domain.Survey
{
    public class QuestionResponse : Entity
    {
        protected QuestionResponse() { }

        public int UserId { get; set; }
        public int SurveyResultId { get; set; }
        public int QuestionId { get; set; }
        
        public DateTime CreateAt { get; set; }

        public User User { get; set; }
        public SurveyResult SurveyResult { get; set; }
        public Question Question { get; set; }
    }
}