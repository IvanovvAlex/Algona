using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResetPasswordToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetPasswordTokenExpiration",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afc48dd7-2c69-4333-a9cf-f1f769084f2e",
                columns: new[] { "PasswordHash", "ResetPasswordToken", "ResetPasswordTokenExpiration", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEHosjPXiYhPROF3mdbMjmVVUul3cErvWtwo4kyGueJo/9I2l4c359rrSZ/blxFo+Zw==", null, null, "42760322-e385-4c91-af4c-b2d2ae443290" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResetPasswordToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ResetPasswordTokenExpiration",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afc48dd7-2c69-4333-a9cf-f1f769084f2e",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAELiwcW7/RuK/vQGNOL32lh7eCqdbaKUwysfD33YIg6ymcPubwN4bVL4kiIh5l0+FQg==", "d1062b93-9d07-42d9-9c56-f096968eb9fb" });
        }
    }
}
