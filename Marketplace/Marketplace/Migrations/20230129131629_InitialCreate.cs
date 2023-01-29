using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Marketplace.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("category");
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                });



            migrationBuilder.DropTable("product");
            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Descryption = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Img = table.Column<byte[]>(type: "BLOB", nullable: true),
                    sellerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                });



            migrationBuilder.DropTable("transaction");
            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    productId = table.Column<int>(type: "INTEGER", nullable: false),
                    count = table.Column<int>(type: "INTEGER", nullable: false),
                    price = table.Column<double>(type: "REAL", nullable: false),
                    buyerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.Id);
                });

            migrationBuilder.DropTable("userAccount");
            migrationBuilder.CreateTable(
                name: "userAccount",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Userame = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Rank = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAccount", x => x.UserID);
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Drinks" },
                    { 3, "Clothes" }
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "Id", "CategoryId", "Descryption", "Img", "Name", "Price", "sellerId" },
                values: new object[,]
                {
                    { 1, 1, "Tasty military rations that are handy during camping!", null, "Military Rations", 15.5, 1 },
                    { 2, 2, "Tea, but in a can!", null, "Tea in a can!", 5.5, 1 },
                    { 3, 3, "Makes you run faster! Only one boot in the pack!", null, "Boot of speed +5", 35.5, 1 },
                    { 4, 1, "Orange, but made of sugar!", null, "Candy Orange", 15.5, 1 }
                });

            migrationBuilder.InsertData(
                table: "userAccount",
                columns: new[] { "UserID", "Address", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "Rank", "Userame" },
                values: new object[,]
                {
                    { 1, "TestAdress", "testEmail", "testName", "test", "test", "45678", "Admin", "test" },
                    { 2, "TestAdress2", "testEmail2", "testName2", "test2", "test2", "456782", "user", "test2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropTable(
                name: "userAccount");
        }
    }
}
