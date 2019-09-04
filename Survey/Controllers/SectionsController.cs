using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey.Application;
using Survey.Application.Interfaces;
using Survey.Domain.Survey;

namespace Survey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionsController : ControllerBase
    {
        private ISurveyDbContext _dbContext;

        public SectionsController(ISurveyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SectionInputModel sectionInputModel)
        {
            var section = Section.Create(sectionInputModel.Name,
                                         sectionInputModel.Description,
                                         sectionInputModel.FormId);
            await _dbContext.Sections.AddAsync(section);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
