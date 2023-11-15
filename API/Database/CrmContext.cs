using API.Models;
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
        public DbSet<UCred> UCreds { get; set; }

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

            modelBuilder.Entity<User>().HasData(new User {
                Id = 1,
                UserName = "Testuser",
                FirstName = "Test",
                LastName = "User",
                Email = "test.user@workcrm.com",
                LinkedInProfile = "https://www.linkedin.com/in/test-user-a0x11111"
            });

            modelBuilder.Entity<JobApplication>().HasData(new JobApplication
            {
                Id = 1,
                UserId = 1,
                Company = "Test Company",
                ApplicationURL = "https://www.test-application-workcrm.com"
            });

            modelBuilder.Entity<ApplicationLog>().HasData(new ApplicationLog
            {
                Id=1,
                ApplicationId = 1,
                Message = "Test message",
                Date = new DateTime(2023, 1, 1)
            });
        }
    }
}
