using DTSContract;
using DTSDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DTSTaskManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagersController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public TaskManagersController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTaskAssignedAsync()
        {
            var taskManagers = await _repositoryManager.TaskManager.GetAllTaskManagersAsync(false);
            return Ok(taskManagers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskManagerByIdAsync(Guid id)
        {
            var taskManager = await _repositoryManager.TaskManager.GetTaskManagerAsync(id, false);
            if (taskManager == null)
            {
                return NotFound();
            }
            return Ok(taskManager);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskManagerAsync([FromBody] TaskManager taskManager)
        {
            if (taskManager == null)
            {
                return BadRequest("Task Manager is null");
            }
            _repositoryManager.TaskManager.AddTask(taskManager);
            await _repositoryManager.SaveAsync();
            
            return CreatedAtAction(nameof(GetTaskManagerByIdAsync), new { id = taskManager.Id }, taskManager);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskManagerAsync(Guid id, [FromBody] TaskManager taskManager)
        {
            if (taskManager == null)
            {
                return BadRequest("Task Manager is null");
            }
            var existingTaskManager = await _repositoryManager.TaskManager.GetTaskManagerAsync(id, false);
            if (existingTaskManager == null)
            {
                return NotFound();
            }
            _repositoryManager.TaskManager.UpdateTask(taskManager);
            await _repositoryManager.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskManagerAsync(Guid id)
        {
            var taskManager = await _repositoryManager.TaskManager.GetTaskManagerAsync(id, false);
            if (taskManager == null)
            {
                return NotFound();
            }
            _repositoryManager.TaskManager.DeleteTask(taskManager);
            await _repositoryManager.SaveAsync();
            return NoContent();
        }
    }
}
