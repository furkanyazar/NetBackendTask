using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Add_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnitPrice = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    UnitsInStock = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 149, 100, 222, 11, 60, 173, 209, 3, 30, 42, 111, 78, 58, 41, 221, 78, 54, 116, 170, 252, 52, 161, 229, 84, 80, 97, 123, 44, 104, 13, 151, 113, 253, 195, 108, 112, 10, 216, 123, 189, 147, 84, 2, 101, 53, 59, 250, 254, 223, 18, 141, 242, 120, 233, 90, 102, 161, 42, 168, 38, 81, 39, 200, 6 }, new byte[] { 30, 211, 48, 184, 193, 89, 67, 222, 222, 14, 46, 160, 200, 254, 236, 40, 105, 208, 55, 221, 203, 72, 155, 252, 1, 149, 18, 3, 222, 228, 236, 87, 146, 75, 229, 149, 204, 54, 50, 211, 57, 58, 204, 76, 177, 241, 21, 5, 222, 108, 201, 108, 129, 163, 229, 156, 10, 100, 133, 189, 64, 171, 245, 46, 68, 32, 95, 201, 137, 249, 100, 30, 159, 145, 189, 192, 102, 49, 8, 191, 156, 192, 202, 226, 142, 81, 67, 172, 148, 70, 83, 156, 41, 46, 21, 227, 189, 29, 206, 202, 97, 94, 155, 107, 196, 182, 175, 22, 143, 235, 45, 70, 197, 30, 193, 156, 94, 65, 71, 99, 110, 100, 31, 81, 221, 99, 112, 218 } });

            migrationBuilder.CreateIndex(
                name: "UK_Products_UserId_Name",
                table: "Products",
                columns: new[] { "UserId", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 127, 131, 104, 243, 95, 76, 131, 229, 207, 53, 46, 81, 226, 77, 81, 228, 193, 147, 199, 200, 97, 80, 51, 129, 78, 99, 16, 232, 136, 132, 223, 108, 213, 17, 83, 199, 41, 109, 62, 145, 152, 47, 49, 148, 252, 90, 230, 248, 60, 61, 192, 25, 20, 58, 59, 28, 157, 162, 36, 226, 205, 114, 220, 141 }, new byte[] { 248, 248, 253, 199, 244, 138, 209, 85, 172, 243, 53, 106, 233, 59, 160, 138, 121, 179, 131, 151, 170, 231, 237, 55, 89, 100, 163, 212, 16, 227, 229, 85, 227, 111, 56, 91, 91, 36, 113, 25, 28, 60, 142, 78, 108, 135, 78, 85, 73, 42, 43, 194, 246, 240, 37, 157, 127, 166, 76, 30, 167, 76, 207, 11, 130, 213, 237, 73, 161, 64, 75, 3, 249, 112, 8, 16, 93, 255, 182, 74, 228, 75, 17, 172, 5, 141, 133, 103, 176, 204, 72, 23, 86, 54, 241, 214, 28, 156, 118, 222, 141, 216, 213, 72, 220, 218, 125, 73, 81, 69, 121, 251, 225, 150, 74, 117, 175, 183, 224, 70, 27, 52, 44, 74, 69, 55, 30, 37 } });
        }
    }
}
