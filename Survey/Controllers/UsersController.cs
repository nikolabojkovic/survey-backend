using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Survey.Application;
using Survey.Application.Interfaces;

namespace Survey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private ISurveyDbContext _dbContext;

        public UsersController(ISurveyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _dbContext.Users
                                        .Include(x => x.UserForms)
                                            .ThenInclude(x => x.Form)
                                        .ToListAsync();

            return Ok(Mapper.Map<IEnumerable<UserViewModel>>(users));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] UserInputModel userInputModel)
        {
            var user = Domain.Users.User.Create(userInputModel.Email, userInputModel.Password, userInputModel.FirstName, userInputModel.LastName);

            foreach(var form in userInputModel.Forms)
            {
                user.AddForm(form);
            }

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
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
