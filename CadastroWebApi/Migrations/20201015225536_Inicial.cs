using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace CadastroWebApi.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Uf = table.Column<string>(nullable: true),
                    Localidade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Bairro", "Cep", "Complemento", "DataNascimento", "Localidade", "Logradouro", "Nome", "Numero", "Sexo", "Uf" },
                values: new object[,]
                {
                    { 1L, "Muggles", "95055-268", "", new DateTime(1995, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maringá", "Rua Alfeiros", "Matheus Gomes Roberto dos Santos", "4", "Masculino", "PR" },
                    { 2L, "Muggles", "95055-268", "", new DateTime(1999, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maringá", "Rua Alfeiros", "Lucas Souza de Gois", "4", "Masculino", "PR" },
                    { 3L, "Gopauva", "823489-025", "", new DateTime(1941, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "São Paulo", "Alameda Yaya", "Bethy da Silva", "257", "Feminino", "SP" },
                    { 4L, "Fim do Universo", "78964-568", "Apt. 1101", new DateTime(1996, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maringá", "Rua da Toalha", "Lívia Bernardo", "42", "Feminino", "PR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
