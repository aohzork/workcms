using API.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class CrmContext : DbContext
    {
        //entities
        public DbSet<User> Users {get; set }
    }
}
