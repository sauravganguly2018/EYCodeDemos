using MahaKumbh.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MahaKumbh.Models.DataAccess
{
    public class MahaKumbhDbContext : DbContext
    {
        // configuration the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=IN3487131W1\\SQLEXPRESS01;Initial Catalog=MahaKumbhDB;Integrated Security=True;TrustServerCertificate=True");

        }

        // map the tables
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }

    }
}
