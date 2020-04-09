using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcaiApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adicional",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TempoPreparo = table.Column<int>(nullable: false),
                    ValorAdicional = table.Column<decimal>(type: "decimal(5,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adicional", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cliente = table.Column<string>(maxLength: 30, nullable: false),
                    Tamanho = table.Column<int>(nullable: false),
                    Sabores = table.Column<int>(nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(5,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido_Adicional",
                columns: table => new
                {
                    IdPedido = table.Column<long>(nullable: false),
                    IdAdicional = table.Column<int>(nullable: false),
                    PedidoId = table.Column<long>(nullable: true),
                    AdicionalId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido_Adicional", x => new { x.IdAdicional, x.IdPedido });
                    table.ForeignKey(
                        name: "FK_Pedido_Adicional_Adicional_AdicionalId",
                        column: x => x.AdicionalId,
                        principalTable: "Adicional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Adicional_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Adicional_AdicionalId",
                table: "Pedido_Adicional",
                column: "AdicionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Adicional_PedidoId",
                table: "Pedido_Adicional",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido_Adicional");

            migrationBuilder.DropTable(
                name: "Adicional");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
