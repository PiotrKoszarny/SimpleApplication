using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleApp.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "Mileage", "Model", "ProductionDate" },
                values: new object[,]
                {
                    { 1, "Volkswagen", 193847.0, "Golf", new DateTime(2018, 1, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, "Volkswagen", 120280.0, "Passat", new DateTime(2015, 2, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, "Volkswagen", 182656.0, "Polo", new DateTime(2018, 5, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, "Volkswagen", 140305.0, "Bora", new DateTime(2017, 10, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, "Opel", 63743.0, "Astra", new DateTime(2018, 4, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, "Opel", 47614.0, "Vectra", new DateTime(2017, 4, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, "Opel", 42797.0, "Corsa", new DateTime(2014, 10, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, "Audi", 102375.0, "A3", new DateTime(2011, 9, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 9, "Audi", 139240.0, "A5", new DateTime(2013, 11, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 10, "Audi", 33801.0, "A7", new DateTime(2012, 1, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 11, "Audi", 152262.0, "Q3", new DateTime(2011, 12, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 12, "Audi", 134284.0, "Q5", new DateTime(2017, 8, 25, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 13, "Audi", 145215.0, "Q7", new DateTime(2018, 11, 25, 0, 0, 0, 0, DateTimeKind.Local) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
