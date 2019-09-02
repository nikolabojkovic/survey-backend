using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Application.Results.Survey
{
    public class SurveyResultsInputModel
    {
        public int UserId { get; set; }
        public IEnumerable<QuestionResultInputModel> QuestionResults { get; set; }

    }
}
