using ConsoleCs_TaskManagerLogic.Infrastructure.Services;
using ConsoleCs_TaskManagerLogic.Model.DataType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplicationCs_TaskManager.Controllers
{
    [ApiController]
    [Route("api")]
    [Authorize]
    public class TaskController(TaskService _taskService) : ControllerBase
    {

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

        [HttpGet]
        public async Task<ActionResult<List<TextTask>>> GetAllTask(int userId)
        {
            try
            {
                var login = User.FindFirst("name")?.Value;
                if (login != null)
                {
                    List<TextTask> tasks =  await _taskService.GetAllTask(login);
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

    }
}
