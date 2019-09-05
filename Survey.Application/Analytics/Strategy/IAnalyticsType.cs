using Survey.Application.Analytics;
using Survey.Domain.Survey;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Survey.Application.Strategy
{
    public interface IAnalyticsType
    {
        QuestionType Type { get; }
        Task<IEnumerable<AnalyticsQuestionViewModel>> GetAnalytics(int id, int surveyResultId);
    }
}
