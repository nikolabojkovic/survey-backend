using System;
using System.Collections.Generic;

namespace Survey.Domain.Survey.Result
{
    public class SurveyResult : Entity
    {
        private SurveyResult() { }

        public bool IsCompleted { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public SurveyActionType ActionType { get; set; }

        public int FormId { get; set; }
        public Form Form { get; set; }

        public ICollection<QuestionResponse> QuestionResponses { get; private set; }

        public static SurveyResult Create(int formId, SurveyActionType actionType, DateTime startedAt, DateTime completedAt)
        {
            return new SurveyResult
            {
                StartedAt = startedAt,
                FormId = formId,
                ActionType = actionType,
                QuestionResponses = new List<QuestionResponse>()
            };
        }

        public void AddResponses(List<QuestionResponse> responses)
        {
            foreach(var response in responses)
                QuestionResponses.Add(response);
        }
    }
}
