using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;
using GAITask.ProjectEntities;


namespace GAITask.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }
        // Navigation property
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        public static User CreateTenantAdminUser(int tenantId, string emailAddress)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }

        public static User CreateTenantRegularUser(int tenantId, string emailAddress)
        {

            var RegularUserName = "regular";
            var user = new User
            {
                TenantId = tenantId,
                UserName = RegularUserName,
                Name = RegularUserName,
                Surname = RegularUserName,
                EmailAddress = emailAddress,
                Roles = new List<UserRole>()
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
