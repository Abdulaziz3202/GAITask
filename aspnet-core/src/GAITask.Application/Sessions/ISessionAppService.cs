using System.Threading.Tasks;
using Abp.Application.Services;
using GAITask.Sessions.Dto;

namespace GAITask.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
