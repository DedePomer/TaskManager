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
        private readonly ApiService _apiService;
        public RegistrationController(IUserService userService, ApiService apiService)
        {
            _userService = userService;
            _apiService = apiService;
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

        [HttpPost("api")]
        [Authorize(Policy = "CreateApiConnectionPolicy")]
        public async Task<ActionResult> RegistrationApiAsync([FromBody]string secret)
        {
            try
            {
                await _apiService.RegisterApiKeyAsync(secret);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
