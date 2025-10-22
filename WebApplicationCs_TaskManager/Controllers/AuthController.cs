using ConsoleCs_TaskManagerLogic.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCs_TaskManager.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpGet]
        public ActionResult Authenticate(string login, string password)
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
