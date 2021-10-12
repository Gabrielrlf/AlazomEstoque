using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlazomEstoque.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadFornecedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Placa = table.Column<string>(type: "TEXT", nullable: true),
                    HorarioEntrada = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadFornecedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstoqueAbertura",
                columns: table => new
                {
                    IdAbertura = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QtdDia = table.Column<int>(type: "INTEGER", nullable: false),
                    HorarioAbertura = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueAbertura", x => x.IdAbertura);
                });

            migrationBuilder.CreateTable(
                name: "EstoqueVaga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QtdAtual = table.Column<int>(type: "INTEGER", nullable: false),
                    UltimaData = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstoqueVaga", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EstoqueVaga",
                columns: new[] { "Id", "QtdAtual", "UltimaData" },
                values: new object[] { 1, 0, new DateTime(2021, 10, 12, 14, 21, 32, 549, DateTimeKind.Local).AddTicks(934) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CadFornecedor");

            migrationBuilder.DropTable(
                name: "EstoqueAbertura");

            migrationBuilder.DropTable(
                name: "EstoqueVaga");
        }
    }
}
