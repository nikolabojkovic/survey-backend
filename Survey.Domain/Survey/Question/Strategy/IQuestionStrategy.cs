using Survey.Domain.Survey;

namespace Survey.Application.Strategy
{
    public interface IQuestionStrategy
    {
        IQuestionType GetQuestionType(QuestionType type);
    }
}
