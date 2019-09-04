using Survey.Domain.Survey;

namespace Survey.Application.Strategy
{
    public interface IQuestionResponseStrategy
    {
        IQuestionResponseType GetQuestionType(QuestionType type);
    }
}
