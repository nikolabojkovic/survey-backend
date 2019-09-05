using Microsoft.EntityFrameworkCore;
using Survey.Application.Analytics;
using Survey.Application.Interfaces;
using Survey.Domain.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Application.Strategy
{
    public class SingleChoiceQuestionAnalytics : IAnalyticsType
    {
        private readonly ISurveyDbContext _dbContext;

        public SingleChoiceQuestionAnalytics(ISurveyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual QuestionType Type => QuestionType.SingleChoice;

        public async Task<IEnumerable<AnalyticsQuestionViewModel>> GetAnalytics(int id, int surveyResultId)
        {
           return await _dbContext.RadioButtonQuestionResponses
                                  .Select(x => new { x.Question, x.SurveyResult.FormId, SurveyResultId = x.SurveyResult.Id, x.Active, x.Name })
                                  .Where(x => x.FormId == id &&
                                              x.SurveyResultId == surveyResultId &&
                                              x.Question.Type == QuestionType.SingleChoice &&
                                              x.Active)
                                  .GroupBy(x => new { QuestionId = x.Question.Id, QuestionText = x.Question.Text, QuestionType = x.Question.Type })
                                  .Select(g => new AnalyticsQuestionViewModel
                                  {
                                      Text = g.Key.QuestionText,
                                      QuestionType = g.Key.QuestionType,
                                      ResponseCount = g.Count(),
                                      Responses = g.Select(r => r.Name).Distinct().Select(name => new AnalyticsSelectResponseViewModel
                                      {
                                          Name = name,
                                          Percentage = Convert.ToDecimal(g.Count(x => x.Name == name)) / g.Count() * 100
                                      })
                                  })
                                  .ToListAsync();
        }
    }
}