using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAITask.TaskItemAppService.Dto
{
    public class PagedTaskItemResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
