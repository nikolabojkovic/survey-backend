using System;
using System.Collections.Generic;
using System.Linq;
using Survey.Domain.Survey;

namespace Survey.Application.Strategy
{
    public class QuestionResponseStrategy : IQuestionResponseStrategy
    {
        private readonly IEnumerable<IQuestionResponseType> _questionResponseTypes;

        public QuestionResponseStrategy(IEnumerable<IQuestionResponseType> questionResponseTypes)
        {
            _questionResponseTypes = questionResponseTypes;
        }

        public IQuestionResponseType GetQuestionType(QuestionType type)
        {
            return _questionResponseTypes.FirstOrDefault(x => x.Type == type) ?? throw new ArgumentNullException(nameof(type));
        }
    }
}
