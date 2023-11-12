using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Test.Models;
using Test.Models.Shoes;
using Test.Unifiers;

namespace Test.Data
{
    internal class ShoeContext : DbContext
    {
        public DbSet<Shoe> Shoes { get; set; }
        public DbSet<HighHeels> HighHeels { get; set; }
        public DbSet<HikingBoots> HikingShoes { get; set; }
        public DbSet<Sandals> Sandals { get; set; }
        public DbSet<Sneackers> Sneackers { get; set; }
        public DbSet<SportShoes> SportShoes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCart> UserCarts { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderShoe> OrderedShoes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shoe>()
            .Property(s => s.Id)
            .UseIdentityColumn();
            modelBuilder.Entity<Shoe>().Property(e => e.Price).HasPrecision(18, 2);
            modelBuilder.Entity<HighHeels>().ToTable("HighHeels");
            modelBuilder.Entity<HikingBoots>().ToTable("HikingBoots");
            modelBuilder.Entity<Sandals>().ToTable("Sandals");
            modelBuilder.Entity<Sneackers>()
            .Property(s => s.Closure)
            .HasConversion<string>();
            modelBuilder.Entity<Sneackers>()
            .Property(s => s.Height)
            .HasConversion<string>();

            //Configuration of unify entity UserCart
            modelBuilder.Entity<UserCart>()
            .HasKey(us => new { us.UserId, us.ShoeCId });

            modelBuilder.Entity<UserCart>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserCarts)
                .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<UserCart>()
                .HasOne(us => us.ShoeC)
                .WithMany(s => s.UserCarts)
                .HasForeignKey(us => us.ShoeCId);

            //Configuration of unify entity OrderShoe
            modelBuilder.Entity<OrderShoe>()
            .HasKey(os => new { os.OrderId, os.ShoeId });

            modelBuilder.Entity<OrderShoe>()
                .HasOne(os => os.Order)
                .WithMany(o => o.OrderShoe)
                .HasForeignKey(os => os.OrderId);

            modelBuilder.Entity<OrderShoe>()
                .HasOne(os => os.Shoe)
                .WithMany(s => s.OrderShoe)
                .HasForeignKey(os => os.ShoeId);

            //Configuration of unify entity UserFavorite
            modelBuilder.Entity<UserFavorite>()
            .HasKey(uf => new { uf.UserId, uf.ShoeFId });

            modelBuilder.Entity<UserFavorite>()
                .HasOne(uf => uf.User)
                .WithMany(u => u.UserFavorites)
                .HasForeignKey(uf => uf.UserId);

            modelBuilder.Entity<UserFavorite>()
                .HasOne(uf => uf.ShoeF)
                .WithMany(s => s.UserFavorites)
                .HasForeignKey(os => os.ShoeFId);
        }
    }
}
