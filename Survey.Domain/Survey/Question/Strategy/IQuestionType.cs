using Survey.Domain.Survey;
using System.Collections.Generic;

namespace Survey.Application.Strategy
{
    public interface IQuestionType
    {
        QuestionType Type { get; }
        Question Create(int sectionId, string text, string description, bool isReqired, string customErrorMessage, bool hasOtherOption, IEnumerable<string> names);
    }
}
