namespace CapaVista
{
    partial class FrmConfig
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
            this.grbIdioma = new System.Windows.Forms.GroupBox();
            this.lblIdioma = new System.Windows.Forms.Label();
            this.grbFuente = new System.Windows.Forms.GroupBox();
            this.rdbGrande = new System.Windows.Forms.RadioButton();
            this.rdbMediana = new System.Windows.Forms.RadioButton();
            this.rdbChico = new System.Windows.Forms.RadioButton();
            this.lblFuente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.lbltituloConfig = new System.Windows.Forms.Label();
            this.button18 = new System.Windows.Forms.Button();
            this.grbTema = new System.Windows.Forms.GroupBox();
            this.rdbContraste = new System.Windows.Forms.RadioButton();
            this.rdbOscuro = new System.Windows.Forms.RadioButton();
            this.rdbEstandar = new System.Windows.Forms.RadioButton();
            this.btnAtras = new System.Windows.Forms.Button();
            this.lblColores = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbHome = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.grbIdioma.SuspendLayout();
            this.grbFuente.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.grbTema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbIdioma
            // 
            this.grbIdioma.Controls.Add(this.comboBox1);
            this.grbIdioma.Location = new System.Drawing.Point(47, 469);
            this.grbIdioma.Name = "grbIdioma";
            this.grbIdioma.Size = new System.Drawing.Size(140, 122);
            this.grbIdioma.TabIndex = 50;
            this.grbIdioma.TabStop = false;
            this.grbIdioma.Text = "Seleccione un Idioma";
            // 
            // lblIdioma
            // 
            this.lblIdioma.AutoSize = true;
            this.lblIdioma.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdioma.Location = new System.Drawing.Point(93, 426);
            this.lblIdioma.Name = "lblIdioma";
            this.lblIdioma.Size = new System.Drawing.Size(70, 22);
            this.lblIdioma.TabIndex = 48;
            this.lblIdioma.Text = "Idioma";
            // 
            // grbFuente
            // 
            this.grbFuente.Controls.Add(this.rdbGrande);
            this.grbFuente.Controls.Add(this.rdbMediana);
            this.grbFuente.Controls.Add(this.rdbChico);
            this.grbFuente.Location = new System.Drawing.Point(395, 214);
            this.grbFuente.Name = "grbFuente";
            this.grbFuente.Size = new System.Drawing.Size(267, 203);
            this.grbFuente.TabIndex = 45;
            this.grbFuente.TabStop = false;
            this.grbFuente.Text = "Seleccione una Fuente";
            // 
            // rdbGrande
            // 
            this.rdbGrande.AutoSize = true;
            this.rdbGrande.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbGrande.Location = new System.Drawing.Point(18, 137);
            this.rdbGrande.Name = "rdbGrande";
            this.rdbGrande.Size = new System.Drawing.Size(149, 24);
            this.rdbGrande.TabIndex = 12;
            this.rdbGrande.TabStop = true;
            this.rdbGrande.Text = "Fuente Grande";
            this.rdbGrande.UseVisualStyleBackColor = true;
            this.rdbGrande.CheckedChanged += new System.EventHandler(this.rdbGrande_CheckedChanged);
            // 
            // rdbMediana
            // 
            this.rdbMediana.AutoSize = true;
            this.rdbMediana.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbMediana.Location = new System.Drawing.Point(18, 82);
            this.rdbMediana.Name = "rdbMediana";
            this.rdbMediana.Size = new System.Drawing.Size(145, 24);
            this.rdbMediana.TabIndex = 11;
            this.rdbMediana.TabStop = true;
            this.rdbMediana.Text = "Fuente Normal";
            this.rdbMediana.UseVisualStyleBackColor = true;
            this.rdbMediana.CheckedChanged += new System.EventHandler(this.rdbMediana_CheckedChanged);
            // 
            // rdbChico
            // 
            this.rdbChico.AutoSize = true;
            this.rdbChico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbChico.Location = new System.Drawing.Point(18, 32);
            this.rdbChico.Name = "rdbChico";
            this.rdbChico.Size = new System.Drawing.Size(160, 24);
            this.rdbChico.TabIndex = 10;
            this.rdbChico.TabStop = true;
            this.rdbChico.Text = "Fuente Pequeña";
            this.rdbChico.UseVisualStyleBackColor = true;
            this.rdbChico.CheckedChanged += new System.EventHandler(this.rdbChico_CheckedChanged);
            // 
            // lblFuente
            // 
            this.lblFuente.AutoSize = true;
            this.lblFuente.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFuente.Location = new System.Drawing.Point(441, 171);
            this.lblFuente.Name = "lblFuente";
            this.lblFuente.Size = new System.Drawing.Size(140, 22);
            this.lblFuente.TabIndex = 44;
            this.lblFuente.Text = "Tamaño Fuente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(367, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 22);
            this.label2.TabIndex = 43;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.pictureBox8);
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.lbltituloConfig);
            this.panel1.Controls.Add(this.button18);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 72);
            this.panel1.TabIndex = 42;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox8.Location = new System.Drawing.Point(253, 11);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(50, 50);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 17;
            this.pictureBox8.TabStop = false;
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
            // lbltituloConfig
            // 
            this.lbltituloConfig.AutoSize = true;
            this.lbltituloConfig.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltituloConfig.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbltituloConfig.Location = new System.Drawing.Point(309, 24);
            this.lbltituloConfig.Name = "lbltituloConfig";
            this.lbltituloConfig.Size = new System.Drawing.Size(251, 37);
            this.lbltituloConfig.TabIndex = 6;
            this.lbltituloConfig.Text = "Configuración";
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
            // grbTema
            // 
            this.grbTema.Controls.Add(this.rdbContraste);
            this.grbTema.Controls.Add(this.rdbOscuro);
            this.grbTema.Controls.Add(this.rdbEstandar);
            this.grbTema.Location = new System.Drawing.Point(48, 214);
            this.grbTema.Name = "grbTema";
            this.grbTema.Size = new System.Drawing.Size(255, 203);
            this.grbTema.TabIndex = 41;
            this.grbTema.TabStop = false;
            this.grbTema.Text = "Seleccione un Tema";
            // 
            // rdbContraste
            // 
            this.rdbContraste.AutoSize = true;
            this.rdbContraste.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbContraste.Location = new System.Drawing.Point(18, 137);
            this.rdbContraste.Name = "rdbContraste";
            this.rdbContraste.Size = new System.Drawing.Size(143, 24);
            this.rdbContraste.TabIndex = 12;
            this.rdbContraste.TabStop = true;
            this.rdbContraste.Text = "Contraste Alto";
            this.rdbContraste.UseVisualStyleBackColor = true;
            this.rdbContraste.CheckedChanged += new System.EventHandler(this.rdbContraste_CheckedChanged);
            // 
            // rdbOscuro
            // 
            this.rdbOscuro.AutoSize = true;
            this.rdbOscuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbOscuro.Location = new System.Drawing.Point(18, 82);
            this.rdbOscuro.Name = "rdbOscuro";
            this.rdbOscuro.Size = new System.Drawing.Size(133, 24);
            this.rdbOscuro.TabIndex = 11;
            this.rdbOscuro.TabStop = true;
            this.rdbOscuro.Text = "Tema Oscuro";
            this.rdbOscuro.UseVisualStyleBackColor = true;
            this.rdbOscuro.CheckedChanged += new System.EventHandler(this.rdbOscuro_CheckedChanged);
            // 
            // rdbEstandar
            // 
            this.rdbEstandar.AutoSize = true;
            this.rdbEstandar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbEstandar.Location = new System.Drawing.Point(18, 32);
            this.rdbEstandar.Name = "rdbEstandar";
            this.rdbEstandar.Size = new System.Drawing.Size(149, 24);
            this.rdbEstandar.TabIndex = 10;
            this.rdbEstandar.TabStop = true;
            this.rdbEstandar.Text = "Tema Estandar";
            this.rdbEstandar.UseVisualStyleBackColor = true;
            this.rdbEstandar.CheckedChanged += new System.EventHandler(this.rdbEstandar_CheckedChanged);
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Location = new System.Drawing.Point(629, 666);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(122, 34);
            this.btnAtras.TabIndex = 40;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // lblColores
            // 
            this.lblColores.AutoSize = true;
            this.lblColores.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColores.Location = new System.Drawing.Point(93, 171);
            this.lblColores.Name = "lblColores";
            this.lblColores.Size = new System.Drawing.Size(94, 24);
            this.lblColores.TabIndex = 39;
            this.lblColores.Text = "Colores";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CapaVista.Properties.Resources.translate;
            this.pictureBox2.Location = new System.Drawing.Point(47, 423);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 49;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(395, 168);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // pbHome
            // 
            this.pbHome.Location = new System.Drawing.Point(47, 168);
            this.pbHome.Name = "pbHome";
            this.pbHome.Size = new System.Drawing.Size(40, 40);
            this.pbHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHome.TabIndex = 46;
            this.pbHome.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(37, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 34);
            this.button1.TabIndex = 51;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(413, 475);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Integridad Base de Datos";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Aleman",
            "Español",
            "Frances",
            "Ingles",
            "Italiano",
            "Portugues",
            "Turco"});
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 713);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbIdioma);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblIdioma);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbHome);
            this.Controls.Add(this.grbFuente);
            this.Controls.Add(this.lblFuente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grbTema);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.lblColores);
            this.Name = "FrmConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConfig";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.Shown += new System.EventHandler(this.FrmConfig_Shown);
            this.grbIdioma.ResumeLayout(false);
            this.grbFuente.ResumeLayout(false);
            this.grbFuente.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.grbTema.ResumeLayout(false);
            this.grbTema.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHome)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbIdioma;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblIdioma;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbHome;
        private System.Windows.Forms.GroupBox grbFuente;
        private System.Windows.Forms.RadioButton rdbGrande;
        private System.Windows.Forms.RadioButton rdbMediana;
        private System.Windows.Forms.RadioButton rdbChico;
        private System.Windows.Forms.Label lblFuente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label lbltituloConfig;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.GroupBox grbTema;
        private System.Windows.Forms.RadioButton rdbContraste;
        private System.Windows.Forms.RadioButton rdbOscuro;
        private System.Windows.Forms.RadioButton rdbEstandar;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label lblColores;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}