using ConsoleCs_TaskManagerLogic.Infrastructure.Services;
using ConsoleCs_TaskManagerLogic.Model.DataType;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCs_TaskManager.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(IUserService userService, ITokenService tokenService, ILogger<AuthController> logger) : Controller
    {
        [HttpPost]
        public ActionResult Authenticate(string login, [FromBody] string password)
        {
            try
            {
                if (userService.IsUserExist(login, password))
                {
                    logger.LogInformation("Generation token");
                    return Ok(tokenService.GenerateToken(login));
                }
                else
                {
                    logger.LogInformation("Invalid login or password");
                    return Unauthorized("Invalid login or password");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult ApiAuthenticate([FromBody] ApiAuthSettings settings)
        {
            try
            {
                if ()
                {

                }
                else
                {

                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
