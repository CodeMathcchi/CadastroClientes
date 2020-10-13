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
                    Rua = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Bairro", "Cep", "Cidade", "Complemento", "DataNascimento", "Estado", "Nome", "Numero", "Rua", "Sexo" },
                values: new object[,]
                {
                    { 1L, "Muggles", "95055-268", "Maringá", "", new DateTime(1995, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR", "Matheus Gomes Roberto dos Santos", "4", "Rua Alfeiros", "Maculino" },
                    { 2L, "Muggles", "95055-268", "Maringá", "", new DateTime(1999, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR", "Lucas Souza de Gois", "4", "Rua Alfeiros", "Maculino" },
                    { 3L, "Gopauva", "823489-025", "São Paulo", "", new DateTime(1941, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "SP", "Bethy da Silva", "257", "Alameda Yaya", "Feminino" },
                    { 4L, "Fim do Universo", "78964-568", "Maringá", "Apt. 1101", new DateTime(1996, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "PR", "Lívia Peron Bernardo", "42", "Rua da Toalha", "Feminino" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
