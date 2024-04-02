using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Argus.Platform.Migrations
{
    /// <inheritdoc />
    public partial class _change_key_audit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DocumentId",
                table: "Audits",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Audits_DocumentId",
                table: "Audits",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Audits_Documents_DocumentId",
                table: "Audits",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audits_Documents_DocumentId",
                table: "Audits");

            migrationBuilder.DropIndex(
                name: "IX_Audits_DocumentId",
                table: "Audits");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Audits");
        }
    }
}
