using System.Data.Entity;

namespace Marketplace.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
    }
}
