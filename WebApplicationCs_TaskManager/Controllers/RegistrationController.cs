using ConsoleCs_TaskManagerLogic.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace WebApplicationCs_TaskManager.Controllers
{
    [ApiController]
    [Route("registration")]
    public class RegistrationController : Controller
    {
        private readonly IUserService _userService;
        public RegistrationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult Registration(string login, string password)
        {
            try
            {
                if (!_userService.IsUserExist(login))
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

        [HttpPost]
        [Authorize]
        public ActionResult RegistrationApi(string secret)
        {
            try
            {
                

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
