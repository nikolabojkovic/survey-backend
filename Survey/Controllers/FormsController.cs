using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survey.Application;
using Survey.Application.Analytics.Query;
using Survey.Application.Interfaces;
using Survey.Application.Results.Survey;
using Survey.Application.Strategy;
using Survey.Domain.Survey;
using Survey.Domain.Survey.Result;

namespace Survey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly ISurveyDbContext _dbContext;
        private readonly IQuestionResponseStrategy _questionResponseStrategy;
        private readonly IMediator _mediator;

        public FormsController(ISurveyDbContext dbContext,
                               IQuestionResponseStrategy questionResponseStrategy,
                               IMediator mediator)
        {
            _dbContext = dbContext;
            _questionResponseStrategy = questionResponseStrategy;
            _mediator = mediator;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var forms = await _dbContext.Forms
                                        .Include(x => x.FormUsers)
                                        .Include(x => x.Sections)
                                            .ThenInclude(x => x.SectionQuestions)
                                                .ThenInclude(x => x.Question)
                                                    .ThenInclude(x => x.Answers)
                                        .ToListAsync();

            return Ok(Mapper.Map<IEnumerable<FormViewModel>>(forms));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var form = await _dbContext.Forms
                                       .Include(x => x.FormUsers)
                                          .Include(x => x.Sections)
                                              .ThenInclude(x => x.SectionQuestions)
                                                  .ThenInclude(x => x.Question)
                                                      .ThenInclude(x => x.Answers)
                                        .SingleOrDefaultAsync(x => x.Id == id && x.Active);

            return Ok(Mapper.Map<FormViewModel>(form));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FormInputModel formInputModel)
        {
            await _dbContext.Forms.AddAsync(Form.Create(formInputModel.Name, formInputModel.Description));
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // POST api/values
        [HttpPost("{id}/responses")]
        public async Task<IActionResult> PostResponses(int id, [FromBody] SurveyResultsInputModel results)
        {
            // TODO: open endpoints for start and copmlete survey 
            var surveyResult = await _dbContext.SurveyResults
                                               .Include(x => x.QuestionResponses)
                                               .FirstOrDefaultAsync(x => x.Id == results.SurveyResultId && !x.IsCompleted);
            var isLive = surveyResult != null;
            if (!isLive)
                surveyResult = SurveyResult.Create(id, SurveyActionType.Visit, DateTime.Now, DateTime.Now);

            var responses = new List<QuestionResponse>();
            foreach (var questionResult in results.QuestionResults)
            {
                foreach (var questionResponse in questionResult.QuestionReponses)
                    responses.Add(_questionResponseStrategy.GetQuestionType(_dbContext.Questions
                                                                                      .Where(q => q.Id == questionResult.QuestionId)
                                                                                      .Select(q => q.Type)
                                                                                      .FirstOrDefault()).Create(surveyResult.Id,
                                                                                                                results.UserId,
                                                                                                                questionResult.QuestionId,
                                                                                                                questionResponse.Text,
                                                                                                                true,
                                                                                                                questionResponse.Name,
                                                                                                                questionResponse.OtherText,
                                                                                                                DateTime.Now));
            }

            surveyResult.AddResponses(responses);

            if (!isLive)
                await _dbContext.SurveyResults.AddAsync(surveyResult);
            else
                _dbContext.SurveyResults.Update(surveyResult);

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // PUT api/values/5
        [HttpGet("{id}/result/{surveyResultId}/analytics/summary")]
        public async Task<IActionResult> GetAnalytics(int id, int surveyResultId)
        {
            return Ok(await _mediator.Send(new GetSurveyAnalyticsQuery { FormId = id, SurveyResultId = surveyResultId }));
        }

       
    }
}
