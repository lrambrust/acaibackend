using Microsoft.EntityFrameworkCore.Migrations;

namespace AcaiApp.Migrations
{
    public partial class correcaoCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Adicional_Adicional_AdicionalId",
                table: "Pedido_Adicional");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_Adicional_AdicionalId",
                table: "Pedido_Adicional");

            migrationBuilder.DropColumn(
                name: "AdicionalId",
                table: "Pedido_Adicional");

            migrationBuilder.AlterColumn<long>(
                name: "IdAdicional",
                table: "Pedido_Adicional",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "PedidoAdicionalId",
                table: "Adicional",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PedidoAdicionalIdAdicional",
                table: "Adicional",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Adicional_PedidoAdicionalIdAdicional_PedidoAdicionalId",
                table: "Adicional",
                columns: new[] { "PedidoAdicionalIdAdicional", "PedidoAdicionalId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Adicional_Pedido_Adicional_PedidoAdicionalIdAdicional_Pedido~",
                table: "Adicional",
                columns: new[] { "PedidoAdicionalIdAdicional", "PedidoAdicionalId" },
                principalTable: "Pedido_Adicional",
                principalColumns: new[] { "IdAdicional", "Id" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adicional_Pedido_Adicional_PedidoAdicionalIdAdicional_Pedido~",
                table: "Adicional");

            migrationBuilder.DropIndex(
                name: "IX_Adicional_PedidoAdicionalIdAdicional_PedidoAdicionalId",
                table: "Adicional");

            migrationBuilder.DropColumn(
                name: "PedidoAdicionalId",
                table: "Adicional");

            migrationBuilder.DropColumn(
                name: "PedidoAdicionalIdAdicional",
                table: "Adicional");

            migrationBuilder.AlterColumn<int>(
                name: "IdAdicional",
                table: "Pedido_Adicional",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "AdicionalId",
                table: "Pedido_Adicional",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Adicional_AdicionalId",
                table: "Pedido_Adicional",
                column: "AdicionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Adicional_Adicional_AdicionalId",
                table: "Pedido_Adicional",
                column: "AdicionalId",
                principalTable: "Adicional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
