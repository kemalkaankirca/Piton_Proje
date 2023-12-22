using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace PitonProject.Models
{
    public class BrandContext : DbContext
    {
        public BrandContext(DbContextOptions<BrandContext> options) : base(options)
        {
            
        }

        public DbSet<Tasks> Tasks { get; set; }
    }
}
