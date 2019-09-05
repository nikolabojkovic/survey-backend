using MediatR;

namespace Survey.Application.Analytics.Query
{
    public class GetSurveyAnalyticsQuery : IRequest<AnalyticsViewModel>
    {
        public int FormId { get; set; }
        public int SurveyResultId { get; set; }
    }
}
