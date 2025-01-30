using System;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using GAITask.EntityFrameworkCore.Seed.Host;
using GAITask.EntityFrameworkCore.Seed.Tenants;
using GAITask.ProjectEntities;
using System.Collections.Generic;
using System.Linq;
using GAITask.Authorization.Users;

namespace GAITask.EntityFrameworkCore.Seed
{
    public static class SeedHelper
    {
        public static void SeedHostDb(IIocResolver iocResolver)
        {
            WithDbContext<GAITaskDbContext>(iocResolver, SeedHostDb);
        }

        public static void SeedHostDb(GAITaskDbContext context)
        {
            context.SuppressAutoSetTenantId = true;

            // Host seed
            new InitialHostDbBuilder(context).Create();

            // Default tenant seed (in host database).
            new DefaultTenantBuilder(context).Create();
            new TenantRoleAndUserBuilder(context, 1).Create();


          

            // Seed tasks
            if (!context.Tasks.Any())
            {
                context.Tasks.AddRange(new List<TaskItem>
            {
                new TaskItem
                {
                    Title = "Fix Login Bug",
                    Description = "Resolve login issue for mobile users",
                    Status = TaskStatus.InProgress,
                    AssignedToUserId = 3,
                    Comment = "Investigating the root cause."
                },
                new TaskItem
                {
                    Title = "Add Dark Mode",
                    Description = "Implement dark mode in the UI",
                    Status = TaskStatus.Open,
                    AssignedToUserId = 3,
                    Comment = "Waiting for UI design."
                },
                new TaskItem
                {
                    Title = "Optimize DB Queries",
                    Description = "Improve query performance",
                    Status = TaskStatus.DoneDev,
                    AssignedToUserId = 2,
                    Comment = "Queries optimized and tested."
                }
            });

                context.SaveChanges();
            }

        }

        private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
            where TDbContext : DbContext
        {
            using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
                {
                    var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                    contextAction(context);

                    uow.Complete();
                }
            }
        }
    }
}
