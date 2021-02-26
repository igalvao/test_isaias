using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class LegalCaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LegalCase",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    CourtName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalCase", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LegalCase_CourtName",
                table: "LegalCase",
                column: "CourtName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LegalCase");
        }
    }
}
