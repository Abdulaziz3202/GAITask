using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GAITask.Authorization.Users;
using GAITask.ProjectEntities;
using GAITask.Users.Dto;
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
        public TaskStatusDto TaskStatus { get; set; }
        public int TaskStatusId { get; set; }
        public string StatusTitle { get; set; }
        public DateTime CreationTime { get; set; }
        public string CreaterUser { get; set; }


        public long AssignedToId { get; set; }
        public UserDto AssignedTo { get; set; }

        public string Comment { get; set; } = string.Empty;
    }
}
