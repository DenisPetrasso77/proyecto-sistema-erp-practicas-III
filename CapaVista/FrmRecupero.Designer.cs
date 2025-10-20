namespace CapaVista
{
    partial class FrmRecupero
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
            this.lblUsuarioCorreo = new System.Windows.Forms.Label();
            this.txtDato = new System.Windows.Forms.TextBox();
            this.btnComprobar = new System.Windows.Forms.Button();
            this.btnValidar = new System.Windows.Forms.Button();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.txtPregunta = new System.Windows.Forms.TextBox();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblRecuperoContraseña2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblRecuperoContraseña = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUsuarioCorreo
            // 
            this.lblUsuarioCorreo.AutoSize = true;
            this.lblUsuarioCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioCorreo.Location = new System.Drawing.Point(12, 9);
            this.lblUsuarioCorreo.Name = "lblUsuarioCorreo";
            this.lblUsuarioCorreo.Size = new System.Drawing.Size(199, 20);
            this.lblUsuarioCorreo.TabIndex = 0;
            this.lblUsuarioCorreo.Text = "Ingrese su Usuario/Correo:";
            // 
            // txtDato
            // 
            this.txtDato.Location = new System.Drawing.Point(218, 9);
            this.txtDato.Name = "txtDato";
            this.txtDato.Size = new System.Drawing.Size(150, 20);
            this.txtDato.TabIndex = 1;
            // 
            // btnComprobar
            // 
            this.btnComprobar.Location = new System.Drawing.Point(121, 35);
            this.btnComprobar.Name = "btnComprobar";
            this.btnComprobar.Size = new System.Drawing.Size(101, 29);
            this.btnComprobar.TabIndex = 2;
            this.btnComprobar.Text = "Comprobar";
            this.btnComprobar.UseVisualStyleBackColor = true;
            this.btnComprobar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.Location = new System.Drawing.Point(121, 137);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(101, 29);
            this.btnValidar.TabIndex = 5;
            this.btnValidar.Text = "Validar";
            this.btnValidar.UseVisualStyleBackColor = true;
            this.btnValidar.Visible = false;
            this.btnValidar.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblPregunta
            // 
            this.lblPregunta.AutoSize = true;
            this.lblPregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPregunta.Location = new System.Drawing.Point(12, 77);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(78, 20);
            this.lblPregunta.TabIndex = 3;
            this.lblPregunta.Text = "Pregunta:";
            this.lblPregunta.Visible = false;
            // 
            // txtPregunta
            // 
            this.txtPregunta.Enabled = false;
            this.txtPregunta.Location = new System.Drawing.Point(109, 77);
            this.txtPregunta.Name = "txtPregunta";
            this.txtPregunta.Size = new System.Drawing.Size(250, 20);
            this.txtPregunta.TabIndex = 3;
            this.txtPregunta.Visible = false;
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Location = new System.Drawing.Point(109, 111);
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(250, 20);
            this.txtRespuesta.TabIndex = 4;
            this.txtRespuesta.Visible = false;
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRespuesta.Location = new System.Drawing.Point(12, 111);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(91, 20);
            this.lblRespuesta.TabIndex = 6;
            this.lblRespuesta.Text = "Respuesta:";
            this.lblRespuesta.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(218, 224);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Visible = false;
            // 
            // lblRecuperoContraseña2
            // 
            this.lblRecuperoContraseña2.AutoSize = true;
            this.lblRecuperoContraseña2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecuperoContraseña2.Location = new System.Drawing.Point(12, 224);
            this.lblRecuperoContraseña2.Name = "lblRecuperoContraseña2";
            this.lblRecuperoContraseña2.Size = new System.Drawing.Size(196, 20);
            this.lblRecuperoContraseña2.TabIndex = 10;
            this.lblRecuperoContraseña2.Text = "Repita Nueva Contraseña:";
            this.lblRecuperoContraseña2.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(218, 190);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(141, 20);
            this.textBox2.TabIndex = 6;
            this.textBox2.Visible = false;
            // 
            // lblRecuperoContraseña
            // 
            this.lblRecuperoContraseña.AutoSize = true;
            this.lblRecuperoContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecuperoContraseña.Location = new System.Drawing.Point(12, 190);
            this.lblRecuperoContraseña.Name = "lblRecuperoContraseña";
            this.lblRecuperoContraseña.Size = new System.Drawing.Size(203, 20);
            this.lblRecuperoContraseña.TabIndex = 8;
            this.lblRecuperoContraseña.Text = "Ingrese Nueva Contraseña:";
            this.lblRecuperoContraseña.Visible = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(121, 260);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(101, 29);
            this.btnActualizar.TabIndex = 8;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Visible = false;
            this.btnActualizar.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmRecupero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 299);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblRecuperoContraseña2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblRecuperoContraseña);
            this.Controls.Add(this.txtRespuesta);
            this.Controls.Add(this.lblRespuesta);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.txtPregunta);
            this.Controls.Add(this.lblPregunta);
            this.Controls.Add(this.btnComprobar);
            this.Controls.Add(this.txtDato);
            this.Controls.Add(this.lblUsuarioCorreo);
            this.Name = "FrmRecupero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recupero Contraseña";
            this.Load += new System.EventHandler(this.FrmRecupero_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsuarioCorreo;
        private System.Windows.Forms.TextBox txtDato;
        private System.Windows.Forms.Button btnComprobar;
        private System.Windows.Forms.Button btnValidar;
        private System.Windows.Forms.Label lblPregunta;
        private System.Windows.Forms.TextBox txtPregunta;
        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.Label lblRespuesta;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblRecuperoContraseña2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblRecuperoContraseña;
        private System.Windows.Forms.Button btnActualizar;
    }
}