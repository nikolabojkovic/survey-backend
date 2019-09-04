using Survey.Application.Strategy;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey.Domain.Survey
{
    public class TextQuestionResponse : QuestionResponse, IQuestionResponseType
    {
        public TextQuestionResponse() { }

        public string Text { get; set; }

        [NotMapped]
        public QuestionType Type => QuestionType.Short;

        public QuestionResponse Create(int surveyResultId, int userId, int questionId, string text, bool isSelected, string name, string otherText, DateTime createdAt)
        {
            return new TextQuestionResponse
            {
                UserId = userId,
                SurveyResultId = surveyResultId,
                QuestionId = questionId,
                Text = text,
                CreateAt = createdAt
            };
        }
    }
}
