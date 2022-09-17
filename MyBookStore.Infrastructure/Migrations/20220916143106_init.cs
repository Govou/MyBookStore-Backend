using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBookStore.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Edition = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { new Guid("40cd8559-7d8c-420d-9c91-d9388a1eca96"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stephen John", null },
                    { new Guid("9bf843c5-812f-4802-a954-e630ddec14ef"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Jake", null },
                    { new Guid("ad11b7fe-85b6-41da-a9e9-6c2bc4f01e98"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paul Samuel", null },
                    { new Guid("d1ebe72c-dffb-4dc8-9c2f-a39f16cf9186"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barry Mark", null }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { new Guid("4651db58-8f51-4fbe-b899-785d9bf6c410"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MichaelLuke", null },
                    { new Guid("6fe4a4e2-93fc-498c-9f63-d29f8c7d219b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "NeoLake", null },
                    { new Guid("b9403eb7-fadd-4df8-b851-ac1a2398e719"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BrianKay", null },
                    { new Guid("fd0a7355-d1af-40cb-a962-e98ace78d029"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "HammerRio", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherId",
                table: "Book",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
