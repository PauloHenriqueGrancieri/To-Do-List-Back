using System.Threading.Tasks;
using todolist.domain;
using todolist.domain.repository;

namespace todolist.useCase.TaskList
{
    public class UpdateTaskListUseCase
    {
        private readonly ITaskListRepository taskListRepository;

        public UpdateTaskListUseCase(ITaskListRepository taskListRepository)
        {
            this.taskListRepository = taskListRepository;
        }

        public async Task<bool> updateAsync(domain.entity.TaskList taskList)
        {
            return await taskListRepository.updateAsync(taskList);
        }
    }
}