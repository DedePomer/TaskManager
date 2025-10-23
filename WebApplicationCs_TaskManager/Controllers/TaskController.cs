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
    }
}
