using Microsoft.EntityFrameworkCore;
using Survey.Application.Analytics;
using Survey.Application.Interfaces;
using Survey.Domain.Survey;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Application.Strategy
{
    public class ShortQuestionAnalytics : IAnalyticsType
    {
        private readonly ISurveyDbContext _dbContext;

        public ShortQuestionAnalytics(ISurveyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual QuestionType Type => QuestionType.Short;

        public async Task<IEnumerable<AnalyticsQuestionViewModel>> GetAnalytics(int id, int surveyResultId)
        {
            return await _dbContext.TextQuestionResponses
                                   .Include(x => x.Question)
                                   .Include(x => x.SurveyResult)
                                   .Where(x => x.SurveyResult.FormId == id &&
                                               x.SurveyResultId == surveyResultId &&
                                               x.Question.Type == Type &&
                                               x.Active)
                                   .GroupBy(x => new { x.Question.Id, QuestionText = x.Question.Text, QuestionType = x.Question.Type })
                                   .Select(x => new AnalyticsQuestionViewModel
                                   {
                                       Text = x.Key.QuestionText,
                                       QuestionType = x.Key.QuestionType,
                                       ResponseCount = x.Count(),
                                       Responses = x.Select(r => new AnalyticsTextResponseViewModel
                                       {
                                           Text = r.Text,
                                       })
                                   })
                                   .ToListAsync();
        }
    }
}