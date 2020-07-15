using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TooSeguros.Infra.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContaCorrente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoBanco = table.Column<string>(maxLength: 5, nullable: false),
                    Banco = table.Column<string>(maxLength: 45, nullable: false),
                    Agencia = table.Column<string>(maxLength: 20, nullable: false),
                    DigitoAgencia = table.Column<string>(maxLength: 5, nullable: false),
                    Conta = table.Column<string>(maxLength: 20, nullable: false),
                    DigitoConta = table.Column<string>(maxLength: 5, nullable: false),
                    TipoContaBancaria = table.Column<byte>(nullable: true),
                    Saldo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContaCorrente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lancamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaCorrenteId = table.Column<int>(nullable: false),
                    TipoTransacao = table.Column<byte>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lancamento_ContaCorrente_ContaCorrenteId",
                        column: x => x.ContaCorrenteId,
                        principalTable: "ContaCorrente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lancamento_ContaCorrenteId",
                table: "Lancamento",
                column: "ContaCorrenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lancamento");

            migrationBuilder.DropTable(
                name: "ContaCorrente");
        }
    }
}
