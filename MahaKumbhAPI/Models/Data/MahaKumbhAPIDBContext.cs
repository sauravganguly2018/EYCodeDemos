using Microsoft.EntityFrameworkCore;

namespace MahaKumbhAPI.Models.Data
{
    public class MahaKumbhAPIDBContext : DbContext
    {
        public MahaKumbhAPIDBContext(DbContextOptions<MahaKumbhAPIDBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
