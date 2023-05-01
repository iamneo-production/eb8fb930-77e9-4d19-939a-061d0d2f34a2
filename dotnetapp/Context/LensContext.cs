using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Context
{
    public class LensContext : DbContext
    {
        public LensContext(DbContextOptions<LensContext> options) : base(options)
        {
        }

        public DbSet<UserModel> UserTable { get; set; }
        public DbSet<ProductModel> ProductTable { get; set; }
        public DbSet<CartModel> CartTable { get; set; }
        public DbSet<OrderModel> OrderTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UsePropertyAccessMode(PropertyAccessMode.Field);

           

            modelBuilder.Entity<OrderModel>()
                .HasOne<UserModel>(s => s.User)
                .WithMany(ad => ad.Orders)
                .HasForeignKey(ad => ad.UserId)
                .OnDelete(DeleteBehavior.Restrict);

          

        }


    }
}
