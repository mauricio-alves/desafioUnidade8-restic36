using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public class Pedido_tem_Produto
    {
      [Key]
        public int Id_PedidoProduto { get; set; }

        public int Id_Pedido { get; set; }

        // Relacionamento um-para-muitos com Pedido
        [ForeignKey("Id_Pedido"), JsonIgnore]
        public Pedido? Pedido { get; set; }
        
        public int Id_Produto { get; set; }

        // Relacionamento um-para-muitos com Produto
        [ForeignKey("Id_Produto"), JsonIgnore]
        public Produto? Produto { get; set; }

        public int Quantidade { get; set; }
    }
}