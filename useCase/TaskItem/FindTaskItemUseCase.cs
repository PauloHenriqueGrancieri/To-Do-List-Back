using System.Collections.Generic;
using System.Threading.Tasks;
using todolist.domain;
using todolist.domain.repositories;

namespace todolist.useCase.TaskItem
{
    public class FindTaskItemUseCase
    {
        private readonly TaskItemRepository taskItemRepository;

        public FindTaskItemUseCase(TaskItemRepository taskItemRepository)
        {
            this.taskItemRepository = taskItemRepository;
        }

        public async Task<List<domain.entity.TaskItem>> findAllAsync()
        {
            return await taskItemRepository.findAllAsync();
        }
        
        public async Task<domain.entity.TaskItem> findByIdAsync(int id)
        {
            return await taskItemRepository.findByIdAsync(id);
        }
        
        public async Task<List<domain.entity.TaskItem>> findByListIdAsync(int listId)
        {
            return await taskItemRepository.findByListIdAsync(listId);
        }
    }
}