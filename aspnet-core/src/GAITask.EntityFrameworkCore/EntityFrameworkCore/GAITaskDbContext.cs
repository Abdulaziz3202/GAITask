using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using GAITask.Authorization.Roles;
using GAITask.Authorization.Users;
using GAITask.MultiTenancy;
using GAITask.ProjectEntities;

namespace GAITask.EntityFrameworkCore
{
    public class GAITaskDbContext : AbpZeroDbContext<Tenant, Role, User, GAITaskDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<TaskItem> Tasks { get; set; }
        //TaskStatus
        public DbSet<TaskStatus> TaskStatus { get; set; }
        public GAITaskDbContext(DbContextOptions<GAITaskDbContext> options)
            : base(options)
        {
        }
    }
}
