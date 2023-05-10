using System.Collections.Generic;
using System.Threading.Tasks;
using todolist.domain.entity;

namespace todolist.domain
{
    public interface ITaskItemRepository
    {
        Task<List<TaskItem>> findAllAsync();
        Task<TaskItem> findByIdAsync(int id);
        
        Task<List<TaskItem>> findByListIdAsync(int listId);

        Task<TaskItem> createAsync(TaskItem taskItem);
        Task<bool> updateAsync(TaskItem taskItem);
        Task<bool> deleteAsync(int id);
        
    }
}