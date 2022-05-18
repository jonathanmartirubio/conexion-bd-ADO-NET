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
        public fProfesores(SqlDataAdapter dataAdapter)
        {
            InitializeComponent();

            this.dataAdapter = dataAdapter;
        }

        private SqlDataAdapter dataAdapter;

        private void fProfesores_Load(object sender, EventArgs e)
        {
            string cadConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\FA506IV\\source\\repos\\jonathanmartirubio\\conexion-bd-ADO-NET\\Instituto.mdf;Integrated Security=True;Connect Timeout=30";
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
