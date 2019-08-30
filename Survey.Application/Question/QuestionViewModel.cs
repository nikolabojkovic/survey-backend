using Survey.Domain.Survey;

namespace Survey.Application
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public QuestionType Type { get; set; }

        public AnswerViewModel Answers { get; set; }
    }
}
