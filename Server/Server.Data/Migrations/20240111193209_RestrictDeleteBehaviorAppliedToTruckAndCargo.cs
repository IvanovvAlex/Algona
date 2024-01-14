using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class RestrictDeleteBehaviorAppliedToTruckAndCargo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cargoes_Trucks_TruckId",
                table: "Cargoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_Cargoes_CargoId",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_Trucks_CargoId",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_Cargoes_TruckId",
                table: "Cargoes");

            migrationBuilder.AlterColumn<int>(
                name: "TotalWeight",
                table: "RequestSpeditions",
                type: "int",
                nullable: false,
                comment: "Total weight",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ToDate",
                table: "RequestSpeditions",
                type: "datetime2",
                nullable: false,
                comment: "To date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "ToAddress",
                table: "RequestSpeditions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "To address",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "RequestSpeditions",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Phone number",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfPallets",
                table: "RequestSpeditions",
                type: "int",
                nullable: false,
                comment: "Number of pallets",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RequestSpeditions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Name",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FromDate",
                table: "RequestSpeditions",
                type: "datetime2",
                nullable: false,
                comment: "From date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "FromAddress",
                table: "RequestSpeditions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "From address",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "RequestSpeditions",
                type: "nvarchar(max)",
                nullable: false,
                comment: "Email address",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "RequestSpeditions",
                type: "nvarchar(450)",
                nullable: false,
                comment: "Spedition id",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TruckId",
                table: "Cargoes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_CargoId",
                table: "Trucks",
                column: "CargoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_Cargoes_CargoId",
                table: "Trucks",
                column: "CargoId",
                principalTable: "Cargoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_Cargoes_CargoId",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_Trucks_CargoId",
                table: "Trucks");

            migrationBuilder.AlterColumn<int>(
                name: "TotalWeight",
                table: "RequestSpeditions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Total weight");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ToDate",
                table: "RequestSpeditions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "To date");

            migrationBuilder.AlterColumn<string>(
                name: "ToAddress",
                table: "RequestSpeditions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "To address");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "RequestSpeditions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Phone number");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfPallets",
                table: "RequestSpeditions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Number of pallets");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "RequestSpeditions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FromDate",
                table: "RequestSpeditions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "From date");

            migrationBuilder.AlterColumn<string>(
                name: "FromAddress",
                table: "RequestSpeditions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "From address");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "RequestSpeditions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Email address");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "RequestSpeditions",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "Spedition id");

            migrationBuilder.AlterColumn<string>(
                name: "TruckId",
                table: "Cargoes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_CargoId",
                table: "Trucks",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cargoes_TruckId",
                table: "Cargoes",
                column: "TruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cargoes_Trucks_TruckId",
                table: "Cargoes",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_Cargoes_CargoId",
                table: "Trucks",
                column: "CargoId",
                principalTable: "Cargoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
