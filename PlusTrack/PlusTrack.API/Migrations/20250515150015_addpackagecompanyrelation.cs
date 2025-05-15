using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlusTrack.API.Migrations
{
    /// <inheritdoc />
    public partial class addpackagecompanyrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Packages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CompanyId",
                table: "Packages",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Companies_CompanyId",
                table: "Packages",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Companies_CompanyId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_CompanyId",
                table: "Packages");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Packages");
        }
    }
}
