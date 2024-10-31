using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;
public class Cliente
{
    [Key]
    public int Id_Cliente { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Numero_Contato { get; set; }
    public DateTime Data_Nascimento { get; set; }

    // Relacionamento um-para-muitos com Pedido
    public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}