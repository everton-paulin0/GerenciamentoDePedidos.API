using GerenciamentoDePedidos.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDePedidos.Infrastruture.Persistence
{
    public class GerenciamentoDbContext : DbContext
    {
        public GerenciamentoDbContext(DbContextOptions<GerenciamentoDbContext> options) :base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>(e=>
                {
                    e.HasKey(u => u.Id);

                    e.HasMany(u=> u.OwnedOrders)
                    .WithOne(u=> u.UserName)
                    .HasForeignKey(u=> u.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);
                });
            builder
                .Entity<Description>(e =>
                {
                    e.HasKey(d => d.Id);

                    e.HasOne(d => d.Order)
                    .WithMany(d => d.Comments)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.Restrict);

                });
            builder
                .Entity<Order>(e =>
                {
                    e.HasKey(o => o.Id);

                    /*
                    e.HasOne(o => o.Client)
                    .WithMany(o => o.OwnedOrders)
                     .HasForeignKey(o => o.IdClient)
                     .OnDelete(DeleteBehavior.Restrict);
                    */

                    e.HasOne(o => o.UserName)
                    .WithMany(o => o.SellerOrders)
                    .HasForeignKey(o => o.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);
                });

            base.OnModelCreating(builder);
        }
    }
}
