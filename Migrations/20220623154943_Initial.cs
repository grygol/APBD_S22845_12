using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APBD12.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "List",
                columns: table => new
                {
                    Id_list = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_List", x => x.Id_list);
                });

            migrationBuilder.CreateTable(
                name: "Subscriber",
                columns: table => new
                {
                    Id_subscriber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriber", x => x.Id_subscriber);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    Id_list = table.Column<int>(type: "int", nullable: false),
                    Id_subscriber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Added_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => new { x.Id_list, x.Id_subscriber });
                    table.ForeignKey(
                        name: "FK_Membership_List_Id_list",
                        column: x => x.Id_list,
                        principalTable: "List",
                        principalColumn: "Id_list",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membership_Subscriber_Id_subscriber",
                        column: x => x.Id_subscriber,
                        principalTable: "Subscriber",
                        principalColumn: "Id_subscriber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "List",
                columns: new[] { "Id_list", "Address", "Created_at", "Description", "Name" },
                values: new object[] { 1, "VIP@example.com", new DateTime(2022, 6, 23, 17, 49, 42, 938, DateTimeKind.Local).AddTicks(7950), "Lista zawierająca wszystkich gości VIP", "VIP" });

            migrationBuilder.InsertData(
                table: "Subscriber",
                columns: new[] { "Id_subscriber", "Address", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Antoni@gmail.com", "Antoni Przykładowy", "Verified" },
                    { 2, "bartlomiej@outlook.com", "Bartłomiej Następny", "Unknown" },
                    { 3, "cecylia@poczta.pl", "Cecylia Ostateczna", "Suppressed" }
                });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id_list", "Id_subscriber", "Added_at", "Status" },
                values: new object[] { 1, 1, new DateTime(2022, 6, 23, 17, 49, 42, 972, DateTimeKind.Local).AddTicks(2420), "Unsubscribed" });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id_list", "Id_subscriber", "Added_at", "Status" },
                values: new object[] { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Subscribed" });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id_list", "Id_subscriber", "Added_at", "Status" },
                values: new object[] { 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Subscribed" });

            migrationBuilder.CreateIndex(
                name: "IX_Membership_Id_subscriber",
                table: "Membership",
                column: "Id_subscriber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropTable(
                name: "List");

            migrationBuilder.DropTable(
                name: "Subscriber");
        }
    }
}
