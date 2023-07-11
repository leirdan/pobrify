using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pobrify.Migrations
{
    public partial class GenreYearOnAlbum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Albums",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Albums",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Albums");
        }
    }
}
