using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduAPI.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedTotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Materials_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "int", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "CreatedTotal", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Co-founder of the prestigious \"Women in IT\" summit.", "Priscillia Chang" },
                    { 2, 1, "A known Udemy coach.", "Alex Green" },
                    { 3, 1, "Programming course provider.", "Get Coding Inc." },
                    { 4, 1, "Local API guru.", "Anne X" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Definition", "Name" },
                values: new object[,]
                {
                    { 1, "A short video detailing how to implement a specific feature.", "Video tutorial" },
                    { 2, "A text form explaining the issue.", "Article" },
                    { 3, "An in-depth form, covering a large portion of material.", "Online course" },
                    { 4, "An analogue predecessor of big online courses.", "Book" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "AuthorId", "Description", "Location", "PublishedAt", "Title", "TypeId" },
                values: new object[,]
                {
                    { 1, 2, "For baby ASP .NET programmers", "udemy.com", new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Build an ASP .NET MVC app", 3 },
                    { 2, 1, "A useful set of tips.", "getstarted.com/article.html", new DateTime(2022, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Get started in IT", 2 },
                    { 3, 4, "An exhaustive guide for beginner and moderately-skilled programmers.", "Rajska library", new DateTime(2020, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Everything you need to know about APIs", 4 },
                    { 4, 3, "Build your first database in EF Core", "getcoding.com/efcore", new DateTime(2022, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "My first DB", 1 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Contents", "MaterialId", "Points" },
                values: new object[,]
                {
                    { 1, "Not really that useful", 2, 3 },
                    { 2, "I didn't even get any errors!", 3, 10 },
                    { 3, "Could be more clear", 1, 7 },
                    { 4, "Decent", 4, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materials_AuthorId",
                table: "Materials",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_TypeId",
                table: "Materials",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MaterialId",
                table: "Reviews",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
