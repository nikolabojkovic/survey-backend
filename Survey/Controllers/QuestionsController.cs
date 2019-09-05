using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survey.Application;
using Survey.Application.Interfaces;
using Survey.Application.Strategy;

namespace Survey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private ISurveyDbContext _dbContext;
        private readonly IQuestionStrategy _questionStrategy;

        public QuestionsController(ISurveyDbContext dbContext, IQuestionStrategy questionStrategy)
        {
            _dbContext = dbContext;
            _questionStrategy = questionStrategy;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IEnumerable<QusetionInputModel> questionInputModelList)
        {
            // TODO: Add strategy here
            foreach(var questionInputModel in questionInputModelList)
            {
                await _dbContext.Questions.AddAsync(_questionStrategy.GetQuestionType(questionInputModel.Type)
                                                                     .Create(questionInputModel.SectionId,
                                                                             questionInputModel.Text,
                                                                             questionInputModel.Description,
                                                                             questionInputModel.IsRequired,
                                                                             questionInputModel.CustomErrorMessage,
                                                                             false,
                                                                             questionInputModel.Answers.Select(x => x.Name)));
            }
           
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
