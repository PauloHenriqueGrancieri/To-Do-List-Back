using System.Threading.Tasks;
using todolist.domain;
using todolist.domain.repositories;

namespace todolist.useCase.TaskItem
{
    public class UpdateTaskItemUseCase
    {
        private readonly TaskItemRepository taskItemRepository;

        public UpdateTaskItemUseCase(TaskItemRepository taskItemRepository)
        {
            this.taskItemRepository = taskItemRepository;
        }

        public async Task<bool> updateAsync(domain.entity.TaskItem taskItem)
        {
            return await taskItemRepository.updateAsync(taskItem);
        }
    }
}