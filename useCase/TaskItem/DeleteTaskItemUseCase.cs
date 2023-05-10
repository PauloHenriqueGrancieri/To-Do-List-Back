using System.Threading.Tasks;
using todolist.domain.repositories;

namespace todolist.useCase.TaskItem
{
    public class DeleteTaskItemUseCase
    {
        private readonly TaskItemRepository taskItemRepository;

        public DeleteTaskItemUseCase(TaskItemRepository taskItemRepository)
        {
            this.taskItemRepository = taskItemRepository;
        }

        public async Task<bool> deleteAsync(int id)
        {
            return await taskItemRepository.deleteAsync(id);
        }
    }
}