using Survey.Application.Strategy;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey.Domain.Survey
{
    public class TextQuestionResponse : QuestionResponse, IQuestionResponseType
    {
        public string Text { get; set; }

        [NotMapped]
        public QuestionType Type => QuestionType.Short;

        public QuestionResponse GetQuestionResponse(int formId, int userId, int questionId, string text, bool isSelected, string name)
        {
            return new TextQuestionResponse
            {
                UserId = userId,
                FormId = formId,
                QuestionId = questionId,
                Text = text
            };
        }
    }
}
