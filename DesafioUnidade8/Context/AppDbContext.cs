using WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Context
{
    public class AppDbContext : DbContext // Define o contexto do banco de dados
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; } // Define a tabela Clientes
        public DbSet<Produto> Produtos { get; set; } // Define a tabela Produtos
        public DbSet<Pedido> Pedidos { get; set; } // Define a tabela Pedidos
        public DbSet<Pedido_tem_Produto> PedidoTemProdutos { get; set; } // Define a tabela Pedido_tem_Produto
    }
}