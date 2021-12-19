using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgenciaDeViagensRecodePro.Migrations
{
    public partial class Contato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    CPF = table.Column<string>(unicode: false, fixedLength: true, maxLength: 11, nullable: true),
                    Telefone = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cliente__D59466421B693E39", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    IdContato = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Mensagem = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.IdContato);
                });

            migrationBuilder.CreateTable(
                name: "Hospedagem",
                columns: table => new
                {
                    IdHospedagem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Endereco = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Telefone = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Diarias = table.Column<int>(nullable: true),
                    ValorDiaria = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Hospedag__AAF786D5B01D56DB", x => x.IdHospedagem);
                });

            migrationBuilder.CreateTable(
                name: "Passagem",
                columns: table => new
                {
                    IdPassagem = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPartida = table.Column<DateTime>(type: "datetime", nullable: true),
                    DataChegada = table.Column<DateTime>(type: "datetime", nullable: true),
                    LocalPartida = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    LocalChegada = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Valor = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Passagem__9509808BB723CE3A", x => x.IdPassagem);
                });

            migrationBuilder.CreateTable(
                name: "Pacote",
                columns: table => new
                {
                    IdPacote = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    fk_Cliente_IdCliente = table.Column<int>(nullable: true),
                    fk_Passagem_IdPassagem = table.Column<int>(nullable: true),
                    fk_Hospedagem_IdHospedagem = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pacote__40CE6F9C81CBDAD2", x => x.IdPacote);
                    table.ForeignKey(
                        name: "FK_Pacote_2",
                        column: x => x.fk_Cliente_IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacote_4",
                        column: x => x.fk_Hospedagem_IdHospedagem,
                        principalTable: "Hospedagem",
                        principalColumn: "IdHospedagem",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pacote_3",
                        column: x => x.fk_Passagem_IdPassagem,
                        principalTable: "Passagem",
                        principalColumn: "IdPassagem",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Cliente__C1F89731B42930D4",
                table: "Cliente",
                column: "CPF",
                unique: true,
                filter: "[CPF] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pacote_fk_Cliente_IdCliente",
                table: "Pacote",
                column: "fk_Cliente_IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pacote_fk_Hospedagem_IdHospedagem",
                table: "Pacote",
                column: "fk_Hospedagem_IdHospedagem");

            migrationBuilder.CreateIndex(
                name: "IX_Pacote_fk_Passagem_IdPassagem",
                table: "Pacote",
                column: "fk_Passagem_IdPassagem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "Pacote");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Hospedagem");

            migrationBuilder.DropTable(
                name: "Passagem");
        }
    }
}
