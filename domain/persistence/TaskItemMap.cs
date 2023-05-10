using FluentNHibernate.Mapping;
using todolist.domain.entity;

namespace todolist.domain.persistence;

public class TaskItemMap : ClassMap<TaskItem>
{
    public TaskItemMap()
    {
        Id(ti => ti.id);
        Map(ti => ti.title);
        Map(ti => ti.description);
        Map(ti => ti.createdDate);
        Map(ti => ti.completionDate);
        Map(ti => ti.isCompleted);
        References(ti => ti.taskList).Column("taskListId");
    }
}