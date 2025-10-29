using ConsoleCs_TaskManagerLogic.Infrastructure.Services;
using ConsoleCs_TaskManagerLogic.Model.DataType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCs_TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   
    public class TaskController(TaskService _taskService, ApiService apiService) : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddTextTask(string text, string? description = default)
        {
            try
            {
                var login = User.FindFirst("name")?.Value;
                if (login != null)
                {
                    await _taskService.AddTextTaskAsync(text, login, description);
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

        [Authorize]
        [HttpGet("{login}")]
        public async Task<ActionResult<List<TextTask>>> GetAllTask()
        {
            try
            {
                var login = User.FindFirst("name")?.Value;
                if (login != null)
                {
                    List<TextTask> tasks = await _taskService.GetTasksAsync(login);
                    return Ok(tasks);
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

        [HttpPost("service/count")]
        public async Task<ActionResult> GetCountTask([FromBody] ApiAuthSettings settings)
        {
            try
            {
                if (await apiService.IsApiKeyExistAsync(settings))
                {
                    return Ok(await _taskService.GetCount());
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
