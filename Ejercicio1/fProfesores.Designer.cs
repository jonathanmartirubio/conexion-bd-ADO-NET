
namespace Ejercicio1
{
    partial class fProfesores
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
            this.dgProfesores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgProfesores)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProfesores
            // 
            this.dgProfesores.AllowUserToAddRows = false;
            this.dgProfesores.AllowUserToDeleteRows = false;
            this.dgProfesores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProfesores.Location = new System.Drawing.Point(40, 38);
            this.dgProfesores.Name = "dgProfesores";
            this.dgProfesores.ReadOnly = true;
            this.dgProfesores.RowHeadersWidth = 51;
            this.dgProfesores.RowTemplate.Height = 24;
            this.dgProfesores.Size = new System.Drawing.Size(715, 380);
            this.dgProfesores.TabIndex = 0;
            // 
            // fProfesores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgProfesores);
            this.Name = "fProfesores";
            this.Text = "Listado de Profesores";
            this.Load += new System.EventHandler(this.fProfesores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgProfesores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgProfesores;
    }
}