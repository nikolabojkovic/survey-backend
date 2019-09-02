using Survey.Application.Strategy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Survey.Domain.Survey
{
    public class RadioButtonQuestionResponse : QuestionResponse, IQuestionResponseType
    {
        public string Name { get; set; }
        public bool IsSelected { get; private set; }

        [NotMapped]
        public QuestionType Type => QuestionType.SingleChoice;

        public QuestionResponse GetQuestionResponse(int formId, int userId, int questionId, string text, bool isSelected, string name)
        {
            return new RadioButtonQuestionResponse
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
