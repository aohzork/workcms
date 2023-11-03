using Microsoft.EntityFrameworkCore;

namespace API.Database
{
    public class CrmContext : DbContext
    {
        //entities

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
        }
    }
}
