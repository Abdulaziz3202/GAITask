using Abp.Authorization;
using GAITask.Authorization.Roles;
using GAITask.Authorization.Users;

namespace GAITask.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
