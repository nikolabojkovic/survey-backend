using Survey.Domain.Survey;
using System.Collections.Generic;

namespace Survey.Application
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public string CustomErrorMessage { get; set; }
        public QuestionType Type { get; set; }

        public IEnumerable<AnswerViewModel> Answers { get; set; }
    }
}
