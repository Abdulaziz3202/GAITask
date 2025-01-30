using System.Threading.Tasks;
using GAITask.Configuration.Dto;

namespace GAITask.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
