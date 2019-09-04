using Survey.Domain.Analytics;
using System.Collections.Generic;

namespace Survey.Application.Analytics
{
    public class AnalyticsViewModel
    {
        public int FormId { get; set; }
        public AnalyticsType Type { get; set; }

        public IEnumerable<AnalyticsQuestionViewModel> Questions { get; set; }

    }
}
