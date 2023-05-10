using System.Collections.Generic;
using System.Threading.Tasks;
using todolist.domain;
using todolist.domain.repository;

namespace todolist.useCase.TaskList
{
    public class FindTaskListUseCase
    {
        private readonly TaskListRepository taskListRepository;

        public FindTaskListUseCase(TaskListRepository taskListRepository)
        {
            this.taskListRepository = taskListRepository;
        }

        public async Task<List<domain.entity.TaskList>> findAllAsync()
        {
            return await taskListRepository.findAllAsync();
        }

        public async Task<domain.entity.TaskList> findByIdAsync(int id)
        {
            return await taskListRepository.findByIdAsync(id);
        }
    }
}