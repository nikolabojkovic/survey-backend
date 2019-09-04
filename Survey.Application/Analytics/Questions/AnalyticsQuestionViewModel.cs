using Survey.Domain.Survey;
using System.Collections.Generic;

namespace Survey.Application.Analytics
{
    public class AnalyticsQuestionViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ResponseCount { get; set; }
        public QuestionType QuestionType { get; set; }

        public IEnumerable<AnalyticsResponseViewModel> Responses { get; set; }
    }
}