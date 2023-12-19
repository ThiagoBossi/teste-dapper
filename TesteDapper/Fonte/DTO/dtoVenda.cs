using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDapper.Fonte.DTO
{
    [Table("vendas")]
    public class dtoVenda
    {
        [Key]
        public int numero { get; set; }
        public int codigocliente { get; set; }
        public float totalgeral { get; set; }

        public List<dtoDetalheVenda> itens { get; set; }
    }
}
