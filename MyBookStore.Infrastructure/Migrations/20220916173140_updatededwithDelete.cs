using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBookStore.Infrastructure.Migrations
{
    public partial class updatededwithDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("40cd8559-7d8c-420d-9c91-d9388a1eca96"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("9bf843c5-812f-4802-a954-e630ddec14ef"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("ad11b7fe-85b6-41da-a9e9-6c2bc4f01e98"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("d1ebe72c-dffb-4dc8-9c2f-a39f16cf9186"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("4651db58-8f51-4fbe-b899-785d9bf6c410"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("6fe4a4e2-93fc-498c-9f63-d29f8c7d219b"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("b9403eb7-fadd-4df8-b851-ac1a2398e719"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("fd0a7355-d1af-40cb-a962-e98ace78d029"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Publisher",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Book",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Author",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Created", "IsDeleted", "Name", "Updated" },
                values: new object[,]
                {
                    { new Guid("94cb215c-c1fa-4e64-8329-e056b205989c"), new DateTime(2022, 9, 16, 18, 31, 40, 106, DateTimeKind.Local).AddTicks(7859), false, "John Jake", null },
                    { new Guid("b10897b3-9922-4766-af8b-0578eb3b62dd"), new DateTime(2022, 9, 16, 18, 31, 40, 106, DateTimeKind.Local).AddTicks(7857), false, "Stephen John", null },
                    { new Guid("b7a7a273-acd3-45ce-a861-179343e88384"), new DateTime(2022, 9, 16, 18, 31, 40, 106, DateTimeKind.Local).AddTicks(7872), false, "Barry Mark", null },
                    { new Guid("ef808cbd-16ac-464a-9be3-59faaa84e411"), new DateTime(2022, 9, 16, 18, 31, 40, 106, DateTimeKind.Local).AddTicks(7860), false, "Paul Samuel", null }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Created", "IsDeleted", "Name", "Updated" },
                values: new object[,]
                {
                    { new Guid("2284e13d-f7b6-4d3e-9b68-b8e1a9fe2016"), new DateTime(2022, 9, 16, 18, 31, 40, 106, DateTimeKind.Local).AddTicks(7786), false, "HammerRio", null },
                    { new Guid("25775c65-c715-43e4-ab3a-b6f8b821e786"), new DateTime(2022, 9, 16, 18, 31, 40, 106, DateTimeKind.Local).AddTicks(7784), false, "BrianKay", null },
                    { new Guid("8b334f51-4d03-4eba-a572-bccc0cb441dd"), new DateTime(2022, 9, 16, 18, 31, 40, 106, DateTimeKind.Local).AddTicks(7729), false, "MichaelLuke", null },
                    { new Guid("e1dfbacd-94b8-4e99-8b83-fb566024d7d1"), new DateTime(2022, 9, 16, 18, 31, 40, 106, DateTimeKind.Local).AddTicks(7785), false, "NeoLake", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("94cb215c-c1fa-4e64-8329-e056b205989c"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("b10897b3-9922-4766-af8b-0578eb3b62dd"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("b7a7a273-acd3-45ce-a861-179343e88384"));

            migrationBuilder.DeleteData(
                table: "Author",
                keyColumn: "Id",
                keyValue: new Guid("ef808cbd-16ac-464a-9be3-59faaa84e411"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("2284e13d-f7b6-4d3e-9b68-b8e1a9fe2016"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("25775c65-c715-43e4-ab3a-b6f8b821e786"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("8b334f51-4d03-4eba-a572-bccc0cb441dd"));

            migrationBuilder.DeleteData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: new Guid("e1dfbacd-94b8-4e99-8b83-fb566024d7d1"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Publisher");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Author");

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
        }
    }
}
