using System.ComponentModel.DataAnnotations;

namespace DesafioUnidade8.Models;
public class Produto
{
    [Key]
    public int Id_Produto { get; set; }
    public string? Nome { get; set; }
    public string? Tipo { get; set; }
    public decimal Valor { get; set; }

    // Relacionamento com Pedido_tem_Produto
    // public required ICollection<Pedido_tem_Produto> PedidoTemProdutos { get; set; }
}