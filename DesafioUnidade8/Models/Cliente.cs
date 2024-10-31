using System.ComponentModel.DataAnnotations;

namespace DesafioUnidade8.Models;
public class Cliente
{
    [Key]
    public int Id_Cliente { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Numero_Contato { get; set; }
    public DateTime Data_Nascimento { get; set; }

    // Relacionamento com Pedido
    public required ICollection<Pedido> Pedidos { get; set; }
}