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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _dbContext.Users
                                        .Include(x => x.UserForms)
                                            .ThenInclude(x => x.Form)
                                        .ToListAsync();

            return Ok(Mapper.Map<IEnumerable<UserViewModel>>(users));
        }

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
    }
}
