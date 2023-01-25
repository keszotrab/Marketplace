//using System.Data.Entity;

using Microsoft.EntityFrameworkCore;

namespace Marketplace.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>().HasData(
           new UserAccount() {UserID = 1, Userame = "test", Email = "testEmail", FirstName = "testName", Address = "TestAdress", PhoneNumber ="45678", Password="test", ConfirmPassword="test", LastName="test" },
           new UserAccount() { UserID = 2, Userame = "test2", Email = "testEmail2", FirstName = "testName2", Address = "TestAdress2", PhoneNumber = "456782", Password = "test2", ConfirmPassword = "test2", LastName = "test2" }
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
