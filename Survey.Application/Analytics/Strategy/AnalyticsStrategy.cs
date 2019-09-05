using Survey.Application.Strategy;
using Survey.Domain.Survey;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survey.Application.Analytics.Strategy
{
    public class AnalyticsStrategy : IAnalyticsStrategy
    {
        private readonly IEnumerable<IAnalyticsType> _analyticsTypes;

        public AnalyticsStrategy(IEnumerable<IAnalyticsType> analyticsTypes)
        {
            _analyticsTypes = analyticsTypes;
        }

        public IAnalyticsType GetAnalyticsType(QuestionType type)
        {
            return _analyticsTypes.FirstOrDefault(x => x.Type == type);
        }
    }
}
