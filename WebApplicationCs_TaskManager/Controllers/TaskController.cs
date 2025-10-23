using ConsoleCs_TaskManagerLogic.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCs_TaskManager.Controllers
{
    [ApiController]
    [Route("api")]
    [Authorize]
    public class TaskController(TaskService _taskService) : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAllTask(int taskId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> AddTextTask(string text, string? description = default)
        {
            try
            {
                var login = User.FindFirst("name")?.Value;
                if (login != null)
                {
                    await _taskService.AddTextTaskAsync(login, text, description);
                    return Ok();
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
