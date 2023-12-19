using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDapper.Fonte.DTO
{
    [Table("fornecedor")]
    public class dtoFornecedor
    {
        public int codigo { get; set; }
        public string razaosocial { get; set; }
        public string cnpj { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }

        public dtoEndereco endereco { get; set; }
    }
}
