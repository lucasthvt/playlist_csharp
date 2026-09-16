using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PlaylistAppEF.Migrations
{
    /// <inheritdoc />
    public partial class AjoutArtiste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArtisteId",
                table: "Chansons",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Artistes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Pays = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreeLe = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Artistes",
                columns: new[] { "Id", "CreeLe", "Nom", "Pays" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Queen", "Royaume-Uni" },
                    { 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Eagles", "États-Unis" },
                    { 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The Weeknd", "Canada" },
                    { 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ed Sheeran", "Royaume-Uni" },
                    { 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Eminem", "États-Unis" },
                    { 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Drake", "Canada" },
                    { 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Nirvana", "États-Unis" },
                    { 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Adele", "Royaume-Uni" },
                    { 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Michael Jackson", "États-Unis" },
                    { 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Daft Punk", "France" },
                    { 11, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bee Gees", "Royaume-Uni" }
                });

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArtisteId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArtisteId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArtisteId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArtisteId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArtisteId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArtisteId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArtisteId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 8,
                column: "ArtisteId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 9,
                column: "ArtisteId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 10,
                column: "ArtisteId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 11,
                column: "ArtisteId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 12,
                column: "ArtisteId",
                value: 11);

            migrationBuilder.CreateIndex(
                name: "IX_Chansons_ArtisteId",
                table: "Chansons",
                column: "ArtisteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chansons_Artistes_ArtisteId",
                table: "Chansons",
                column: "ArtisteId",
                principalTable: "Artistes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chansons_Artistes_ArtisteId",
                table: "Chansons");

            migrationBuilder.DropTable(
                name: "Artistes");

            migrationBuilder.DropIndex(
                name: "IX_Chansons_ArtisteId",
                table: "Chansons");

            migrationBuilder.DropColumn(
                name: "ArtisteId",
                table: "Chansons");
        }
    }
}
