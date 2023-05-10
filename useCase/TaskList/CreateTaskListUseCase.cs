using System.Threading.Tasks;
using todolist.domain;
using todolist.domain.repository;

namespace todolist.useCase.TaskList
{
    public class CreateTaskListUseCase
    {
        private readonly TaskListRepository taskListRepository;

        public CreateTaskListUseCase(TaskListRepository taskListRepository)
        {
            this.taskListRepository = taskListRepository;
        }

        public async Task<domain.entity.TaskList> createAsync(domain.entity.TaskList taskList)
        {
            return await taskListRepository.createAsync(taskList);
        }
    }
}