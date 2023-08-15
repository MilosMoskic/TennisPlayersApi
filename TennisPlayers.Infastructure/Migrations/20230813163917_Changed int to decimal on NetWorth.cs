﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TennisPlayers.Infastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedinttodecimalonNetWorth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NetWorth",
                table: "Sponsors",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NetWorth",
                table: "Sponsors",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}