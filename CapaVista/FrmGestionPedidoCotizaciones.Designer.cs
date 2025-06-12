namespace CapaVista
{
    partial class FrmGestionPedidoCotizaciones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.IDPR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FECHA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USUARIOSOLICITANTE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANTIDADPRODUCTOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadPedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Proveedor2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Proveedor3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDPR,
            this.FECHA,
            this.USUARIOSOLICITANTE,
            this.CANTIDADPRODUCTOS});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView2.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridView2.Location = new System.Drawing.Point(12, 63);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(424, 187);
            this.dataGridView2.TabIndex = 15;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // IDPR
            // 
            this.IDPR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IDPR.HeaderText = "Nro. Pedido";
            this.IDPR.Name = "IDPR";
            this.IDPR.ReadOnly = true;
            this.IDPR.Width = 81;
            // 
            // FECHA
            // 
            this.FECHA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle13.Format = "dd/MM/yyyy";
            dataGridViewCellStyle13.NullValue = null;
            this.FECHA.DefaultCellStyle = dataGridViewCellStyle13;
            this.FECHA.HeaderText = "Fecha";
            this.FECHA.Name = "FECHA";
            this.FECHA.ReadOnly = true;
            this.FECHA.Width = 62;
            // 
            // USUARIOSOLICITANTE
            // 
            this.USUARIOSOLICITANTE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.USUARIOSOLICITANTE.HeaderText = "Pedido Por";
            this.USUARIOSOLICITANTE.Name = "USUARIOSOLICITANTE";
            this.USUARIOSOLICITANTE.ReadOnly = true;
            this.USUARIOSOLICITANTE.Width = 78;
            // 
            // CANTIDADPRODUCTOS
            // 
            this.CANTIDADPRODUCTOS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CANTIDADPRODUCTOS.HeaderText = "Cantidad de Productos";
            this.CANTIDADPRODUCTOS.Name = "CANTIDADPRODUCTOS";
            this.CANTIDADPRODUCTOS.ReadOnly = true;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToResizeColumns = false;
            this.dataGridView3.AllowUserToResizeRows = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDProducto,
            this.Descripcion2,
            this.CantidadPedida,
            this.Proveedor1,
            this.Proveedor2,
            this.Proveedor3});
            this.dataGridView3.Location = new System.Drawing.Point(459, 63);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(635, 187);
            this.dataGridView3.TabIndex = 16;
            this.dataGridView3.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(571, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "SELECCION DE PROVEEDORES POR PRODUCTOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "PEDIDOS PENDIENTES";
            // 
            // IDProducto
            // 
            this.IDProducto.HeaderText = "IDProducto";
            this.IDProducto.Name = "IDProducto";
            this.IDProducto.Visible = false;
            // 
            // Descripcion2
            // 
            this.Descripcion2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion2.HeaderText = "Producto";
            this.Descripcion2.Name = "Descripcion2";
            // 
            // CantidadPedida
            // 
            this.CantidadPedida.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CantidadPedida.HeaderText = "Cant. Pedida";
            this.CantidadPedida.Name = "CantidadPedida";
            // 
            // Proveedor1
            // 
            this.Proveedor1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Proveedor1.HeaderText = "Proveedor 1";
            this.Proveedor1.Name = "Proveedor1";
            this.Proveedor1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Proveedor1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Proveedor1.Width = 90;
            // 
            // Proveedor2
            // 
            this.Proveedor2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Proveedor2.HeaderText = "Proveedor 2";
            this.Proveedor2.Name = "Proveedor2";
            this.Proveedor2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Proveedor2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Proveedor2.Width = 90;
            // 
            // Proveedor3
            // 
            this.Proveedor3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Proveedor3.HeaderText = "Proveedor 3";
            this.Proveedor3.Name = "Proveedor3";
            this.Proveedor3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Proveedor3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Proveedor3.Width = 90;
            // 
            // FrmGestionPedidoCotizaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 329);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.dataGridView2);
            this.Name = "FrmGestionPedidoCotizaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GESTION PEDIDOS DE COTIZACION";
            this.Load += new System.EventHandler(this.FrmGestionPedidoCotizaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPR;
        private System.Windows.Forms.DataGridViewTextBoxColumn FECHA;
        private System.Windows.Forms.DataGridViewTextBoxColumn USUARIOSOLICITANTE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANTIDADPRODUCTOS;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadPedida;
        private System.Windows.Forms.DataGridViewComboBoxColumn Proveedor1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Proveedor2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Proveedor3;
    }
}