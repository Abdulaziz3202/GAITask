using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GAITask.Authorization.Users;
using GAITask.ProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAITask.TaskItemAppService.Dto
{
    [AutoMap(typeof(TaskItem))]
    public class TaskItemDto : EntityDto<Guid>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int Status { get; set; }

        public long AssignedToUserId { get; set; }
        public User AssignedTo { get; set; }

        public string Comment { get; set; } = string.Empty;
    }
}
