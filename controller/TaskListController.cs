using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todolist.domain;
using todolist.domain.entity;
using todolist.useCase.TaskList;

namespace todolist.controller
{
    
    [ApiController]
    [Route("/taskList")]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListRepository taskListRepository;
        private readonly IServiceProvider serviceProvider;
        
        private readonly CreateTaskListUseCase createTaskListUseCase;
        private readonly DeleteTaskListUseCase deleteTaskListUseCase;
        private readonly FindTaskListUseCase findTaskListUseCase;
        private readonly UpdateTaskListUseCase updateTaskListUseCase;

        public TaskListController(CreateTaskListUseCase createTaskListUseCase,
            DeleteTaskListUseCase deleteTaskListUseCase, FindTaskListUseCase findTaskListUseCase,
            UpdateTaskListUseCase updateTaskListUseCase, ITaskListRepository taskListRepository, IServiceProvider provider)
        {
            this.createTaskListUseCase = createTaskListUseCase;
            this.deleteTaskListUseCase = deleteTaskListUseCase;
            this.findTaskListUseCase = findTaskListUseCase;
            this.updateTaskListUseCase = updateTaskListUseCase;
            
            this.taskListRepository = taskListRepository;
            serviceProvider = provider;
        }
        
        [HttpGet]
        public async Task<IActionResult> findAllAsync()
        {
            var taskLists = await findTaskListUseCase.findAllAsync();
            return Ok(taskLists);
        }

        [HttpGet("/taskList/{id}", Name = "GetTaskListById")]
        public async Task<IActionResult> findByIdAsync(int id)
        {
            var taskList = await findTaskListUseCase.findByIdAsync(id);
            if (taskList == null)
            {
                return NotFound();
            }

            return Ok(taskList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(TaskList taskList)
        {
            if (taskList == null)
            {
                return BadRequest("TaskList cannot be null");
            }
            await createTaskListUseCase.createAsync(taskList);
            return CreatedAtRoute("GetTaskListById", new { id = taskList.id }, taskList);
        }


        [HttpPut("/taskList/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TaskList taskList)
        {
            if (id != taskList.id)
            {
                return BadRequest("Unable to update the TaskList");
            }

            if (await updateTaskListUseCase.updateAsync(taskList))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("/taskList/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (await deleteTaskListUseCase.deleteAsync(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}