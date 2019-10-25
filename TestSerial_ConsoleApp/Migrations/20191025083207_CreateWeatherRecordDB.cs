using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestSerial_ConsoleApp.Migrations
{
    public partial class CreateWeatherRecordDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCollection = table.Column<DateTime>(nullable: false),
                    TempOutside = table.Column<double>(nullable: false),
                    TempIndoor = table.Column<double>(nullable: false),
                    HumOutside = table.Column<double>(nullable: false),
                    HumIndoor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherRecords", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherRecords");
        }
    }
}
