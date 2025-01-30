using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using GAITask.Configuration.Dto;

namespace GAITask.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : GAITaskAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
