
namespace Ejercicio1
{
    partial class fBusqueda
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
            this.bAnterior = new System.Windows.Forms.Button();
            this.bSiguiente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDNI = new System.Windows.Forms.TextBox();
            this.tbTelf = new System.Windows.Forms.TextBox();
            this.tbNombre = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbApellidos = new System.Windows.Forms.TextBox();
            this.lbContador = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bAnterior
            // 
            this.bAnterior.Location = new System.Drawing.Point(73, 293);
            this.bAnterior.Name = "bAnterior";
            this.bAnterior.Size = new System.Drawing.Size(170, 57);
            this.bAnterior.TabIndex = 0;
            this.bAnterior.Text = "Anterior";
            this.bAnterior.UseVisualStyleBackColor = true;
            this.bAnterior.Click += new System.EventHandler(this.bAnterior_Click);
            // 
            // bSiguiente
            // 
            this.bSiguiente.Location = new System.Drawing.Point(527, 293);
            this.bSiguiente.Name = "bSiguiente";
            this.bSiguiente.Size = new System.Drawing.Size(170, 57);
            this.bSiguiente.TabIndex = 1;
            this.bSiguiente.Text = "Siguiente";
            this.bSiguiente.UseVisualStyleBackColor = true;
            this.bSiguiente.Click += new System.EventHandler(this.bSiguiente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "DNI:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Telf:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Apellidos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(409, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nombre:";
            // 
            // tbDNI
            // 
            this.tbDNI.Location = new System.Drawing.Point(185, 56);
            this.tbDNI.Name = "tbDNI";
            this.tbDNI.ReadOnly = true;
            this.tbDNI.Size = new System.Drawing.Size(193, 22);
            this.tbDNI.TabIndex = 7;
            // 
            // tbTelf
            // 
            this.tbTelf.Location = new System.Drawing.Point(185, 189);
            this.tbTelf.Name = "tbTelf";
            this.tbTelf.ReadOnly = true;
            this.tbTelf.Size = new System.Drawing.Size(193, 22);
            this.tbTelf.TabIndex = 8;
            // 
            // tbNombre
            // 
            this.tbNombre.Location = new System.Drawing.Point(185, 127);
            this.tbNombre.Name = "tbNombre";
            this.tbNombre.ReadOnly = true;
            this.tbNombre.Size = new System.Drawing.Size(193, 22);
            this.tbNombre.TabIndex = 9;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(504, 89);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.ReadOnly = true;
            this.tbEmail.Size = new System.Drawing.Size(193, 22);
            this.tbEmail.TabIndex = 10;
            // 
            // tbApellidos
            // 
            this.tbApellidos.Location = new System.Drawing.Point(504, 159);
            this.tbApellidos.Name = "tbApellidos";
            this.tbApellidos.ReadOnly = true;
            this.tbApellidos.Size = new System.Drawing.Size(193, 22);
            this.tbApellidos.TabIndex = 11;
            // 
            // lbContador
            // 
            this.lbContador.AutoSize = true;
            this.lbContador.Location = new System.Drawing.Point(320, 313);
            this.lbContador.Name = "lbContador";
            this.lbContador.Size = new System.Drawing.Size(0, 17);
            this.lbContador.TabIndex = 12;
            // 
            // fBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 379);
            this.Controls.Add(this.lbContador);
            this.Controls.Add(this.tbApellidos);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbNombre);
            this.Controls.Add(this.tbTelf);
            this.Controls.Add(this.tbDNI);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSiguiente);
            this.Controls.Add(this.bAnterior);
            this.Name = "fBusqueda";
            this.Text = "Resultado(s) de la búsqueda";
            this.Load += new System.EventHandler(this.fBusqueda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAnterior;
        private System.Windows.Forms.Button bSiguiente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDNI;
        private System.Windows.Forms.TextBox tbTelf;
        private System.Windows.Forms.TextBox tbNombre;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbApellidos;
        private System.Windows.Forms.Label lbContador;
    }
}