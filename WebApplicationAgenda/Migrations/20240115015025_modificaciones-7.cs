﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplicationAgenda.Migrations
{
    public partial class modificaciones7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Calls",
                columns: new[] { "Id", "ContactId", "CountCall", "TimeCall" },
                values: new object[] { 2, 2, 2, new DateTime(2024, 1, 14, 21, 50, 24, 843, DateTimeKind.Local).AddTicks(3455) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Calls",
                columns: new[] { "Id", "ContactId", "CountCall", "TimeCall" },
                values: new object[] { 1, 1, 2, new DateTime(2024, 1, 14, 21, 41, 15, 788, DateTimeKind.Local).AddTicks(6730) });
        }
    }
}