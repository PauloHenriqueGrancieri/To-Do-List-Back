using System.Collections.Generic;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Linq;
using todolist.domain.entity;
using todolist.domain.persistence;
using ISession = NHibernate.ISession;

namespace todolist.domain.repository
{
    public class TaskListRepository : ITaskListRepository
    {
        // private readonly ISession _session;
        private readonly ISession _session;


        public TaskListRepository(ISession session)
        {
            _session = session;
        }


        public async Task<List<TaskList>> findAllAsync()
        {
            return await _session.Query<TaskList>().ToListAsync();
        }

        public async Task<TaskList> findByIdAsync(int id)
        {
            return await _session.GetAsync<TaskList>(id);
        }

        public async Task<TaskList> createAsync(TaskList taskList)
        {
            await _session.SaveAsync(taskList);
            return taskList;
        }

        public async Task<bool> updateAsync(TaskList taskList)
        {
            using (var transaction = _session.BeginTransaction())
            {
                await _session.UpdateAsync(taskList);
                await transaction.CommitAsync();
            }
            return true;
        }

        public async Task<bool> deleteAsync(int id)
        {
            using(var transaction = _session.BeginTransaction())
            {
                var taskList = await findByIdAsync(id);
                if (taskList == null)
                {
                    return false;
                }

                await _session.DeleteAsync(taskList);
                await transaction.CommitAsync();
                return true;
            }
        }
    }
}