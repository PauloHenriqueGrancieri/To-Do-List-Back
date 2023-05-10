using System;
using System.ComponentModel.DataAnnotations.Schema;
using NHibernate.Mapping.Attributes;
using NHibernate.SimpleMapping.Attributes;

namespace todolist.domain.entity
{
    [NHibernate.SimpleMapping.Attributes.Table("taskitem")]
    public class TaskItem
    {
        [Id(Name = "id", Column = "id")]
        public virtual int id { get; set; }
        
        [Property]
        public virtual string title { get; set; }
        
        [Property]
        public virtual string description { get; set; }
        
        [Property]
        public virtual DateTime createdDate { get; set; }
        
        [Property]
        public virtual DateTime? completionDate { get; set; }
        
        [Property]
        public virtual bool isCompleted { get; set; }

        [ManyToOne(Column = "taskListId")]
        public virtual TaskList taskList { get; set; }
    }
}