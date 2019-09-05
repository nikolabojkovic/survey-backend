using System;
using System.Collections.Generic;
using System.Linq;
using Survey.Domain.Survey;

namespace Survey.Application.Strategy
{
    public class QuestionStrategy : IQuestionStrategy
    {
        private readonly IEnumerable<IQuestionType> _questionTypes;

        public QuestionStrategy(IEnumerable<IQuestionType> questionTypes)
        {
            _questionTypes = questionTypes;
        }

        public IQuestionType GetQuestionType(QuestionType type)
        {
            return _questionTypes.FirstOrDefault(x => x.Type == type) ?? throw new ArgumentNullException(nameof(type));
        }
    }
}
