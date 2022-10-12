using System;
using System.Security.Cryptography;
using System.Text;
using AltenAPI.Utils;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AltenAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbBooking",
                columns: table => new
                {
                    bookingNumber = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false),
                    roomId = table.Column<int>(type: "int", nullable: false),
                    beginDate = table.Column<DateTime>(type: "date", nullable: false),
                    endDate = table.Column<DateTime>(type: "date", nullable: false),
                    isCancelled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbBooking", x => x.bookingNumber);
                });

            migrationBuilder.CreateTable(
                name: "tbHotel",
                columns: table => new
                {
                    hotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbHotel", x => x.hotelId);
                });

            migrationBuilder.CreateTable(
                name: "tbRoom",
                columns: table => new
                {
                    roomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hotelId = table.Column<int>(type: "int", nullable: false),
                    number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbRoom", x => x.roomId);
                });

            migrationBuilder.CreateTable(
                name: "tbUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GivenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbUsers", x => x.Id);
                });


            var password = HashPassword.HashUserPassword("batman");
            var strSql = @$"
            INSERT INTO tbUsers(Username, EmailAddress, Password, GivenName, Surname, Role) VALUES ('batman', 'batman@gothan.com', '{password}', 'Bruce', 'Wayne', 'admin');
            INSERT INTO tbHotel(name, address) VALUES ('Alten Hotel', 'Cancun');
            INSERT INTO tbRoom(hotelId, number) VALUES (1, 101);
            ";
            migrationBuilder.Sql(strSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbBooking");

            migrationBuilder.DropTable(
                name: "tbHotel");

            migrationBuilder.DropTable(
                name: "tbRoom");

            migrationBuilder.DropTable(
                name: "tbUsers");
        }
    }
}
