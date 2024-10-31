using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;
public class Produto
{
    [Key]
    public int Id_Produto { get; set; }
    public string? Nome { get; set; }
    public string? Tipo { get; set; }
    public decimal Valor { get; set; }

    // Relacionamento muitos-para-muitos com Pedido_tem_Produto
    public ICollection<Pedido_tem_Produto> PedidoTemProdutos { get; set; } = new List<Pedido_tem_Produto>();
}