using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentTime",
                table: "Transports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Transports",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentTime",
                table: "Speditions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Current time");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Speditions",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Spedition Status");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afc48dd7-2c69-4333-a9cf-f1f769084f2e",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEJlUR0KcrqiXuznYT+gDc6z6trbf29WowzV5tDNTVriIQ3wqpHO/WfEvjG9gFbpDjA==", "06c7dce7-7773-48b0-aea9-a8b18e4b03bb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentTime",
                table: "Transports");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Transports");

            migrationBuilder.DropColumn(
                name: "CurrentTime",
                table: "Speditions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Speditions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afc48dd7-2c69-4333-a9cf-f1f769084f2e",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEHosjPXiYhPROF3mdbMjmVVUul3cErvWtwo4kyGueJo/9I2l4c359rrSZ/blxFo+Zw==", "42760322-e385-4c91-af4c-b2d2ae443290" });
        }
    }
}
