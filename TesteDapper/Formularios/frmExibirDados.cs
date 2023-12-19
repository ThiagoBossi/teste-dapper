using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TesteDapper.Formularios
{
    public partial class frmExibirDados : Form
    {
        #region Variáveis do Formulário
        private List<object> listaObjetos { get; set; }
        public static object objetoRetorno { get; set; }
        #endregion

        #region Construtor do Formulário
        public frmExibirDados(IEnumerable<object> _listaObjetos)
        {
            InitializeComponent();
            listaObjetos = _listaObjetos.ToList();
        }
        #endregion

        #region Eventos do Formulário
        private void frmExibirDados_Load(object sender, EventArgs e)
        {
            listaDados.DataSource = listaObjetos;
        }

        private void listaDados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var objetoClicado = (object)listaDados.Rows[e.RowIndex].DataBoundItem;
                objetoRetorno = objetoClicado;

                DialogResult = DialogResult.OK;

                Close();
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
        #endregion
    }
}
