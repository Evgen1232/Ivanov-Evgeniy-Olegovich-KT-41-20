using IvanovEvgeniyKT_41_20.Database.Configurations;
using IvanovEvgeniyKT_41_20.Models;
using Microsoft.EntityFrameworkCore;

namespace IvanovEvgeniyKT_41_20.Database
{
    public class IvanovDbContext : DbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());

        }

        public IvanovDbContext(DbContextOptions<IvanovDbContext> options) : base(options)
        {
        }
    }
}
