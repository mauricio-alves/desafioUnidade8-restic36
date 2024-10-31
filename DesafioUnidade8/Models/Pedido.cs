using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioUnidade8.Models;
public class Pedido
{
    [Key]
    public int Id_Pedido { get; set; }
    public required string Status { get; set; }
    public int Cliente_Id_Cliente  { get; set; }

    [ForeignKey("Cliente_Id_Cliente")]
    public required Cliente Cliente { get; set; }
        
    // Relacionamento com Pedido_tem_Produto
    public required ICollection<Pedido_tem_Produto> PedidoTemProdutos { get; set; }
}