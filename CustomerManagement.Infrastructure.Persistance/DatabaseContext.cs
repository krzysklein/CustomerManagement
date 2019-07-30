using Microsoft.EntityFrameworkCore;
using System;

namespace CustomerManagement.Infrastructure.Persistance
{
    public class DatabaseContext : DbContext
    {


        public DatabaseContext(
            DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        }
    }
}
