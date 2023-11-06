using API.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class CrmContext : DbContext
    {
        public CrmContext(DbContextOptions<CrmContext> options):base(options) { }
        //entities
        public DbSet<User> Users { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<ApplicationLog> ApplicationLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(c => c.JobApplications)
                .WithOne(p => p.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<JobApplication>()
                .HasMany(c => c.ApplicationLogs)
                .WithOne(p => p.JobApplication)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
