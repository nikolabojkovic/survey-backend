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
    public class SectionsController : ControllerBase
    {
        private ISurveyDbContext _dbContext;

        public SectionsController(ISurveyDbContext dbContext)
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
        public async Task<IActionResult> Post([FromBody] SectionInputModel sectionInputModel)
        {
            var section = Section.Create(sectionInputModel.Name,
                                         sectionInputModel.Description,
                                         sectionInputModel.FormId);
            await _dbContext.Sections.AddAsync(section);
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
