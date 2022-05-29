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

        private void ControlarNavegacion(int pos)
        {
            if (pos == 0 || pos < 0)
            {
                bAnterior.Enabled = false;
                bPrimero.Enabled = false;
            }
            else
            {
                bAnterior.Enabled = true;
                bPrimero.Enabled = true;
            }
            if ((pos + 1) == MaxRegistros)
            {
                bSiguiente.Enabled = false;
                bUltimo.Enabled = false;
            }
            else
            {
                bSiguiente.Enabled = true;
                bUltimo.Enabled = true;
            }
        }

        private bool RegistroCambiado()
        {
            bool res;
            DataRow drRegistro = dsProfesores.Tables["Profesores"].Rows[pos];
            res = false;
            if (tbDNI.Text != (string)drRegistro["DNI"] || tbApellidos.Text != (string)drRegistro["Apellido"]
                || tbEmail.Text != (string)drRegistro["EMail"] || tbNombre.Text != (string)drRegistro["Nombre"] ||
                tbTelf.Text != (string)drRegistro["Tlf"])
            {
                res = true;
            }

            return res;
        }
        private void MostrarRegistro(int pos)
        {
            DataRow drRegistro;

            drRegistro = dsProfesores.Tables["Profesores"].Rows[pos];

            tbDNI.Text = drRegistro["DNI"].ToString();
            tbNombre.Text = drRegistro["Nombre"].ToString();
            tbTelf.Text = drRegistro["Tlf"].ToString();
            tbApellidos.Text = drRegistro["Apellido"].ToString();
            tbEmail.Text = drRegistro["email"].ToString();
            lbContador.Text = "Registro " + (pos + 1) + " de " + MaxRegistros;

        }

        private string SinRegistros()
        {
            string texto;
            tbApellidos.Clear();
            tbNombre.Clear();
            tbDNI.Clear();
            tbEmail.Clear();
            tbTelf.Clear();
            lbContador.Text = "La tabla de profesores está vacía";
            bBuscar.Enabled = false;
            bEliminar.Enabled = false;
            bSiguiente.Enabled = false;
            bAnterior.Enabled = false;
            bPrimero.Enabled = false;
            bUltimo.Enabled = false;
            bMostrarTodos.Enabled = false;
            bActualizar.Enabled = false;

            texto = lbContador.Text;


            return texto;
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
            MaxRegistros = dsProfesores.Tables["Profesores"].Rows.Count;
            if (MaxRegistros == 0)
            {
                SinRegistros();
            }
            else
            {
                MostrarRegistro(pos);
                ControlarNavegacion(pos);
                if (MaxRegistros == 1)
                {
                    bBuscar.Enabled = false;
                }
            }

            conect.Close();

        }

        private void bPrimero_Click(object sender, EventArgs e)
        {
            bool regCambiado;
            DialogResult pregunta;

            regCambiado = RegistroCambiado();
            if (!regCambiado)
            {
                pos = 0;
                ControlarNavegacion(pos);
                MostrarRegistro(pos);
            }
            else
            {
                pregunta = MessageBox.Show("¿El registro ha cambiado desea actualizarlo?", "Registro Cambiado", MessageBoxButtons.YesNo);
                if (pregunta == DialogResult.Yes)
                {
                    ControlarNavegacion(pos);
                }
                else
                {
                    pos = 0;
                    ControlarNavegacion(pos);
                    MostrarRegistro(pos);
                }
            }
        }

        private void bAnterior_Click(object sender, EventArgs e)
        {
            bool regCambiado;
            DialogResult pregunta;

            regCambiado = RegistroCambiado();
            if (!regCambiado)
            {
                pos--;
                ControlarNavegacion(pos);
                MostrarRegistro(pos);
            }
            else
            {
                pregunta = MessageBox.Show("¿El registro ha cambiado desea actualizarlo?", "Registro Cambiado", MessageBoxButtons.YesNo);
                if (pregunta == DialogResult.Yes)
                {
                    ControlarNavegacion(pos);
                }
                else
                {
                    pos--;
                    ControlarNavegacion(pos);
                    MostrarRegistro(pos);
                }
            }
        }
        private void bSiguiente_Click(object sender, EventArgs e)
        {
            bool regCambiado;
            DialogResult pregunta;

            regCambiado = RegistroCambiado();
            if (!regCambiado)
            {
                pos++;
                ControlarNavegacion(pos);
                MostrarRegistro(pos);
            }
            else
            {
                pregunta = MessageBox.Show("¿El registro ha cambiado desea actualizarlo?", "Registro Cambiado", MessageBoxButtons.YesNo);
                if (pregunta == DialogResult.Yes)
                {
                    ControlarNavegacion(pos);
                }
                else
                {
                    pos++;
                    ControlarNavegacion(pos);
                    MostrarRegistro(pos);
                }
            }
        }

        private void bUltimo_Click(object sender, EventArgs e)
        {
            bool regCambiado;
            DialogResult pregunta;

            regCambiado = RegistroCambiado();
            if (!regCambiado)
            {
                pos = MaxRegistros - 1;
                ControlarNavegacion(pos);
                MostrarRegistro(pos);
            }
            else
            {
                pregunta = MessageBox.Show("¿El registro ha cambiado desea actualizarlo?", "Registro Cambiado", MessageBoxButtons.YesNo);
                if (pregunta == DialogResult.Yes)
                {
                    ControlarNavegacion(pos);
                }
                else
                {
                    pos = MaxRegistros - 1;
                    ControlarNavegacion(pos);
                    MostrarRegistro(pos);
                }
            }
        }

        private void bAnyadir_Click(object sender, EventArgs e)
        {
            tbDNI.Clear();
            tbNombre.Clear();
            tbApellidos.Clear();
            tbEmail.Clear();
            tbTelf.Clear();
            bActualizar.Enabled = false;
        }
        private void bGuardar_Click(object sender, EventArgs e)
        {
            try 
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

                if (dsProfesores.Tables["Profesores"].Rows.Count == 1)
                {
                    pos = 0;
                    MaxRegistros++;
                    ControlarNavegacion(pos);
                    MostrarRegistro(pos);
                    bEliminar.Enabled = true;
                    bMostrarTodos.Enabled = true;
                }
                else
                {
                    MaxRegistros++;
                    pos = MaxRegistros - 1;
                    ControlarNavegacion(pos);
                    MostrarRegistro(pos);
                    bBuscar.Enabled = true;
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("El DNI introducido ya existe en la base de datos.");
            }

        }

        private void bActualizar_Click(object sender, EventArgs e)
        {
            DataRow drRegistro = dsProfesores.Tables["Profesores"].Rows[pos];

            drRegistro["DNI"] = tbDNI.Text;
            drRegistro["Nombre"] = tbNombre.Text;
            drRegistro["Apellido"] = tbApellidos.Text;
            drRegistro["Tlf"] = tbTelf.Text;
            drRegistro["EMail"] = tbEmail.Text;

            SqlCommandBuilder cb = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Update(dsProfesores, "Profesores");
            MessageBox.Show("Registro actualizado correctamente.");
        }
        private void bEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Eliminar;
            Eliminar = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo);

            if (Eliminar == DialogResult.Yes)
            {
                dsProfesores.Tables["Profesores"].Rows[pos].Delete();

                SqlCommandBuilder cb = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dsProfesores, "Profesores");
                if (dsProfesores.Tables["Profesores"].Rows.Count == 0)
                {
                    MaxRegistros--;
                    SinRegistros();
                }
                else
                {
                    MaxRegistros--;
                    pos = 0;
                    MostrarRegistro(pos);
                    if (dsProfesores.Tables["Profesores"].Rows.Count == 1)
                    {
                        ControlarNavegacion(pos);
                        bBuscar.Enabled = false;
                    }
                    MessageBox.Show("Registro eliminado.");
                    
                }
            }

        }
        private void TextoCambiado(object sender, EventArgs e)
        {
            if(dsProfesores.Tables["Profesores"].Rows.Count != 0)
            {
                if (tbDNI.Text == "" || tbNombre.Text == "" || tbApellidos.Text == "" || tbEmail.Text == "" || tbTelf.Text == "")
                {
                    bGuardar.Enabled = false;
                    bActualizar.Enabled = false;
                }
                else
                {
                    bGuardar.Enabled = true;
                }
                if (!RegistroCambiado())
                {
                    bActualizar.Enabled = false;
                    bGuardar.Enabled = false;
                }
                else
                {
                    if (tbDNI.Text != "" && tbNombre.Text != "" && tbApellidos.Text != "" && tbEmail.Text != "" && tbTelf.Text != "")
                    {
                        bActualizar.Enabled = true;
                    }
                }
            }
            else
            {
                if (tbDNI.Text != "" && tbNombre.Text != "" && tbApellidos.Text != "" && tbEmail.Text != "" && tbTelf.Text != "")
                {
                    bGuardar.Enabled = true;
                }
            }
            

        }


        private void bBuscar_Click(object sender, EventArgs e)
        {
            string datosBusqueda, busquedaSQL;

            datosBusqueda = tbBuscar.Text;
            busquedaSQL = "";

            if (!rbNombre.Checked && !rbApellidos.Checked && !rbDNI.Checked)
                MessageBox.Show("Seleccione el parámetro por el que quiere realizar la búsqueda.");
            else
            {
                if (datosBusqueda == "")
                    MessageBox.Show("Introduzca los criterios de búsqueda.");
                else
                {
                    if (rbDNI.Checked)
                        busquedaSQL = "SELECT * FROM Profesores WHERE DNI = " + datosBusqueda;
                    if (rbApellidos.Checked)
                        busquedaSQL = "SELECT * FROM Profesores WHERE Apellido LIKE '%" + datosBusqueda + "%'";
                    if (rbNombre.Checked)
                        busquedaSQL = "SELECT * FROM Profesores WHERE Nombre LIKE '%" + datosBusqueda + "%'";
                    fBusqueda fBus = new fBusqueda(busquedaSQL);
                    fBus.ShowDialog();
                }
                
            }  
        }

        private void bMostrarTodos_Click(object sender, EventArgs e)
        {
            fProfesores fProf = new fProfesores(dataAdapter);
            fProf.ShowDialog();
        }
    }
}
