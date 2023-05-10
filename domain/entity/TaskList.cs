using System.Collections.Generic;
using NHibernate.Mapping.Attributes;
using NHibernate.SimpleMapping.Attributes;
using NHibernate.Tuple;

namespace todolist.domain.entity
{
    [Table("tasklist")]
    public class TaskList
    {
        [Id(Name = "id", Column = "id")]
        public virtual int id { get; set; }
        
        [Property]
        public virtual string name { get; set; }
        
        // public List<TaskItem> taskItems { get; set; }
    }
}