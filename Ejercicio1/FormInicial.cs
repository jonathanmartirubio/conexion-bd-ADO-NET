using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ejercicio1
{
    public partial class FormInicial : Form
    {
        public FormInicial()
        {
            InitializeComponent();
        }

        private string cadConexion;
        private void bConectar_Click(object sender, EventArgs e)
        {
                cadConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\" + tbRutaConexion.Text + ";Integrated Security=True;Connect Timeout=30";
            Form1 form = new Form1(cadConexion);
            form.ShowDialog();
        }
    }
}
