using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class Pedido_tem_Produto
    {
      [Key]
        public int Id_Pedido { get; set; }

        [ForeignKey("Id_Pedido")]
        public required Pedido Pedido { get; set; }
        
        public int Id_Produto { get; set; }
                
        [ForeignKey("Id_Produto")]
        public required Produto Produto { get; set; }

    
        public int Quantidade { get; set; }
    }
}