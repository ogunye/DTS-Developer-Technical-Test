using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI.Contracts;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskFilesController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TaskFilesController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAllTasks();
            return Ok(tasks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            var task = await _taskRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskFile task)
        {
            if (task == null)
            {
                return BadRequest("Task cannot be null");
            }
            await _taskRepository.CreateTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, [FromBody] TaskFile task)
        {
            if (id != task.Id)
            {
                return BadRequest("ID mismatch");
            }
            var existingTask = await _taskRepository.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound();
            }
            await _taskRepository.UpdateTask(task);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var existingTask = await _taskRepository.GetTaskById(id);
            if (existingTask == null)
            {
                return NotFound();
            }
            await _taskRepository.DeleteTask(id);
            return NoContent();
        }
    }
}
