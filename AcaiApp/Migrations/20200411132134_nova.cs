using Microsoft.EntityFrameworkCore.Migrations;

namespace AcaiApp.Migrations
{
    public partial class nova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedido_Adicional",
                table: "Pedido_Adicional");

            migrationBuilder.DropColumn(
                name: "IdPedido",
                table: "Pedido_Adicional");

            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Pedido");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Pedido_Adicional",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Adicional",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PedidoId",
                table: "Adicional",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedido_Adicional",
                table: "Pedido_Adicional",
                columns: new[] { "IdAdicional", "Id" });

            migrationBuilder.CreateIndex(
                name: "IX_Adicional_PedidoId",
                table: "Adicional",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adicional_Pedido_PedidoId",
                table: "Adicional",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adicional_Pedido_PedidoId",
                table: "Adicional");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedido_Adicional",
                table: "Pedido_Adicional");

            migrationBuilder.DropIndex(
                name: "IX_Adicional_PedidoId",
                table: "Adicional");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Pedido_Adicional");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Adicional");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Adicional");

            migrationBuilder.AddColumn<long>(
                name: "IdPedido",
                table: "Pedido_Adicional",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Pedido",
                type: "varchar(30) CHARACTER SET utf8mb4",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedido_Adicional",
                table: "Pedido_Adicional",
                columns: new[] { "IdAdicional", "IdPedido" });
        }
    }
}
