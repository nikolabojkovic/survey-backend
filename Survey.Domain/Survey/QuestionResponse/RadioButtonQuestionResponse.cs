using Survey.Application.Strategy;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey.Domain.Survey
{
    public class RadioButtonQuestionResponse : QuestionResponse, IQuestionResponseType
    {
        public RadioButtonQuestionResponse() { }

        public string Name { get; set; }
        public bool IsSelected { get; private set; }
        public string OtherText { get; set; }

        [NotMapped]
        public QuestionType Type => QuestionType.SingleChoice;

        public QuestionResponse Create(int surveyResultId, int userId, int questionId, string text, bool isSelected, string name, string otherText, DateTime createdAt)
        {
            return new RadioButtonQuestionResponse
            {
                UserId = userId,
                SurveyResultId = surveyResultId,
                QuestionId = questionId,
                Name = name,
                IsSelected = isSelected,
                CreateAt = createdAt
            };
        }
    }
}
