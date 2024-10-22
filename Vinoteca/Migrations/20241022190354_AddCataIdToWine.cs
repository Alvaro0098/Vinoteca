using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vinoteca.Migrations
{
    /// <inheritdoc />
    public partial class AddCataIdToWine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CataId",
                table: "Wines",
                type: "INTEGER",
                 nullable: true); 

            migrationBuilder.CreateTable(
                name: "Cata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    ListaDeInvitados = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cata", x => x.Id);
                });

            //migrationBuilder.UpdateData(
            //    table: "Wines",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    columns: new[] { "CataId", "CreatedAt" },
            //    values: new object[] { 0, new DateTime(2024, 10, 22, 16, 3, 52, 341, DateTimeKind.Local).AddTicks(6420) });

            migrationBuilder.CreateIndex(
                name: "IX_Wines_CataId",
                table: "Wines",
                column: "CataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Cata_CataId",
                table: "Wines",
                column: "CataId",
                principalTable: "Cata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Cata_CataId",
                table: "Wines");

            migrationBuilder.DropTable(
                name: "Cata");

            migrationBuilder.DropIndex(
                name: "IX_Wines_CataId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "CataId",
                table: "Wines");

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 10, 19, 14, 21, 51, 382, DateTimeKind.Local).AddTicks(256));
        }
    }
}
