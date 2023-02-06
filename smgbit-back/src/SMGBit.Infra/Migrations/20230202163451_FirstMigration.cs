using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMGBit.Infra.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataViagem = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumeroViagem = table.Column<int>(type: "int", nullable: false),
                    Motorista = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Placa = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    TipoVeiculo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Origem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaixasCarregagas = table.Column<int>(type: "int", nullable: false),
                    Entregas = table.Column<int>(type: "int", nullable: false),
                    KmRodados = table.Column<int>(type: "int", nullable: false),
                    TipoViagem = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    TabelaFrete = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ValorViagem = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Travels");
        }
    }
}
