using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_Cliente_Id_Cliente",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoTemProdutos_Pedidos_Pedido_Id_Pedido",
                table: "PedidoTemProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoTemProdutos_Produtos_Produto_Id_Produto",
                table: "PedidoTemProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoTemProdutos",
                table: "PedidoTemProdutos");

            migrationBuilder.RenameColumn(
                name: "Produto_Id_Produto",
                table: "PedidoTemProdutos",
                newName: "Id_Produto");

            migrationBuilder.RenameColumn(
                name: "Pedido_Id_Pedido",
                table: "PedidoTemProdutos",
                newName: "Id_Pedido");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoTemProdutos_Produto_Id_Produto",
                table: "PedidoTemProdutos",
                newName: "IX_PedidoTemProdutos_Id_Produto");

            migrationBuilder.RenameColumn(
                name: "Cliente_Id_Cliente",
                table: "Pedidos",
                newName: "Id_Cliente");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_Cliente_Id_Cliente",
                table: "Pedidos",
                newName: "IX_Pedidos_Id_Cliente");

            migrationBuilder.AddColumn<int>(
                name: "Id_PedidoProduto",
                table: "PedidoTemProdutos",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoTemProdutos",
                table: "PedidoTemProdutos",
                column: "Id_PedidoProduto");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoTemProdutos_Id_Pedido",
                table: "PedidoTemProdutos",
                column: "Id_Pedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_Id_Cliente",
                table: "Pedidos",
                column: "Id_Cliente",
                principalTable: "Clientes",
                principalColumn: "Id_Cliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoTemProdutos_Pedidos_Id_Pedido",
                table: "PedidoTemProdutos",
                column: "Id_Pedido",
                principalTable: "Pedidos",
                principalColumn: "Id_Pedido",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoTemProdutos_Produtos_Id_Produto",
                table: "PedidoTemProdutos",
                column: "Id_Produto",
                principalTable: "Produtos",
                principalColumn: "Id_Produto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Clientes_Id_Cliente",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoTemProdutos_Pedidos_Id_Pedido",
                table: "PedidoTemProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoTemProdutos_Produtos_Id_Produto",
                table: "PedidoTemProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoTemProdutos",
                table: "PedidoTemProdutos");

            migrationBuilder.DropIndex(
                name: "IX_PedidoTemProdutos_Id_Pedido",
                table: "PedidoTemProdutos");

            migrationBuilder.DropColumn(
                name: "Id_PedidoProduto",
                table: "PedidoTemProdutos");

            migrationBuilder.RenameColumn(
                name: "Id_Produto",
                table: "PedidoTemProdutos",
                newName: "Produto_Id_Produto");

            migrationBuilder.RenameColumn(
                name: "Id_Pedido",
                table: "PedidoTemProdutos",
                newName: "Pedido_Id_Pedido");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoTemProdutos_Id_Produto",
                table: "PedidoTemProdutos",
                newName: "IX_PedidoTemProdutos_Produto_Id_Produto");

            migrationBuilder.RenameColumn(
                name: "Id_Cliente",
                table: "Pedidos",
                newName: "Cliente_Id_Cliente");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_Id_Cliente",
                table: "Pedidos",
                newName: "IX_Pedidos_Cliente_Id_Cliente");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoTemProdutos",
                table: "PedidoTemProdutos",
                column: "Pedido_Id_Pedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Clientes_Cliente_Id_Cliente",
                table: "Pedidos",
                column: "Cliente_Id_Cliente",
                principalTable: "Clientes",
                principalColumn: "Id_Cliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoTemProdutos_Pedidos_Pedido_Id_Pedido",
                table: "PedidoTemProdutos",
                column: "Pedido_Id_Pedido",
                principalTable: "Pedidos",
                principalColumn: "Id_Pedido",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoTemProdutos_Produtos_Produto_Id_Produto",
                table: "PedidoTemProdutos",
                column: "Produto_Id_Produto",
                principalTable: "Produtos",
                principalColumn: "Id_Produto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
