using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataSet dsProfesores;
        SqlDataAdapter dataAdapter;
        private int pos;
        private int MaxRegistros;

        private void MostrarRegistro(int pos)
        {
            DataRow drRegistro;

            drRegistro = dsProfesores.Tables["Profesores"].Rows[pos];

            tbDNI.Text = drRegistro["DNI"].ToString();
            tbNombre.Text = drRegistro["Nombre"].ToString();
            tbTelf.Text = drRegistro["Tlf"].ToString();
            tbApellidos.Text = drRegistro["Apellido"].ToString();
            tbEmail.Text = drRegistro["email"].ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string cadConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\FA506IV\\source\\repos\\jonathanmartirubio\\conexion-bd-ADO-NET\\Instituto.mdf;Integrated Security=True;Connect Timeout=30";

            SqlConnection conect = new SqlConnection(cadConexion);

            conect.Open();

            string cadenaSQL = "SELECT * From Profesores";
            dataAdapter = new SqlDataAdapter(cadenaSQL, conect);

            dsProfesores = new DataSet();

            dataAdapter.Fill(dsProfesores, "Profesores");

            pos = 0;
            MostrarRegistro(pos);
            MaxRegistros = dsProfesores.Tables["Profesores"].Rows.Count;

            conect.Close();
        }

        private void bPrimero_Click(object sender, EventArgs e)
        {
            pos = 0;
            MostrarRegistro(pos);
        }
        //TODO: desactivar botones si se superan los límites del registro. 
        private void bAnterior_Click(object sender, EventArgs e)
        {
            pos--;
            MostrarRegistro(pos);
        }

        private void bSiguiente_Click(object sender, EventArgs e)
        {
            pos++;
            MostrarRegistro(pos);
        }

        private void bUltimo_Click(object sender, EventArgs e)
        {
            pos = MaxRegistros - 1;
            MostrarRegistro(pos);
        }

        private void bAnyadir_Click(object sender, EventArgs e)
        {
            tbDNI.Clear();
            tbNombre.Clear();
            tbApellidos.Clear();
            tbEmail.Clear();
            tbTelf.Clear();
        }

        private void bGuardar_Click(object sender, EventArgs e)
        {
            DataRow drRegistro = dsProfesores.Tables["Profesores"].NewRow();

            drRegistro["DNI"] = tbDNI.Text;
            drRegistro["Nombre"] = tbNombre.Text;
            drRegistro["Apellido"] = tbApellidos.Text;
            drRegistro["Tlf"] = tbTelf.Text;
            drRegistro["EMail"] = tbEmail.Text;

            dsProfesores.Tables["Profesores"].Rows.Add(drRegistro);

            SqlCommandBuilder cb = new SqlCommandBuilder(dataAdapter);

            dataAdapter.Update(dsProfesores, "Profesores");

            MaxRegistros++;
            pos = MaxRegistros - 1;
        }
    }
}
