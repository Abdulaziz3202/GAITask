using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace GAITask.EntityFrameworkCore
{
    public static class GAITaskDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<GAITaskDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<GAITaskDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
