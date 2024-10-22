using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vinoteca.Migrations
{
    /// <inheritdoc />
    public partial class AddCataIdToWine2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Cata_CataId",
                table: "Wines");

            migrationBuilder.AlterColumn<int>(
                name: "CataId",
                table: "Wines",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CataId", "CreatedAt" },
                values: new object[] { null, new DateTime(2024, 10, 22, 16, 21, 36, 692, DateTimeKind.Local).AddTicks(3429) });

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Cata_CataId",
                table: "Wines",
                column: "CataId",
                principalTable: "Cata",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Cata_CataId",
                table: "Wines");

            migrationBuilder.AlterColumn<int>(
                name: "CataId",
                table: "Wines",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Wines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CataId", "CreatedAt" },
                values: new object[] { 0, new DateTime(2024, 10, 22, 16, 3, 52, 341, DateTimeKind.Local).AddTicks(6420) });

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Cata_CataId",
                table: "Wines",
                column: "CataId",
                principalTable: "Cata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
