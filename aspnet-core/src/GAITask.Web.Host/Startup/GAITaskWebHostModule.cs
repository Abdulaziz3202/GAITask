using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GAITask.Configuration;

namespace GAITask.Web.Host.Startup
{
    [DependsOn(
       typeof(GAITaskWebCoreModule))]
    public class GAITaskWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public GAITaskWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GAITaskWebHostModule).GetAssembly());
        }
    }
}
