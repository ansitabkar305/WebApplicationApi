using Microsoft.EntityFrameworkCore;

namespace WebApplicationApi.Data
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions <DatabaseContext> options):base (options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> hotels { get; set; }
    }
}
