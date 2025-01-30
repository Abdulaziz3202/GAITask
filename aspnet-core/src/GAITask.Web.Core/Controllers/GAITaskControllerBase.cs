using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace GAITask.Controllers
{
    public abstract class GAITaskControllerBase: AbpController
    {
        protected GAITaskControllerBase()
        {
            LocalizationSourceName = GAITaskConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
