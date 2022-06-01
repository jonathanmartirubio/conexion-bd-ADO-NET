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
    public partial class fProfesores : Form
    {
        public fProfesores(SqlDataAdapter dataAdapter, string cadConexion)
        {
            InitializeComponent();

            this.dataAdapter = dataAdapter;
            this.cadConexion = cadConexion;
        }

        private SqlDataAdapter dataAdapter;
        private string cadConexion;

        private void fProfesores_Load(object sender, EventArgs e)
        {
            SqlConnection conect = new SqlConnection(cadConexion);

            conect.Open();

            string cadenaSQL = "SELECT * From Profesores";
            dataAdapter = new SqlDataAdapter(cadenaSQL, conect);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            dgProfesores.DataSource = dt;

            conect.Close();
        }
    }
}
