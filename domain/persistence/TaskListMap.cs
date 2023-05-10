using System.Security.Claims;
using FluentNHibernate.Mapping;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode.Impl;
using todolist.domain.entity;

namespace todolist.domain.persistence;

public class TaskListMap : ClassMap<TaskList>
{
    public TaskListMap()
    {
        Id(tl => tl.id);
        Map(tl => tl.name);
        // HasMany<TaskItem>(tl => tl.taskItems).Inverse().Cascade.AllDeleteOrphan();
    }
}