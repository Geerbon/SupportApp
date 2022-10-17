using Microsoft.EntityFrameworkCore;

namespace SupportApplication.Models
{
    public class ApplicationDbContext : DbContext
    {
        //В program подключение к базе данных
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Messages> Messages { get; set; }
    }
}
