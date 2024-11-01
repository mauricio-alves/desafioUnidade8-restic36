using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models;
public class Produto
{
    [Key]
    public int Id_Produto { get; set; }
    public string? Nome { get; set; }
    public string? Tipo { get; set; }
    public decimal Valor { get; set; }
}