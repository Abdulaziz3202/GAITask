using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using GAITask.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAITask.ProjectEntities
{
    public class TaskItem : FullAuditedEntity<Guid>
    {

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public long TaskStatusId { get; set; }
        public TaskStatus TaskStatus { get; set; }

        public long AssignedToId { get; set; }
        public User AssignedTo { get; set; }

        public string Comment { get; set; } = string.Empty;
    }

   
}
