using System.ComponentModel.DataAnnotations.Schema;

namespace TesteDapper.Fonte.DTO
{
    [Table("detalhevendas")]
    public class dtoDetalheVenda
    {
        public int numero { get; set; }
        public string descricao { get; set; }
        public float preco { get; set; }
        public float quantidade { get; set; }
    }
}
