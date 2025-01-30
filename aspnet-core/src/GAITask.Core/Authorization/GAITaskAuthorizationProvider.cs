using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace GAITask.Authorization
{
    public class GAITaskAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            context.CreatePermission(PermissionNames.Pages_Tasks, L("Tasks"));
            context.CreatePermission(PermissionNames.Pages_Tasks_Create, L("CreateTask"));
            context.CreatePermission(PermissionNames.Pages_Tasks_Update_Status, L("TasksUpdateStatus"));
    



        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, GAITaskConsts.LocalizationSourceName);
        }
    }
}
