using Survey.Domain.Survey;
using System;

namespace Survey.Application.Strategy
{
    public interface IQuestionResponseType
    {
        QuestionType Type { get; }
        QuestionResponse Create(int surveyResultId, int userId, int questionId, string text, bool isSelected, string name, string otherText, DateTime createdAt);
    }
}
