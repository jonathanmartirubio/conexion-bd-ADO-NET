
namespace Ejercicio1
{
    partial class FormInicial
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
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRutaConexion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bConectar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(210, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(334, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "users\\USUARIO\\CARPETAPROYECTO\\Instituto.mdf";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(77, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "C:\\";
            // 
            // tbRutaConexion
            // 
            this.tbRutaConexion.Location = new System.Drawing.Point(105, 153);
            this.tbRutaConexion.Name = "tbRutaConexion";
            this.tbRutaConexion.Size = new System.Drawing.Size(441, 22);
            this.tbRutaConexion.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(150, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(511, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Escribe la ruta donde se encuentra tu archivo de la base de datos, por ejemplo:";
            // 
            // bConectar
            // 
            this.bConectar.Location = new System.Drawing.Point(565, 133);
            this.bConectar.Name = "bConectar";
            this.bConectar.Size = new System.Drawing.Size(162, 62);
            this.bConectar.TabIndex = 22;
            this.bConectar.Text = "Conectar";
            this.bConectar.UseVisualStyleBackColor = true;
            this.bConectar.Click += new System.EventHandler(this.bConectar_Click);
            // 
            // FormInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 308);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbRutaConexion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bConectar);
            this.Name = "FormInicial";
            this.Text = "Conectar a la Base de datos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRutaConexion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button bConectar;
    }
}