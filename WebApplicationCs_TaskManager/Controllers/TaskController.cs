using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCs_TaskManager.Controllers
{
    [ApiController]
    [Route("api")]
    [Authorize]
    public class TaskController: ControllerBase
    {
        [HttpGet]     
        public ActionResult GetAllTask(int taskId)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult AddTextTask(string text, string? description = default)
        {
            try
            {
                var login = User.FindFirst("name")?.Value;
                if (login != null)
                {

                }
                else 
                {
                    return Unauthorized();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
