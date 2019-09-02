using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survey.Application;
using Survey.Application.Interfaces;
using Survey.Application.Results.Survey;
using Survey.Application.Strategy;
using Survey.Domain.Survey;
using Survey.Domain.Users;

namespace Survey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly ISurveyDbContext _dbContext;
        private readonly IQuestionResponseStrategy _questionResponseStrategy;

        public FormsController(ISurveyDbContext dbContext, IQuestionResponseStrategy questionResponseStrategy)
        {
            _dbContext = dbContext;
            _questionResponseStrategy = questionResponseStrategy;
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
            var form = await _dbContext.Forms.SingleOrDefaultAsync(x => x.Id == id && x.Active);

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
            var responses = new List<QuestionResponse>();
            var questionResults = results.QuestionResults.SelectMany(questionResult => questionResult.QuestionReponses.Select(questionResponse => questionResponse));

            foreach (var questionResult in results.QuestionResults)
            {
                foreach (var questionResponse in questionResult.QuestionReponses)
                    responses.Add(_questionResponseStrategy.GetQuestionType(_dbContext.Questions
                                                                                      .Where(q => q.Id == questionResult.QuestionId)
                                                                                      .Select(q => q.Type)
                                                                                      .FirstOrDefault()).GetQuestionResponse(id,
                                                                                                                             results.UserId,
                                                                                                                             questionResult.QuestionId,
                                                                                                                             questionResponse.Text,
                                                                                                                             true,
                                                                                                                             questionResponse.Name));
            }

            await _dbContext.QuestionResponses.AddRangeAsync(responses);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
