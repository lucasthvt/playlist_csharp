using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaylistAppEF.Migrations
{
    /// <inheritdoc />
    public partial class AjoutLabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Chansons",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Label",
                value: "");

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 2,
                column: "Label",
                value: "");

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 3,
                column: "Label",
                value: "");

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 4,
                column: "Label",
                value: "");

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 5,
                column: "Label",
                value: "");

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 6,
                column: "Label",
                value: "");

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 7,
                column: "Label",
                value: "");

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 8,
                column: "Label",
                value: "");

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 9,
                column: "Label",
                value: "");

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 10,
                column: "Label",
                value: "");

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 11,
                column: "Label",
                value: "");

            migrationBuilder.UpdateData(
                table: "Chansons",
                keyColumn: "Id",
                keyValue: 12,
                column: "Label",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Chansons");
        }
    }
}
