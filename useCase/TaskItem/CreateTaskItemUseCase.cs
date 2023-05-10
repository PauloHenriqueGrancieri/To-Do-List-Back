using System.Threading.Tasks;
using todolist.domain;
using todolist.domain.repositories;

namespace todolist.useCase.TaskItem
{
    public class CreateTaskItemUseCase
    {
        private readonly TaskItemRepository taskItemRepository;

        public CreateTaskItemUseCase(TaskItemRepository taskItemRepository)
        {
            this.taskItemRepository = taskItemRepository;
        }
        
        public async Task<domain.entity.TaskItem> createAsync(domain.entity.TaskItem taskItem)
        {
            return await taskItemRepository.createAsync(taskItem);
        }
    }
}