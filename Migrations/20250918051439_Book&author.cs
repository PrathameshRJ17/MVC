using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_core_empty_controler__Day_3_.Migrations
{
    /// <inheritdoc />
    public partial class Bookauthor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    authid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "11, 1"),
                    authname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.authid);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    bookid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Publicationyear = table.Column<DateOnly>(type: "date", nullable: false),
                    authid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.bookid);
                    table.ForeignKey(
                        name: "FK_Books_Authors_authid",
                        column: x => x.authid,
                        principalTable: "Authors",
                        principalColumn: "authid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "authid", "authname" },
                values: new object[,]
                {
                    { 11, "Prathamesh" },
                    { 12, "Anna" },
                    { 13, "shetty" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "bookid", "Publicationyear", "authid", "price", "title" },
                values: new object[,]
                {
                    { 1, new DateOnly(2025, 5, 6), 11, 999m, "swarg" },
                    { 2, new DateOnly(2020, 4, 4), 12, 500m, "shap" },
                    { 3, new DateOnly(2020, 5, 7), 13, 150m, "jhatu" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_authid",
                table: "Books",
                column: "authid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
