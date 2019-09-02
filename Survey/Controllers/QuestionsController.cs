using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey.Application;
using Survey.Application.Interfaces;
using Survey.Domain.Survey;

namespace Survey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private ISurveyDbContext _dbContext;

        public QuestionsController(ISurveyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QusetionInputModel questionInputModel)
        {
            var checkBoxQuestion = CheckBoxesQuestion.Create(questionInputModel.SectionId,
                                                     questionInputModel.Text,
                                                     questionInputModel.Description,
                                                     questionInputModel.IsRequired,
                                                     questionInputModel.CustomErrorMessage);
            await _dbContext.Questions.AddAsync(checkBoxQuestion);

            var radioButtonQuestion = RadioButtonsQuestion.Create(questionInputModel.SectionId,
                                                     questionInputModel.Text,
                                                     questionInputModel.Description,
                                                     questionInputModel.IsRequired,
                                                     questionInputModel.CustomErrorMessage);
            await _dbContext.Questions.AddAsync(radioButtonQuestion);

            var shortQuestion = ShortQuestion.Create(questionInputModel.SectionId,
                                                     questionInputModel.Text,
                                                     questionInputModel.Description,
                                                     questionInputModel.IsRequired,
                                                     questionInputModel.CustomErrorMessage);
            await _dbContext.Questions.AddAsync(shortQuestion);
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
