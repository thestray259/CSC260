using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGameLibrary.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VideoGames",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false),
                    Platform = table.Column<string>(type: "varchar(15)", nullable: false),
                    Genre = table.Column<string>(type: "varchar(100)", nullable: false),
                    Rating = table.Column<string>(type: "varchar(10)", nullable: false),
                    YearOfRelease = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "varchar(75)", nullable: false),
                    LoanedTo = table.Column<string>(type: "varchar(20)", nullable: true),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGames", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGames");
        }
    }
}
