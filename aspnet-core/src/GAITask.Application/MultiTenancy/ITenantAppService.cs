using Abp.Application.Services;
using GAITask.MultiTenancy.Dto;

namespace GAITask.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

