using Microsoft.EntityFrameworkCore;
using Models;

namespace Database
{
    public class EntityContext : DbContext
    {
        public DbSet<Images> Images { get; set; }
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("InsertSQL string here")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }


    }
}