using KnowledgeHubPortal.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubPortal.Models.DataAccess
{
    // add-migration -Context KnowledgeHubPortal.Models.DataAccess.KHPDbContext init
    // update-database -Context KnowledgeHubPortal.Models.DataAccess.KHPDbContext
    public class KHPDbContext : DbContext
    {
        // configuration the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=IN3487131W1\\SQLEXPRESS01;Initial Catalog=KHPDB;Integrated Security=True;TrustServerCertificate=True");

        }

        // map the tables
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
