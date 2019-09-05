using Survey.Domain.Survey;

namespace Survey.Application.Strategy
{
    public interface IAnalyticsStrategy
    {
        IAnalyticsType GetAnalyticsType(QuestionType type);
    }
}
