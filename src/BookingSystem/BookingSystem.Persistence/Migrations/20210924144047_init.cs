using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystem.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Uid = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    BookedQuantity = table.Column<int>(nullable: false),
                    ResourceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity", "Uid" },
                values: new object[] { 1L, "Resource 1", 100, new Guid("08bb3dde-09eb-453e-a2f2-d34183c0c5bb") });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity", "Uid" },
                values: new object[] { 2L, "Resource 2", 200, new Guid("18bb3dde-09eb-453e-a2f2-d34183c0c5bb") });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity", "Uid" },
                values: new object[] { 3L, "Resource 3", 300, new Guid("28bb3dde-09eb-453e-a2f2-d34183c0c5bb") });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity", "Uid" },
                values: new object[] { 4L, "Resource 4", 400, new Guid("38bb3dde-09eb-453e-a2f2-d34183c0c5bb") });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity", "Uid" },
                values: new object[] { 5L, "Resource 5", 500, new Guid("48bb3dde-09eb-453e-a2f2-d34183c0c5bb") });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity", "Uid" },
                values: new object[] { 6L, "Resource 6", 600, new Guid("58bb3dde-09eb-453e-a2f2-d34183c0c5bb") });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity", "Uid" },
                values: new object[] { 7L, "Resource 7", 700, new Guid("68bb3dde-09eb-453e-a2f2-d34183c0c5bb") });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity", "Uid" },
                values: new object[] { 8L, "Resource 8", 800, new Guid("78bb3dde-09eb-453e-a2f2-d34183c0c5bb") });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity", "Uid" },
                values: new object[] { 9L, "Resource 9", 900, new Guid("88bb3dde-09eb-453e-a2f2-d34183c0c5bb") });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Name", "Quantity", "Uid" },
                values: new object[] { 10L, "Resource 10", 1000, new Guid("98bb3dde-09eb-453e-a2f2-d34183c0c5bb") });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ResourceId",
                table: "Bookings",
                column: "ResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Resources");
        }
    }
}
