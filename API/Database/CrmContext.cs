using API.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class CrmContext : DbContext
    {
        //entities
        public DbSet<User> Users { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<ApplicationLog> ApplicationLogs { get; set; }

    }
}
