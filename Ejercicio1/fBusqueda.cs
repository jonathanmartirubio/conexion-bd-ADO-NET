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
    public partial class fBusqueda : Form
    {
        public fBusqueda(string busquedaSQL, string cadConexion)
        {
            InitializeComponent();

            this.busquedaSQL = busquedaSQL;
            this.cadConexion = cadConexion;
        }

        private int pos;
        private int max;
        private string busquedaSQL;
        private string cadConexion;
        DataSet dsResultado;
        SqlDataAdapter da;

        private void ControlarNavegacion(int pos)
        {
            if (pos == 0 || pos < 0)
                bAnterior.Enabled = false;
            else
                bAnterior.Enabled = true;
            if ((pos + 1) == max)
                bSiguiente.Enabled = false;
            else
                bSiguiente.Enabled = true;
        }
        private void MostrarResultado(int pos)
        {
            if (dsResultado.Tables["Busqueda"].Rows.Count == 0)
            {
                this.Close();
                MessageBox.Show("No Hay ningún resultado para esta búsqueda.", "Resultado de la búsqueda");
            }
            else
            {
                DataRow drRegistro;

                drRegistro = dsResultado.Tables["Busqueda"].Rows[pos];

                tbDNI.Text = drRegistro["DNI"].ToString();
                tbNombre.Text = drRegistro["Nombre"].ToString();
                tbTelf.Text = drRegistro["Tlf"].ToString();
                tbApellidos.Text = drRegistro["Apellido"].ToString();
                tbEmail.Text = drRegistro["email"].ToString();
                lbContador.Text = "Resultado " + (pos + 1) + " de " + max;
            }
        }
        private void fBusqueda_Load(object sender, EventArgs e)
        {
            SqlConnection conect = new SqlConnection(cadConexion);

            conect.Open();
            da = new SqlDataAdapter(busquedaSQL, conect);
            dsResultado = new DataSet();
            da.Fill(dsResultado, "Busqueda");

            pos = 0;
            max = dsResultado.Tables["Busqueda"].Rows.Count;
            MostrarResultado(pos);
            ControlarNavegacion(pos);
            conect.Close();
        }

        private void bAnterior_Click(object sender, EventArgs e)
        {
            pos--;
            ControlarNavegacion(pos);
            MostrarResultado(pos);
        }

        private void bSiguiente_Click(object sender, EventArgs e)
        {
            pos++;
            ControlarNavegacion(pos);
            MostrarResultado(pos);
        }
    }
}
