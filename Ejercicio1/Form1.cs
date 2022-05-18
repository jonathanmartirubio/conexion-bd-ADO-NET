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
        
        private void Deshabilitar(int pos)
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
            if((pos+1) == MaxRegistros)
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
                DialogResult pregunta;

                pregunta = MessageBox.Show("¿El registro ha cambiado desea actualizarlo?", "Registro Cambiado", MessageBoxButtons.YesNo);

                if (pregunta == DialogResult.Yes)
                {
                    res = true;
                }
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
            lbContador.Text = "Registro " + (pos + 1) + " de " + MaxRegistros;
            bAnterior.Enabled = false;
            bPrimero.Enabled = false;
            bActualizar.Enabled = false;
            conect.Close();

        }

        private void bPrimero_Click(object sender, EventArgs e)
        {
            bool pregunta;

            pregunta = RegistroCambiado();

            if (!pregunta)
            {
                pos = 0;
                Deshabilitar(pos);
                MostrarRegistro(pos);
                lbContador.Text = "Registro " + (pos + 1) + " de " + MaxRegistros;
                bActualizar.Enabled = false;
            }
            else
            {
                Deshabilitar(pos);
                lbContador.Text = "Registro " + (pos + 1) + " de " + MaxRegistros;
            }

        }

        private void bAnterior_Click(object sender, EventArgs e)
        {
            bool pregunta;

            pregunta = RegistroCambiado();
            if (!pregunta)
            {
                pos--;
                Deshabilitar(pos);
                MostrarRegistro(pos);
                lbContador.Text = "Registro " + (pos + 1) + " de " + MaxRegistros;
                bActualizar.Enabled = false;
            }
            else
            {
                Deshabilitar(pos);
                lbContador.Text = "Registro " + (pos + 1) + " de " + MaxRegistros;
            }
            
        }
        private void bSiguiente_Click(object sender, EventArgs e)
        {
            bool pregunta;

            pregunta = RegistroCambiado();
            if (!pregunta)
            {
                pos++;
                Deshabilitar(pos);
                MostrarRegistro(pos);
                lbContador.Text = "Registro " + (pos + 1) + " de " + MaxRegistros;
                bActualizar.Enabled = false;
            }
            else
            {
                Deshabilitar(pos);
                lbContador.Text = "Registro " + (pos + 1) + " de " + MaxRegistros;
            }
            
        }

        private void bUltimo_Click(object sender, EventArgs e)
        {
            bool pregunta;

            pregunta = RegistroCambiado();

            if (!pregunta)
            {
                pos = MaxRegistros - 1;
                Deshabilitar(pos);
                MostrarRegistro(pos);
                lbContador.Text = "Registro " + (pos + 1) + " de " + MaxRegistros;
                bActualizar.Enabled = false;
            }
            else
            {
                Deshabilitar(pos);
                lbContador.Text = "Registro " + (pos + 1) + " de " + MaxRegistros;
            }

        }

        private void bAnyadir_Click(object sender, EventArgs e)
        {
            tbDNI.Clear();
            tbNombre.Clear();
            tbApellidos.Clear();
            tbEmail.Clear();
            tbTelf.Clear();
        }
        //TODO: Comprobar datos correctos TextChanged
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
            Deshabilitar(pos);
            MostrarRegistro(pos);
            lbContador.Text = "Registro " + (pos + 1) + " de " + MaxRegistros;
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
        }
        //TODO: Controlar lo que se muestra si al eliminar no quedasen registros
        private void bEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Eliminar;
            Eliminar = MessageBox.Show("¿Desea eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo);

            if (Eliminar == DialogResult.Yes)
            {
                dsProfesores.Tables["Profesores"].Rows[pos].Delete();

                SqlCommandBuilder cb = new SqlCommandBuilder(dataAdapter);
                dataAdapter.Update(dsProfesores, "Profesores");
                MaxRegistros--;
                pos = 0;
                MostrarRegistro(pos);
                MessageBox.Show("Registro eliminado.");
            }
            
        }

        private void TextoCambiado(object sender, EventArgs e)
        {
                bActualizar.Enabled = true;
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
