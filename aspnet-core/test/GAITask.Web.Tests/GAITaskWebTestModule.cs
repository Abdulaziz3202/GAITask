using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GAITask.EntityFrameworkCore;
using GAITask.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace GAITask.Web.Tests
{
    [DependsOn(
        typeof(GAITaskWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class GAITaskWebTestModule : AbpModule
    {
        public GAITaskWebTestModule(GAITaskEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GAITaskWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(GAITaskWebMvcModule).Assembly);
        }
    }
}