using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Echoes.Data.Migrations
{
    public partial class mapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "State",
                maxLength: 30,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "State",
                maxLength: 2,
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_State_Code",
                table: "State",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_State_Name",
                table: "State",
                column: "Name",
                unique: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "City",
                maxLength: 30,
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId_Name",
                table: "City",
                columns: new[] { "StateId", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_State_Code",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_State_Name",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_City_StateId_Name",
                table: "City");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "State",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "State",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "City",
                nullable: true);
        }
    }
}
