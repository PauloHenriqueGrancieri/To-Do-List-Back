using System.Threading.Tasks;
using todolist.domain;
using todolist.domain.repository;

namespace todolist.useCase.TaskList
{
    public class DeleteTaskListUseCase
    {
        private readonly TaskListRepository taskListRepository;

        public DeleteTaskListUseCase(TaskListRepository taskListRepository)
        {
            this.taskListRepository = taskListRepository;
        }

        public async Task<bool> deleteAsync(int id)
        {
            return await taskListRepository.deleteAsync(id);
        }
    }
}