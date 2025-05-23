namespace CapaVista
{
    partial class FrmPR
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sugerencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidadpedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seleccionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Descripcion,
            this.StockActual,
            this.UnidadCompra,
            this.Referencia,
            this.Sugerencia,
            this.Cantidadpedida,
            this.Seleccionar});
            this.dataGridView1.Location = new System.Drawing.Point(12, 118);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1017, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 65;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // StockActual
            // 
            this.StockActual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.StockActual.HeaderText = "Stock Actual";
            this.StockActual.Name = "StockActual";
            this.StockActual.ReadOnly = true;
            this.StockActual.Width = 93;
            // 
            // UnidadCompra
            // 
            this.UnidadCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UnidadCompra.HeaderText = "Forma de Compra";
            this.UnidadCompra.Name = "UnidadCompra";
            this.UnidadCompra.ReadOnly = true;
            this.UnidadCompra.Width = 106;
            // 
            // Referencia
            // 
            this.Referencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Referencia.HeaderText = "Referencia";
            this.Referencia.Name = "Referencia";
            this.Referencia.ReadOnly = true;
            this.Referencia.Width = 84;
            // 
            // Sugerencia
            // 
            this.Sugerencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Sugerencia.HeaderText = "Sugerencia";
            this.Sugerencia.Name = "Sugerencia";
            this.Sugerencia.ReadOnly = true;
            this.Sugerencia.Width = 86;
            // 
            // Cantidadpedida
            // 
            this.Cantidadpedida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Cantidadpedida.HeaderText = "CantidadSolicitada";
            this.Cantidadpedida.Name = "Cantidadpedida";
            this.Cantidadpedida.ReadOnly = true;
            this.Cantidadpedida.Width = 120;
            // 
            // Seleccionar
            // 
            this.Seleccionar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Seleccionar.HeaderText = "Pedir";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Width = 37;
            // 
            // FrmPR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 359);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmPR";
            this.Text = "FrmPRcs";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sugerencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidadpedida;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seleccionar;
    }
}