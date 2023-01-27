//using System.Data.Entity;

using Microsoft.EntityFrameworkCore;

namespace Marketplace.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Category> category { get; set; }
        public DbSet<Transaction> transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasData(
                new UserAccount() {UserID = 1, Userame = "test", Email = "testEmail", FirstName = "testName", Address = "TestAdress", PhoneNumber ="45678", Password="test", Rank="Admin", LastName="test" },
                new UserAccount() { UserID = 2, Userame = "test2", Email = "testEmail2", FirstName = "testName2", Address = "TestAdress2", PhoneNumber = "456782", Password = "test2", Rank = "user", LastName = "test2" }
            );

            modelBuilder.Entity<Product>().HasData(
                 new Product() { Id= 1, Name = "Military Rations", CategoryId = 1, Descryption ="Tasty military rations that are handy during camping!", Price = 15.50, Img = null, sellerId = 1 },
                 new Product() { Id = 2, Name = "Tea in a can!", CategoryId = 2, Descryption = "Tea, but in a can!", Price = 5.50, Img = null, sellerId = 1 },
                 new Product() { Id = 3, Name = "Boot of speed +5", CategoryId = 3, Descryption = "Makes you run faster! Only one boot in the pack!", Price = 35.50, Img = null, sellerId = 1 },
                 new Product() { Id = 4, Name = "Candy Orange", CategoryId = 1, Descryption = "Orange, but made of sugar!", Price = 15.50, Img = null, sellerId = 1 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Food"  },
                new Category() { Id = 2, Name = "Drinks" },
                new Category() { Id = 3, Name = "Clothes" }

            );

        }




        public string DbPath { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "UserAccount.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder
       options)
        => options.UseSqlite($"Data Source={DbPath}");

    }
}
