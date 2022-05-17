using Microsoft.EntityFrameworkCore;
using OCMS.Data.Access.Entity;

namespace OCMS.Data.Access
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<CancellationRequest> CancellationRequest { get; set; }

    }
}
