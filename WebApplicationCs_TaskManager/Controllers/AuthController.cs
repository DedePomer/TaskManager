using ConsoleCs_TaskManagerLogic.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCs_TaskManager.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(IUserService userService, ITokenService tokenService) : Controller
    {        
        [HttpPost]
        public ActionResult Authenticate(string login, string password)
        {
            try
            {
                if (userService.IsUserExist(login, password))
                {
                    return Ok(tokenService.GenerateToken(login));
                }
                else 
                {
                    return Unauthorized("Invalid login or password");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
