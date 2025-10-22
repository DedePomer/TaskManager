using ConsoleCs_TaskManagerLogic.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCs_TaskManager.Controllers
{
    [ApiController]
    [Route("reg")]
    public class RegistrationController : Controller
    {
        private readonly IUserService _userService;
        public RegistrationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Delete(string login, string password)
        {
            try
            {
                if (!_userService.IsUserWithThisLoginExist(login))
                {
                    _userService.RegisterUser(login, password);
                    return Ok();
                }
                else 
                {
                    return Conflict("User with this login already exists");
                }
                
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
