using System.Collections.Generic;
using System.Threading.Tasks;
using todolist.domain.entity;

namespace todolist.domain
{
    public interface ITaskListRepository
    {
        Task<List<TaskList>> findAllAsync();
        Task<TaskList> findByIdAsync(int id);
        Task<TaskList> createAsync(TaskList taskList);
        Task<bool> updateAsync(TaskList taskList);
        Task<bool> deleteAsync(int id);
    }
}