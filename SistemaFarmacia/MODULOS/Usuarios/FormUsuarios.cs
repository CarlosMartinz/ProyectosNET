using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaFarmacia
{

    public partial class FormUsuarios : Form
    {

        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            pnlFondo.Visible = false;
            pnlicono.Visible = false;
            pnlAyuda.Visible = false;
            mostrar();
        }

        private void pnlFondo_Paint(object sender, PaintEventArgs e)
        {
            pnlFondo.BackColor = Color.FromArgb(75, 0, 0,0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        /******************/
        /***    CRUD    ***/
        /******************/

        //Metodo Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    //Data 'Carpeta', db_conexion 'Clase', conexion 'proceso'
                    con.ConnectionString = Data.db_conexion.conexion;
                    con.Open();

                    //Llama procedimiento de la BD 'insertarUsuario'
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("insertar_Usuarios", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@login", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@password", txtPass.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@rol", cboRol.Text);

                    //transforma el binario a un formato de sql img
                    System.IO.MemoryStream imag = new System.IO.MemoryStream();
                    ptcIconoPass.Image.Save(imag, ptcIconoPass.Image.RawFormat);

                    cmd.Parameters.AddWithValue("@icono", imag.GetBuffer());
                    cmd.Parameters.AddWithValue("@nombreIcono", txtNombreIcono.Text);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    mostrar();
                    pnlFondo.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        //Metodo mostrar
        private void mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter mos;
                SqlConnection con = new SqlConnection();
                //Data 'Carpeta', db_conexion 'Clase', conexion 'proceso'
                con.ConnectionString = Data.db_conexion.conexion;
                con.Open();
                mos = new SqlDataAdapter("mostrarUsuario", con);
                mos.Fill(dt);
                grdUsuarios.DataSource = dt;
                con.Close();

                grdUsuarios.Columns[1].Visible = false;
                grdUsuarios.Columns[2].Visible = true;
                grdUsuarios.Columns[3].Visible = true;
                grdUsuarios.Columns[4].Visible = true;
                grdUsuarios.Columns[5].Visible = false;
                grdUsuarios.Columns[6].Visible = false;
                grdUsuarios.Columns[7].Visible = false;
                grdUsuarios.Columns[8].Visible = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        /**************************************/
        /*   Muestra el panel de los iconos   */
        /**************************************/

        private void lblAnuncioIcono_Click(object sender, EventArgs e)
        {
            pnlicono.Visible = true;
            ptcIconoPass.Visible = false;
        }

        private void ptcIconoPass_Click(object sender, EventArgs e)
        {
            pnlicono.Visible = true;
            lblAnuncioIcono.Visible = true;
            ptcIconoPass.Visible = false;
            txtNombreIcono.Visible = false;
        }


        /*****************************/
        /*   Pasar icono al label   */
        /****************************/

        private void imgIcono_Click(object sender, EventArgs e)
        {
            ptcIconoPass.Image = imgIcono.Image;
            txtNombreIcono.Text = "Icono 1";
            lblAnuncioIcono.Visible = false;
            pnlicono.Visible = false;
            ptcIconoPass.Visible = true;
            txtNombreIcono.Visible = true;
        }
        private void imgIcono2_Click(object sender, EventArgs e)
        {
            ptcIconoPass.Image = imgIcono2.Image;
            txtNombreIcono.Text = "Icono 2"; 
            lblAnuncioIcono.Visible = false;
            pnlicono.Visible = false;
            ptcIconoPass.Visible = true;
            txtNombreIcono.Visible = true;
        }

        private void imgIcono3_Click(object sender, EventArgs e)
        {
            ptcIconoPass.Image = imgIcono3.Image;
            txtNombreIcono.Text = "Icono 3";
            lblAnuncioIcono.Visible = false;
            pnlicono.Visible = false;
            ptcIconoPass.Visible = true;
            txtNombreIcono.Visible = true;
        }

        private void imgIcono4_Click(object sender, EventArgs e)
        {
            ptcIconoPass.Image = imgIcono4.Image;
            txtNombreIcono.Text = "Icono 4";
            lblAnuncioIcono.Visible = false;
            pnlicono.Visible = false;
            ptcIconoPass.Visible = true;
            txtNombreIcono.Visible = true;
        }

        private void imgIcono5_Click(object sender, EventArgs e)
        {
            ptcIconoPass.Image = imgIcono5.Image;
            txtNombreIcono.Text = "Icono 5";
            lblAnuncioIcono.Visible = false;
            pnlicono.Visible = false;
            ptcIconoPass.Visible = true;
            txtNombreIcono.Visible = true;
        }

        private void imgIcono6_Click(object sender, EventArgs e)
        {
            ptcIconoPass.Image = imgIcono6.Image;
            txtNombreIcono.Text = "Icono 6";
            lblAnuncioIcono.Visible = false;
            pnlicono.Visible = false;
            ptcIconoPass.Visible = true;
            txtNombreIcono.Visible = true;
        }


        /*********************************************/
        /*   Busqueda de icono o foto del empleado   */
        /*********************************************/

        private void imgIconoBuscar_Click(object sender, EventArgs e)
        {

        }



        /***********************************/
        /*   Muestrar y oculta insertar empleado   */
        /**********************************/

        private void ptcCrud_Click(object sender, EventArgs e)
        {
            pnlFondo.Visible = true;
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            pnlFondo.Visible = false;
        }

        private void btnVolver_Click_(object sender, EventArgs e)
        {
            pnlFondo.Visible = false;
        }

        //MUestra panel de ayuda
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pnlAyuda.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlAyuda.Visible = false;
        }

        private void grdUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
