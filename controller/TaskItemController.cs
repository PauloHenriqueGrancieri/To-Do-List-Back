using Microsoft.AspNetCore.Mvc;
using todolist.domain;
using todolist.domain.entity;
using todolist.useCase.TaskItem;

namespace todolist.controller
{
    [ApiController]
    [Route("/taskItem")]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemRepository taskItemRepository;
        private readonly IServiceProvider serviceProvider;

        private readonly CreateTaskItemUseCase createTaskItemUseCase;
        private readonly DeleteTaskItemUseCase deleteTaskItemUseCase;
        private readonly FindTaskItemUseCase findTaskItemUseCase;
        private readonly UpdateTaskItemUseCase updateTaskItemUseCase;

        public TaskItemController(CreateTaskItemUseCase createTaskItemUseCase,
            DeleteTaskItemUseCase deleteTaskItemUseCase, FindTaskItemUseCase findTaskItemUseCase,
            UpdateTaskItemUseCase updateTaskItemUseCase, ITaskItemRepository taskItemRepository, IServiceProvider provider)
        {
            this.createTaskItemUseCase = createTaskItemUseCase;
            this.deleteTaskItemUseCase = deleteTaskItemUseCase;
            this.findTaskItemUseCase = findTaskItemUseCase;
            this.updateTaskItemUseCase = updateTaskItemUseCase;
            
            this.taskItemRepository = taskItemRepository;
            serviceProvider = provider;
        }

        
        [HttpGet]
        public async Task<IActionResult> findAllAsync()
        {
            var taskItems = await findTaskItemUseCase.findAllAsync();
            return Ok(taskItems);
        }

        [HttpGet("/taskItem/{id}", Name = "GetTaskItemById")]
        public async Task<IActionResult> findByIdAsync(int id)
        {
            var taskItem = await findTaskItemUseCase.findByIdAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return Ok(taskItem);
        }
        
        [HttpGet("/taskItem/listId/{listId}")]
        public async Task<IActionResult> findByListIdAsync(int listId)
        {
            var taskItem = await findTaskItemUseCase.findByListIdAsync(listId);
            if (taskItem == null)
            {
                return NotFound();
            }

            return Ok(taskItem);
        }

        [HttpDelete("/taskItem/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (await deleteTaskItemUseCase.deleteAsync(id))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TaskItem taskItem)
        {
            if (taskItem == null)
            {
                return BadRequest("TaskItem cannot be null");
            }
            
            await createTaskItemUseCase.createAsync(taskItem);
            return CreatedAtRoute("GetTaskItemById", new { id = taskItem.id }, taskItem);
        }

        [HttpPut("/taskItem/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TaskItem taskItem)
        {
            if (id != taskItem.id)
            {
                return BadRequest();
            }

            if (await updateTaskItemUseCase.updateAsync(taskItem))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}