namespace DesafioUnidade8.Models;
public class Pedido
{
    public int PedidoId { get; set; }
    public required string Status { get; set; }
    public int IdCliente { get; set; }
}