namespace TesteDapper.Formularios
{
    partial class frmExibirDados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listaDados = new System.Windows.Forms.DataGridView();
            this.btnVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listaDados)).BeginInit();
            this.SuspendLayout();
            // 
            // listaDados
            // 
            this.listaDados.AllowUserToAddRows = false;
            this.listaDados.AllowUserToDeleteRows = false;
            this.listaDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaDados.Location = new System.Drawing.Point(12, 12);
            this.listaDados.Name = "listaDados";
            this.listaDados.ReadOnly = true;
            this.listaDados.RowHeadersVisible = false;
            this.listaDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaDados.Size = new System.Drawing.Size(361, 274);
            this.listaDados.TabIndex = 3;
            this.listaDados.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.listaDados_CellMouseDoubleClick);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(12, 292);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(361, 36);
            this.btnVoltar.TabIndex = 2;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // frmExibirDados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 340);
            this.Controls.Add(this.listaDados);
            this.Controls.Add(this.btnVoltar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExibirDados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teste | Dapper";
            this.Load += new System.EventHandler(this.frmExibirDados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView listaDados;
        private System.Windows.Forms.Button btnVoltar;
    }
}