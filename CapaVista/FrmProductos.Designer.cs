namespace CapaVista
{
    partial class FrmProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductos));
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lbltituloHome = new System.Windows.Forms.Label();
            this.button18 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscador
            // 
            this.txtBuscador.Location = new System.Drawing.Point(28, 107);
            this.txtBuscador.Multiline = true;
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(293, 30);
            this.txtBuscador.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Location = new System.Drawing.Point(701, 429);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(144, 44);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(537, 234);
            this.dataGridView1.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(356, 145);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(190, 23);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Mostrar Stock Bajo";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(584, 242);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CapaVista.Properties.Resources.SignoMasFinal;
            this.pictureBox1.Location = new System.Drawing.Point(584, 177);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.lbltituloHome);
            this.panel1.Controls.Add(this.button18);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 72);
            this.panel1.TabIndex = 21;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::CapaVista.Properties.Resources.sign_out;
            this.pictureBox7.Location = new System.Drawing.Point(1160, 12);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(40, 40);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 15;
            this.pictureBox7.TabStop = false;
            // 
            // lbltituloHome
            // 
            this.lbltituloHome.AutoSize = true;
            this.lbltituloHome.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltituloHome.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbltituloHome.Location = new System.Drawing.Point(325, 22);
            this.lbltituloHome.Name = "lbltituloHome";
            this.lbltituloHome.Size = new System.Drawing.Size(179, 37);
            this.lbltituloHome.TabIndex = 6;
            this.lbltituloHome.Text = "Productos";
            // 
            // button18
            // 
            this.button18.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button18.FlatAppearance.BorderSize = 0;
            this.button18.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.Location = new System.Drawing.Point(1127, 45);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(109, 27);
            this.button18.TabIndex = 5;
            this.button18.Text = "Salir";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // FrmProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(857, 485);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtBuscador);
            this.Name = "FrmProductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmProductos";
            this.Load += new System.EventHandler(this.FrmProductos_Load);
            this.Shown += new System.EventHandler(this.FrmProductos_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lbltituloHome;
        private System.Windows.Forms.Button button18;
    }
}