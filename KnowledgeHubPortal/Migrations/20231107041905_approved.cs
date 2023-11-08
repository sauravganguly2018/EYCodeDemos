﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowledgeHubPortal.Migrations
{
    /// <inheritdoc />
    public partial class approved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Articles");
        }
    }
}
