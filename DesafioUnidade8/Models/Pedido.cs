using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models;
public class Pedido
{
    [Key]
    public int Id_Pedido { get; set; }
    public required string Status { get; set; }

    // Relacionamento muitos-para-um com Cliente
    [ForeignKey("Id_Cliente"), JsonIgnore]
    public int Id_Cliente  { get; set; }
    public Cliente? Cliente { get; set; }
        
    // Relacionamento muitos-para-muitos com Pedido_tem_Produto
    public ICollection<Pedido_tem_Produto> PedidoTemProdutos { get; set; } = new List<Pedido_tem_Produto>();
}