using MediatR;
using Survey.Application.Interfaces;
using Survey.Application.Strategy;
using Survey.Domain.Analytics;
using Survey.Domain.Survey;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Survey.Application.Analytics.Query
{
    class GetSurveyAnalyticsQueryHandler : IRequestHandler<GetSurveyAnalyticsQuery, AnalyticsViewModel>
    {
        private readonly ISurveyDbContext _dbContext;
        private readonly IAnalyticsStrategy _analyticsStrategy;

        public GetSurveyAnalyticsQueryHandler(ISurveyDbContext dbContext,
                                              IAnalyticsStrategy analyticsStrategy)
        {
            _dbContext = dbContext;
            _analyticsStrategy = analyticsStrategy;
        }

        public async Task<AnalyticsViewModel> Handle(GetSurveyAnalyticsQuery request, CancellationToken cancellationToken)
        {
            var questions = new List<AnalyticsQuestionViewModel>();

            foreach (QuestionType questionType in Enum.GetValues(typeof(QuestionType)))
            {
                var analitycsType = _analyticsStrategy.GetAnalyticsType(questionType);
                if (analitycsType != null)
                    questions.AddRange(await analitycsType.GetAnalytics(request.FormId, request.SurveyResultId));
            }

            return new AnalyticsViewModel
            {
                FormId = request.FormId,
                Type = AnalyticsType.Summary,
                Questions = questions
            };
        }
    }
}
