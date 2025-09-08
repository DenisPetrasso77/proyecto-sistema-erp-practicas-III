namespace CapaVista
{
    partial class FrmPagos
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnEmitirOrdenPago = new System.Windows.Forms.Button();
            this.btnAgregarNotaCredito = new System.Windows.Forms.Button();
            this.btnAgregarFactura = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NroInforme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOTACREDITO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscador1 = new System.Windows.Forms.TextBox();
            this.lblBuscador = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnDetalle = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPagar = new System.Windows.Forms.Button();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.IdOrden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoNotaDeCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstadoOrdenDePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 79);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(628, 512);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAtras);
            this.tabPage1.Controls.Add(this.btnEmitirOrdenPago);
            this.tabPage1.Controls.Add(this.btnAgregarNotaCredito);
            this.tabPage1.Controls.Add(this.btnAgregarFactura);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.txtBuscador1);
            this.tabPage1.Controls.Add(this.lblBuscador);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(620, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Documentacion";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Location = new System.Drawing.Point(456, 424);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(140, 35);
            this.btnAtras.TabIndex = 8;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnEmitirOrdenPago
            // 
            this.btnEmitirOrdenPago.Location = new System.Drawing.Point(250, 372);
            this.btnEmitirOrdenPago.Name = "btnEmitirOrdenPago";
            this.btnEmitirOrdenPago.Size = new System.Drawing.Size(140, 35);
            this.btnEmitirOrdenPago.TabIndex = 7;
            this.btnEmitirOrdenPago.Text = "Emitir Orden de Pago";
            this.btnEmitirOrdenPago.UseVisualStyleBackColor = true;
            // 
            // btnAgregarNotaCredito
            // 
            this.btnAgregarNotaCredito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarNotaCredito.Location = new System.Drawing.Point(328, 308);
            this.btnAgregarNotaCredito.Name = "btnAgregarNotaCredito";
            this.btnAgregarNotaCredito.Size = new System.Drawing.Size(187, 35);
            this.btnAgregarNotaCredito.TabIndex = 5;
            this.btnAgregarNotaCredito.Text = "Cargar Nota de C.";
            this.btnAgregarNotaCredito.UseVisualStyleBackColor = true;
            // 
            // btnAgregarFactura
            // 
            this.btnAgregarFactura.Location = new System.Drawing.Point(83, 308);
            this.btnAgregarFactura.Name = "btnAgregarFactura";
            this.btnAgregarFactura.Size = new System.Drawing.Size(216, 35);
            this.btnAgregarFactura.TabIndex = 4;
            this.btnAgregarFactura.Text = "Cargar Factura";
            this.btnAgregarFactura.UseVisualStyleBackColor = true;
            this.btnAgregarFactura.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroInforme,
            this.Proveedor,
            this.Factura,
            this.NOTACREDITO});
            this.dataGridView1.Location = new System.Drawing.Point(83, 135);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(432, 155);
            this.dataGridView1.TabIndex = 3;
            // 
            // NroInforme
            // 
            this.NroInforme.HeaderText = "Id Orden de Compra";
            this.NroInforme.Name = "NroInforme";
            // 
            // Proveedor
            // 
            this.Proveedor.HeaderText = "Importe";
            this.Proveedor.Name = "Proveedor";
            // 
            // Factura
            // 
            this.Factura.HeaderText = "Factura";
            this.Factura.Name = "Factura";
            // 
            // NOTACREDITO
            // 
            this.NOTACREDITO.HeaderText = "Nota de Credito";
            this.NOTACREDITO.Name = "NOTACREDITO";
            // 
            // txtBuscador1
            // 
            this.txtBuscador1.Location = new System.Drawing.Point(83, 99);
            this.txtBuscador1.Multiline = true;
            this.txtBuscador1.Name = "txtBuscador1";
            this.txtBuscador1.Size = new System.Drawing.Size(432, 30);
            this.txtBuscador1.TabIndex = 2;
            // 
            // lblBuscador
            // 
            this.lblBuscador.AutoSize = true;
            this.lblBuscador.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscador.Location = new System.Drawing.Point(79, 77);
            this.lblBuscador.Name = "lblBuscador";
            this.lblBuscador.Size = new System.Drawing.Size(252, 19);
            this.lblBuscador.TabIndex = 1;
            this.lblBuscador.Text = "Buscar por Orden de Compra:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnVolver);
            this.tabPage2.Controls.Add(this.btnDetalle);
            this.tabPage2.Controls.Add(this.txtBuscar);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(620, 486);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gestión Pagos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.Location = new System.Drawing.Point(467, 439);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(140, 30);
            this.btnVolver.TabIndex = 18;
            this.btnVolver.Text = "Atras";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnDetalle
            // 
            this.btnDetalle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.Location = new System.Drawing.Point(424, 87);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(140, 30);
            this.btnDetalle.TabIndex = 17;
            this.btnDetalle.Text = "Detalle";
            this.btnDetalle.UseVisualStyleBackColor = true;
            this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(40, 87);
            this.txtBuscar.Multiline = true;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(350, 30);
            this.txtBuscar.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(333, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "Buscar por Orden de Pago/Nro Factura";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbFormaPago);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnPagar);
            this.groupBox1.Controls.Add(this.txtTotalPagar);
            this.groupBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(61, 263);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 162);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle";
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Items.AddRange(new object[] {
            "Tranferencia"});
            this.cmbFormaPago.Location = new System.Drawing.Point(166, 77);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(140, 27);
            this.cmbFormaPago.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Forma de Pago";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "TOTAL A PAGAR";
            // 
            // btnPagar
            // 
            this.btnPagar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagar.Location = new System.Drawing.Point(166, 120);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(140, 30);
            this.btnPagar.TabIndex = 13;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Location = new System.Drawing.Point(166, 38);
            this.txtTotalPagar.Multiline = true;
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.Size = new System.Drawing.Size(140, 25);
            this.txtTotalPagar.TabIndex = 11;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdOrden,
            this.IdProveedor,
            this.MontoNotaDeCredito,
            this.MontoFactura,
            this.EstadoOrdenDePago});
            this.dataGridView2.Location = new System.Drawing.Point(40, 133);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(524, 124);
            this.dataGridView2.TabIndex = 8;
            // 
            // IdOrden
            // 
            this.IdOrden.HeaderText = "Nro Orden de Pago";
            this.IdOrden.Name = "IdOrden";
            // 
            // IdProveedor
            // 
            this.IdProveedor.HeaderText = "Proveedor";
            this.IdProveedor.Name = "IdProveedor";
            // 
            // MontoNotaDeCredito
            // 
            this.MontoNotaDeCredito.HeaderText = "Monto de Nota de Crédito";
            this.MontoNotaDeCredito.Name = "MontoNotaDeCredito";
            // 
            // MontoFactura
            // 
            this.MontoFactura.HeaderText = "Monto de Factura";
            this.MontoFactura.Name = "MontoFactura";
            // 
            // EstadoOrdenDePago
            // 
            this.EstadoOrdenDePago.HeaderText = "Estado Orden De Pago";
            this.EstadoOrdenDePago.Name = "EstadoOrdenDePago";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(620, 486);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Pagos Pendientes";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-17, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 73);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CapaVista.Properties.Resources.metodo_de_pago;
            this.pictureBox2.Location = new System.Drawing.Point(70, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(126, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(397, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Carga de Documentación";
            // 
            // FrmPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 587);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmPagos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPagos";
            this.Load += new System.EventHandler(this.FrmPagos_Load);
            this.Shown += new System.EventHandler(this.FrmPagos_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtBuscador1;
        private System.Windows.Forms.Label lblBuscador;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAgregarFactura;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnAgregarNotaCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroInforme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOTACREDITO;
        private System.Windows.Forms.Button btnEmitirOrdenPago;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrden;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoNotaDeCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoOrdenDePago;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
    }
}