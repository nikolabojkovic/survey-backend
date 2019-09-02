using Survey.Domain.Survey;
using System.Collections.Generic;

namespace Survey.Application.Results.Survey
{
    public class QuestionResultInputModel
    {
        public int QuestionId { get; set; }
        public QuestionType Type { get; set; }
        public IEnumerable<QuestionResponseInputModel> QuestionReponses { get; set; }
    }
}
