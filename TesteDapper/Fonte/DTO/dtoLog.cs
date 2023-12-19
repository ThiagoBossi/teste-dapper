using System.ComponentModel;

namespace TesteDapper.Fonte.DTO
{
    public class dtoLog
    {
        [Description("codigo")]
        public int codigoLog { get; set; }

        [Description("data")]
        public string dataLog { get; set; }

        [Description("formulario")]
        public string formularioLog { get; set; }

        [Description("historico")]
        public string historicoLog { get; set; }

        [Description("usuario")]
        public string usuarioLog { get; set; }

        [Description("estacao")]
        public string estacaoLog { get; set; }
    }
}
