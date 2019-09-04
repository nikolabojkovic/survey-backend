using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] QusetionInputModel questionInputModel)
        {
            // TODO: Add strategy here
            var checkBoxQuestion = CheckBoxesQuestion.Create(questionInputModel.SectionId,
                                                     questionInputModel.Text,
                                                     questionInputModel.Description,
                                                     questionInputModel.IsRequired,
                                                     questionInputModel.CustomErrorMessage,
                                                     false);
            await _dbContext.Questions.AddAsync(checkBoxQuestion);

            var radioButtonQuestion = RadioButtonsQuestion.Create(questionInputModel.SectionId,
                                                     questionInputModel.Text,
                                                     questionInputModel.Description,
                                                     questionInputModel.IsRequired,
                                                     questionInputModel.CustomErrorMessage,
                                                     false);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] QusetionInputModel questionUpdateModel)
        {
            var question = await _dbContext.Questions.FirstOrDefaultAsync(x => x.Active && x.Id == id);
            question.Update(questionUpdateModel.Text,
                            questionUpdateModel.Description,
                            questionUpdateModel.IsRequired,
                            questionUpdateModel.CustomErrorMessage);
            _dbContext.Questions.Update(question); 
            return NoContent();
        }
    }
}
