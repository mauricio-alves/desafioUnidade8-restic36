using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioUnidade8.Models
{
    public class Pedido_tem_Produto
    {
      [Key]
        public int Pedido_Id_Pedido { get; set; }
        
        public int Produto_Id_Produto { get; set; }
        
        public int? Quantidade { get; set; }

        [ForeignKey("Pedido_Id_Pedido")]
        public required Pedido Pedido { get; set; }
        
        [ForeignKey("Produto_Id_Produto")]
        public required Produto Produto { get; set; }
    }
}