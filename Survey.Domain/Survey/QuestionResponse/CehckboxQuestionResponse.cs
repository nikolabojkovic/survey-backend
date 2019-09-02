using Survey.Application.Strategy;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey.Domain.Survey
{
    public class CehckBoxQuestionResponse : QuestionResponse, IQuestionResponseType
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }

        [NotMapped]
        public QuestionType Type { get => QuestionType.MultipleChoice; }

        public QuestionResponse GetQuestionResponse(int formId, int userId, int questionId, string text, bool isSelected, string name)
        {
            return new CehckBoxQuestionResponse
            {
                UserId = userId,
                FormId = formId,
                QuestionId = questionId,
                Name = name,
                IsSelected = isSelected
            };
        }
    }
}
