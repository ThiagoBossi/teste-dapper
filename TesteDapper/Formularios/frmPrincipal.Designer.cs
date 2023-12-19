namespace TesteDapper
{
    partial class frmInicial
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBuscarDados = new System.Windows.Forms.Button();
            this.listaDados = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.listaDados)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscarDados
            // 
            this.btnBuscarDados.Location = new System.Drawing.Point(13, 13);
            this.btnBuscarDados.Name = "btnBuscarDados";
            this.btnBuscarDados.Size = new System.Drawing.Size(462, 36);
            this.btnBuscarDados.TabIndex = 0;
            this.btnBuscarDados.Text = "Buscar Dados";
            this.btnBuscarDados.UseVisualStyleBackColor = true;
            this.btnBuscarDados.Click += new System.EventHandler(this.btnBuscarDados_Click);
            // 
            // listaDados
            // 
            this.listaDados.AllowUserToAddRows = false;
            this.listaDados.AllowUserToDeleteRows = false;
            this.listaDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaDados.Location = new System.Drawing.Point(13, 55);
            this.listaDados.Name = "listaDados";
            this.listaDados.ReadOnly = true;
            this.listaDados.RowHeadersVisible = false;
            this.listaDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaDados.Size = new System.Drawing.Size(462, 262);
            this.listaDados.TabIndex = 1;
            this.listaDados.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.listaDados_CellMouseDoubleClick);
            // 
            // frmInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 329);
            this.Controls.Add(this.listaDados);
            this.Controls.Add(this.btnBuscarDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teste | Dapper";
            ((System.ComponentModel.ISupportInitialize)(this.listaDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscarDados;
        private System.Windows.Forms.DataGridView listaDados;
    }
}

