using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        /******************/
        /***    CRUD    ***/
        /******************/

        public bool validarEmail(string emailVali)
        {
            return Regex.IsMatch(emailVali, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
        }

        //Metodo Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Dirreccion de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, " + " por favor seleccione un correo valido", "Validacion de correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                txtEmail.SelectAll();
            }
            else if (txtNombre.Text != "" && txtUsuario.Text != "" && txtPass.Text != "" && txtTelefono.Text != "" && cboRol.Text != "")
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
                    cmd.Parameters.AddWithValue("@rol", cboRol.SelectedItem);

                    string estado = "Activo";

                    //transforma el binario a un formato de sql img
                    System.IO.MemoryStream imag = new System.IO.MemoryStream();
                    ptcIconoPass.Image.Save(imag, ptcIconoPass.Image.RawFormat);

                    cmd.Parameters.AddWithValue("@icono", imag.GetBuffer());
                    cmd.Parameters.AddWithValue("@nombreIcono", txtNombreIcono.Text);
                    cmd.Parameters.AddWithValue("@estado", estado);

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
            else
            {
                MessageBox.Show("Debes llenar todos los campo obligatorios, a excepcion del correo");
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
                cargarIconos();
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
                grdUsuarios.Columns[9].Visible = true;
                grdUsuarios.Columns[10].Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        //Metodo pasar datos
        private void grdUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblidUsuario.Text = grdUsuarios.SelectedCells[1].Value.ToString();
            txtNombre.Text = grdUsuarios.SelectedCells[2].Value.ToString();
            txtTelefono.Text = grdUsuarios.SelectedCells[3].Value.ToString();
            txtUsuario.Text = grdUsuarios.SelectedCells[4].Value.ToString();
            txtPass.Text = grdUsuarios.SelectedCells[5].Value.ToString();

            //icono
            ptcIconoPass.BackgroundImage = null;
            byte[] b = (Byte[])grdUsuarios.SelectedCells[6].Value;
            MemoryStream ms = new MemoryStream(b);
            ptcIconoPass.Image = Image.FromStream(ms);

            lblAnuncioIcono.Visible = false;
            txtNombreIcono.Visible = true;
            ptcIconoPass.Visible = true;

            txtNombreIcono.Text = grdUsuarios.SelectedCells[7].Value.ToString();

            txtEmail.Text = grdUsuarios.SelectedCells[8].Value.ToString();
            cboRol.SelectedItem = grdUsuarios.SelectedCells[9].Value.ToString();

            pnlFondo.Visible = true;
            btnModificar.Visible = true;
            btnModificar.Enabled = true;

            pnlicono.Visible = false;

            btnGuardar.Visible = false;
            btnGuardar.Enabled = false;
        }

        public void cargarIconos()
        {
            try
            {
                foreach (DataGridViewRow row in grdUsuarios.Rows)
                {
                    string icono = Convert.ToString(row.Cells["NombreIcono"].Value);

                    if (icono == "1")
                    {
                        imgIcono.Visible = false;
                    }
                    else if (icono == "2")
                    {
                        imgIcono2.Visible = false;
                    }
                    else if (icono == "3")
                    {
                        imgIcono3.Visible = false;
                    }
                    else if (icono == "4")
                    {
                        imgIcono4.Visible = false;
                    }
                    else if (icono == "5")
                    {
                        imgIcono5.Visible = false;
                    }
                    else if (icono == "6")
                    {
                        imgIcono6.Visible = false;
                    }
                    
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        //Metodo actualizar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (validarEmail(txtEmail.Text) == false)
            {
                MessageBox.Show("Dirreccion de correo electronico no valida, el correo debe tener el formato: nombre@dominio.com, " + " por favor seleccione un correo valido", "Validacion de correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                txtEmail.SelectAll();
            }
            else if (txtNombre.Text != "" && txtUsuario.Text != "" && txtPass.Text != "" && txtTelefono.Text != "" && cboRol.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    //Data 'Carpeta', db_conexion 'Clase', conexion 'proceso'
                    con.ConnectionString = Data.db_conexion.conexion;
                    con.Open();

                    //Llama procedimiento de la BD 'insertarUsuario'
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("modificarUsuario", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUsuario", lblidUsuario.Text);
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

                    btnGuardar.Visible = false;
                    btnGuardar.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debes llenar todos los campo obligatorios, a excepcion del correo");
            }
        }

        //Metodo eliminar o desabilitar
        private void grdUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == this.grdUsuarios.Columns["eliminar"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("Estas suguro de eliminar este usuario?","Eliminar usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if(result == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in grdUsuarios.SelectedRows)
                    {
                        int onekey = Convert.ToInt32(row.Cells["Codigo"].Value);
                        string usuario = Convert.ToString(row.Cells["Usuario"].Value);

                        try
                        {
                            SqlConnection con = new SqlConnection();
                            //Data 'Carpeta', db_conexion 'Clase', conexion 'proceso'
                            con.ConnectionString = Data.db_conexion.conexion;
                            con.Open();
                            
                            //Llama procedimiento de la BD 'insertarUsuario'
                            SqlCommand cmd = new SqlCommand();
                            cmd = new SqlCommand("eliminarUsuario", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@idUsuario", onekey);
                            cmd.Parameters.AddWithValue("@login", usuario);

                            cmd.ExecuteNonQuery();
                            con.Close();
                            mostrar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        /**************************************/
        /*   Muestra el panel de los iconos   */
        /**************************************/

        private void lblAnuncioIcono_Click(object sender, EventArgs e)
        {
            pnlicono.Visible = true;
            cargarIconos();
        }

        private void ptcIconoPass_Click(object sender, EventArgs e)
        {
            pnlicono.Visible = true;
            lblAnuncioIcono.Visible = true;
            ptcIconoPass.Visible = false;
            txtNombreIcono.Visible = false;
            cargarIconos();
        }


        /*****************************/
        /*   Pasar icono al label   */
        /****************************/

        private void imgIcono_Click(object sender, EventArgs e)
        {
            ptcIconoPass.Image = imgIcono.Image;
            txtNombreIcono.Text = "1";
            lblAnuncioIcono.Visible = false;
            pnlicono.Visible = false;
            ptcIconoPass.Visible = true;
            txtNombreIcono.Visible = true;
        }
        private void imgIcono2_Click(object sender, EventArgs e)
        {
            ptcIconoPass.Image = imgIcono2.Image;
            txtNombreIcono.Text = "2"; 
            lblAnuncioIcono.Visible = false;
            pnlicono.Visible = false;
            ptcIconoPass.Visible = true;
            txtNombreIcono.Visible = true;
        }

        private void imgIcono3_Click(object sender, EventArgs e)
        {
            ptcIconoPass.Image = imgIcono3.Image;
            txtNombreIcono.Text = "3";
            lblAnuncioIcono.Visible = false;
            pnlicono.Visible = false;
            ptcIconoPass.Visible = true;
            txtNombreIcono.Visible = true;
        }

        private void imgIcono4_Click(object sender, EventArgs e)
        {
            ptcIconoPass.Image = imgIcono4.Image;
            txtNombreIcono.Text = "4";
            lblAnuncioIcono.Visible = false;
            pnlicono.Visible = false;
            ptcIconoPass.Visible = true;
            txtNombreIcono.Visible = true;
        }

        private void imgIcono5_Click(object sender, EventArgs e)
        {
            ptcIconoPass.Image = imgIcono5.Image;
            txtNombreIcono.Text = "5";
            lblAnuncioIcono.Visible = false;
            pnlicono.Visible = false;
            ptcIconoPass.Visible = true;
            txtNombreIcono.Visible = true;
        }

        private void imgIcono6_Click(object sender, EventArgs e)
        {
            ptcIconoPass.Image = imgIcono6.Image;
            txtNombreIcono.Text = "6";
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
            pnlicono.Visible = false;

            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = "";
            txtPass.Text = "";
            txtEmail.Text = "";
            cboRol.SelectedItem = "";
            txtNombreIcono.Text = "";
            lblAnuncioIcono.Visible = true;
            
            btnGuardar.Visible = true;
            btnGuardar.Enabled = true;
            
            btnModificar.Visible = false;
            btnModificar.Enabled = false;
            
            ptcIconoPass.Visible = false;
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            pnlFondo.Visible = false;
        }

        private void btnVolver_Click_(object sender, EventArgs e)
        {
            pnlFondo.Visible = false;
        }

        //Muestra panel de ayuda
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pnlAyuda.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlAyuda.Visible = false;
        }
    }

}
