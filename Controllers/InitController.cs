using System.Threading.Tasks;
using hostingRatingWebApi.Database;
using hostingRatingWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace hostingRatingWebApi.Controllers
{
    [Route("init")]
    public class InitController:Controller
    {
        private readonly DatabaseContext _dbContext;

        public InitController (DatabaseContext dbContext)
         {
            _dbContext = dbContext;
        }
        // [HttpGet]
        // public async Task<IActionResult> CreateAdminAsync()
        // {
        //     var newUser = new User("1@wp.pl","1",true);
        //     await _dbContext.AddAsync(newUser);
        //     await _dbContext.SaveChangesAsync();
        //     return Json(newUser);
            
        // }
    }
}