using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class FeedRolesAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "98620bae-4e03-493a-80f7-adf53c08b3f8", "c20198be-88e7-48e8-a58f-920717c23954", "Client", "CLIENT" },
                    { "caa85a15-7f5c-43a0-9af4-8b64844c201d", "ac1b96c0-a4dd-47d2-ac7e-9a8cb53430fc", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "Type", "UserName" },
                values: new object[] { "afc48dd7-2c69-4333-a9cf-f1f769084f2e", 0, "e821c43e-236a-4615-a454-7af10dd382e3", "alex.ivanov@algona.ltd", false, "Alex", false, "Ivanov", false, null, "ALEX.IVANOV@ALGONA.LTD", "ALEX.IVANOV@ALGONA.LTD", "AQAAAAIAAYagAAAAELiwcW7/RuK/vQGNOL32lh7eCqdbaKUwysfD33YIg6ymcPubwN4bVL4kiIh5l0+FQg==", null, false, "d1062b93-9d07-42d9-9c56-f096968eb9fb", false, 0, "alex.ivanov@algona.ltd" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "caa85a15-7f5c-43a0-9af4-8b64844c201d", "afc48dd7-2c69-4333-a9cf-f1f769084f2e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98620bae-4e03-493a-80f7-adf53c08b3f8");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "caa85a15-7f5c-43a0-9af4-8b64844c201d", "afc48dd7-2c69-4333-a9cf-f1f769084f2e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caa85a15-7f5c-43a0-9af4-8b64844c201d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "afc48dd7-2c69-4333-a9cf-f1f769084f2e");
        }
    }
}
