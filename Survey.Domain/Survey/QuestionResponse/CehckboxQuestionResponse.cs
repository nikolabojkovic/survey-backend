using Survey.Application.Strategy;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Survey.Domain.Survey
{
    public class CheckBoxQuestionResponse : QuestionResponse, IQuestionResponseType
    {
        public CheckBoxQuestionResponse () { }

        public string Name { get; set; }
        public bool IsSelected { get; set; }
        public string OtherText { get; set; }

        [NotMapped]
        public QuestionType Type { get => QuestionType.MultipleChoice; }

        public QuestionResponse Create(int surveyResultId, int userId, int questionId, string text, bool isSelected, string name, string otherText, DateTime createdAt)
        {
            return new CheckBoxQuestionResponse
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
