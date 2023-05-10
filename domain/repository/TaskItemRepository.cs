using System.Collections.Generic;
using System.Threading.Tasks;
using NHibernate;
using System.Linq;
using NHibernate.Linq;
using todolist.domain.entity;

using ISession = NHibernate.ISession;

namespace todolist.domain.repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        // private readonly ISession _session;
        private readonly ISession _session;
        
        public TaskItemRepository(ISession session)
        {
            _session = session;
        }

        public async Task<List<TaskItem>> findAllAsync()
        {
            return await _session.Query<TaskItem>().ToListAsync();
        }

        public async Task<TaskItem> findByIdAsync(int id)
        {
            return await _session.GetAsync<TaskItem>(id);
        }
        
        public async Task<List<TaskItem>> findByListIdAsync(int listId)
        {
            var items = await _session.Query<TaskItem>()
                .Where(t => t.taskList.id == listId)
                .ToListAsync();
            return items;
        }

        public async Task<TaskItem> createAsync(TaskItem taskItem)
        {
            await _session.SaveAsync(taskItem);
            return taskItem;
        }

        public async Task<bool> updateAsync(TaskItem taskItem)
        {
            using (var transaction = _session.BeginTransaction())
            {
                await _session.UpdateAsync(taskItem);
                await transaction.CommitAsync();
            }
            return true;
        }

        public async Task<bool> deleteAsync(int id)
        {
            using(var transaction = _session.BeginTransaction())
            {
                var taskItem = await findByIdAsync(id);
                if (taskItem == null)
                {
                    return false;
                }

                await _session.DeleteAsync(taskItem);
                await transaction.CommitAsync();
                return true;
            }
        }
    }
}