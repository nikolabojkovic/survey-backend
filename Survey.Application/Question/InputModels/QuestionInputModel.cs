using Survey.Domain.Survey;
using System.Collections.Generic;

namespace Survey.Application
{
    public class QusetionInputModel
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public string CustomErrorMessage { get; set; }
        public QuestionType Type { get; set; }

        public int SectionId { get; set; }

        public IEnumerable<AnswerInputModel> Answers { get; set; }
    }
}
