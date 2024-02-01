using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFieldsInTransportAndSpedition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Transports",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Speditions",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Spedition Status: Approved, Pending, Rejected",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldComment: "Spedition Status");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afc48dd7-2c69-4333-a9cf-f1f769084f2e",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEOufS3A7urwzVQKOwbQ4q4NTKLQEk+jTl/lBavw906YE4jEJmNhN8/a0X8JjsbH7zA==", "74e1b96e-715a-40b6-b15f-030e833d1367" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Transports",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Speditions",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                comment: "Spedition Status",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Spedition Status: Approved, Pending, Rejected");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afc48dd7-2c69-4333-a9cf-f1f769084f2e",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAIAAYagAAAAEJlUR0KcrqiXuznYT+gDc6z6trbf29WowzV5tDNTVriIQ3wqpHO/WfEvjG9gFbpDjA==", "06c7dce7-7773-48b0-aea9-a8b18e4b03bb" });
        }
    }
}
