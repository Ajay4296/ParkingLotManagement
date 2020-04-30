using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class InitialMigrtin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingSpace",
                columns: table => new
                {
                    VehicalNo = table.Column<string>(nullable: false),
                    VehicalType = table.Column<string>(nullable: true),
                    ChargesPerHour = table.Column<int>(nullable: false),
                    EntryTime = table.Column<DateTime>(nullable: false),
                    DriverCategory = table.Column<string>(nullable: true),
                    ParkingType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpace", x => x.VehicalNo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSpace");
        }
    }
}
