using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlazomEstoque.Infra.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EstoqueVaga",
                keyColumn: "Id",
                keyValue: 1,
                column: "UltimaData",
                value: new DateTime(2021, 10, 12, 14, 23, 18, 398, DateTimeKind.Local).AddTicks(7783));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EstoqueVaga",
                keyColumn: "Id",
                keyValue: 1,
                column: "UltimaData",
                value: new DateTime(2021, 10, 12, 14, 21, 32, 549, DateTimeKind.Local).AddTicks(934));
        }
    }
}
