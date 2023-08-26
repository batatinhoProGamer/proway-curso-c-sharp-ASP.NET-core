using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojaRepositorios.Migrations
{
    public partial class CreateClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "VARCHAR(14)", maxLength: 14, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    Estado = table.Column<string>(type: "CHAR(2)", fixedLength: true, maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Bairro = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Cep = table.Column<string>(type: "CHAR(10)", fixedLength: true, maxLength: 10, nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: false),
                    Complemento = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cpf", "DataNascimento", "Nome", "Bairro", "Cep", "Cidade", "Complemento", "Estado", "Logradouro", "Numero" },
                values: new object[] { 2, "123.456.789-00", new DateTime(1990, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pedro da Silva", "Badenfurt", "89070-250", "Blumenau", "Sem complemento", "SC", "Rua dos Pedra", "200" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
