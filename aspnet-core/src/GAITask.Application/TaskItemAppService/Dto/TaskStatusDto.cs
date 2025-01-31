using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using GAITask.ProjectEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskStatus = GAITask.ProjectEntities.TaskStatus;

namespace GAITask.TaskItemAppService.Dto
{

    [AutoMap(typeof(TaskStatus))]
    public class TaskStatusDto : EntityDto<long>
    {
        public string Title { get; set; }
    }
}
