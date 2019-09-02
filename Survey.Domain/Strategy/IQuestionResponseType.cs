using Survey.Domain.Survey;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Strategy
{
    public interface IQuestionResponseType
    {
        QuestionType Type { get; }
        QuestionResponse GetQuestionResponse(int formId, int userId, int questionId, string text, bool isSelected, string name);
    }
}
