using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDapper.Fonte.DTO
{
    [Table("clientes")]
    public class dtoCliente
    {
        [Key]
        public int codigo { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string celular { get; set; }

        public List<dtoVenda> vendas { get; set; }
    }
}
