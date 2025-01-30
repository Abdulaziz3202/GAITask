using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using GAITask.ProjectEntities;
using GAITask.TaskItemAppService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAITask.TaskItemAppService
{
    public class TaskItemAppService : AsyncCrudAppService<TaskItem, TaskItemDto, Guid, PagedTaskItemResultRequestDto, CreateTaskItemDto, TaskItemDto>
    {





        public TaskItemAppService(IRepository<TaskItem, Guid> repository) : base(repository)
        {




        }
    }
}
