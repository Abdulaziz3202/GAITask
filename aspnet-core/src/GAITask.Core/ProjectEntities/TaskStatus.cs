using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAITask.ProjectEntities
{
    public class TaskStatus:Entity<long>
    {

        public string Title { get; set; }

        public List<TaskItem> TaskItems { get; set; }
    }
}
