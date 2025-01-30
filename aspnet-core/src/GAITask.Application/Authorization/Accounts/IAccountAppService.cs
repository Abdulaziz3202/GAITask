using System.Threading.Tasks;
using Abp.Application.Services;
using GAITask.Authorization.Accounts.Dto;

namespace GAITask.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
