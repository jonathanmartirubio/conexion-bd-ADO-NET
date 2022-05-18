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
        public fBusqueda(string busquedaSQL)
        {
            InitializeComponent();

            this.busquedaSQL = busquedaSQL;
        }

        private int pos;
        private int max;
        private string busquedaSQL;
        DataSet dsResultado;
        SqlDataAdapter da;

        private void Deshabilitar(int pos)
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
            }
        }
        private void fBusqueda_Load(object sender, EventArgs e)
        {
            string cadConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\FA506IV\\source\\repos\\jonathanmartirubio\\conexion-bd-ADO-NET\\Instituto.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection conect = new SqlConnection(cadConexion);

            conect.Open();
            da = new SqlDataAdapter(busquedaSQL, conect);
            dsResultado = new DataSet();
            da.Fill(dsResultado, "Busqueda");

            pos = 0;
            MostrarResultado(pos);
            max = dsResultado.Tables["Busqueda"].Rows.Count;
            lbContador.Text = "Resultado " + (pos + 1) + " de " + max;
            bAnterior.Enabled = false;
            if (max == 1)
            {
                bSiguiente.Enabled = false;
            }
            conect.Close();
        }

        private void bAnterior_Click(object sender, EventArgs e)
        {
            pos--;
            Deshabilitar(pos);
            MostrarResultado(pos);
            lbContador.Text = "Resultado " + (pos + 1) + " de " + max;
        }

        private void bSiguiente_Click(object sender, EventArgs e)
        {
            pos++;
            Deshabilitar(pos);
            MostrarResultado(pos);
            lbContador.Text = "Resultado " + (pos + 1) + " de " + max;
        }
    }
}
