using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCs_TaskManager.Controllers
{
    [ApiController]
    [Route("Task")]
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

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
