using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkClip.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Browsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Family = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Major = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Minor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Browsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsBot = table.Column<bool>(type: "bit", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Family = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkShorteners",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Token = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkShorteners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Family = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Major = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Minor = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestUrls",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkShortenerId = table.Column<long>(type: "bigint", nullable: false),
                    RequestDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestUrls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestUrls_LinkShorteners_LinkShortenerId",
                        column: x => x.LinkShortenerId,
                        principalTable: "LinkShorteners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestUrls_LinkShortenerId",
                table: "RequestUrls",
                column: "LinkShortenerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Browsers");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "OS");

            migrationBuilder.DropTable(
                name: "RequestUrls");

            migrationBuilder.DropTable(
                name: "LinkShorteners");
        }
    }
}
