using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace SistemaFarmacia.MODULOS.Login
{
    public partial class FormLogin : Form
    {
        int contador;
        public FormLogin()
        {
            InitializeComponent();
        }

        public void cmdtrarUsuarios()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Data.db_conexion.conexion;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("select * from Usuarios where Estado = 'Activo'", con);
            SqlDataReader dataReal = cmd.ExecuteReader();

            while (dataReal.Read())
            {
                Label b = new Label();
                Panel p1 = new Panel();
                PictureBox I1 = new PictureBox();

                b.Text = dataReal["Login"].ToString();
                b.Name = dataReal["idUsuario"].ToString();
                b.Size = new Size(175, 25);
                b.Font = new Font("Microsoft Sans Serif", 13);
                b.BackColor = Color.FromArgb(20, 20, 20);
                b.ForeColor = Color.White;
                b.Dock = DockStyle.Bottom;
                b.TextAlign = ContentAlignment.MiddleCenter;
                b.Cursor = Cursors.Hand;

                p1.Size = new Size(155, 167);
                p1.BorderStyle = BorderStyle.None;
                p1.BackColor = Color.FromArgb(20, 20, 20);


                I1.Size = new Size(175, 132);
                I1.Dock = DockStyle.Top;
                I1.BackgroundImage = null;
                byte[] bi = (Byte[])dataReal["Icono"];
                MemoryStream ms = new MemoryStream(bi);
                I1.Image = Image.FromStream(ms);
                I1.SizeMode = PictureBoxSizeMode.Zoom;
                I1.Tag = dataReal["Login"].ToString();
                I1.Cursor = Cursors.Hand;

                p1.Controls.Add(b);
                p1.Controls.Add(I1);
                b.BringToFront();
                flowLayoutPanel1.Controls.Add(p1);

                b.Click += new EventHandler(cargarValidarText);  
                I1.Click += new EventHandler(cargarValidarImg);  
            }
            con.Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            cmdtrarUsuarios();
            mostrarCorreos();
            pnlRestaurar.Visible = false;
            pnlVerificador.Visible = false;
            btnVolver.Visible = false;
            pnlUsuarios.Visible = true;

            espera.Start();
        }

        private void cargarValidarText(Object sender, EventArgs e)
        {
            lblLogin.Text = ((Label)sender).Text;
            pnlVerificador.Visible = true;
            pnlUsuarios.Visible = false;
        }
       private void cargarValidarImg(Object sender, EventArgs e)
       {
            lblLogin.Text = ((PictureBox)sender).Tag.ToString();
            pnlVerificador.Visible = true;
            pnlUsuarios.Visible = false;
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            iniciar();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            pnlRestaurar.Visible = false;
            pnlVerificador.Visible = false;
            pnlUsuarios.Visible = true;
            txtpassword.Text = "";
        }

        /************************************************/
        /*       Control de validacion de datos         */
        /************************************************/
        private void iniciar()
        {
            validarUsuario();
            contar();

            //if(contador > 0)
            //{
            //    Caja.FormApertura apertura = new Caja.FormApertura();
            //    apertura.ShowDialog();
            //    this.Hide();
            //}
        }

        private void contar()
        {
            int x;
            x = dataGridView1.Rows.Count;
            contador = (x);
        }

        private void validarUsuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter mos;
                SqlConnection con = new SqlConnection();
                //Data 'Carpeta', db_conexion 'Clase', conexion 'proceso'
                con.ConnectionString = Data.db_conexion.conexion;
                con.Open();
                mos = new SqlDataAdapter("validarUsuario", con);
                mos.SelectCommand.CommandType = CommandType.StoredProcedure;
                mos.SelectCommand.Parameters.AddWithValue("@login", lblLogin.Text);
                mos.SelectCommand.Parameters.AddWithValue("@pass", txtpassword.Text);
                mos.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         private void buscarUserCorreo()
         {
            try
            {
                string result;
                DataTable dt = new DataTable();
                SqlDataAdapter mos;
                SqlConnection con = new SqlConnection();
                //Data 'Carpeta', db_conexion 'Clase', conexion 'proceso'
                con.ConnectionString = Data.db_conexion.conexion;
                con.Open();
                SqlCommand da = new SqlCommand("mostrarPass", con);
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@email", cboCorreo.Text);

                lblResultadoPass.Text = Convert.ToString(da.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            buscarUserCorreo();
            txtMensaje.Text = txtMensaje.Text.Replace("@password", lblResultadoPass.Text);
            enviarCorreo("desing.cod@gmail.com", "582469713Ca", txtMensaje.Text, "Solicitud de Contraseña", cboCorreo.Text, "");
        }

        internal void enviarCorreo(string emisor, string password, string mensaje, string asunto, string destinatario, string ruta)
        {
            try
            {
                MailMessage correos = new MailMessage();
                SmtpClient envios = new SmtpClient();
                correos.To.Clear();
                correos.Body = "";
                correos.Subject = "";
                correos.Body = mensaje;
                correos.Subject = asunto;
                correos.IsBodyHtml = true;
                correos.To.Add((destinatario));
                correos.From = new MailAddress(emisor);
                envios.Credentials = new NetworkCredential(emisor, password);

                envios.Host = "smtp.gmail.com";
                envios.Port = 587;
                envios.EnableSsl = true;

                envios.Send(correos);
                lblEstadoEnvio.Text = "ENVIADO";
                MessageBox.Show("Contraseña Enviada, revisa tu correo electronico, si no logras encontrar el correo reisa el spam", "Restauracion de contraseña", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //PanelRestaurarCuenta.Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR, revisa tu correo Electronico", "Restauracion de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //lblEstado_de_envio.Text = "Correo no registrado";
            }

        }

        private void mostrarCorreos()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter mos;
                SqlConnection con = new SqlConnection();
                //Data 'Carpeta', db_conexion 'Clase', conexion 'proceso'
                con.ConnectionString = Data.db_conexion.conexion;
                con.Open();
                mos = new SqlDataAdapter("select Email from Usuarios where Estado = 'Activo'", con);

                mos.Fill(dt);
                cboCorreo.DisplayMember = "Email";
                cboCorreo.ValueMember = "Email";
                cboCorreo.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mostrarCajaPorSerial()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Data.db_conexion.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrarCajaSerial", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Serial", lblSerial.Text);
                da.Fill(dt);
                datalistado_caja.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

          /*****************************************/
          /*   Control de visibilidad de paneles   */
          /*****************************************/
        private void button1_Click(object sender, EventArgs e)
        {
            pnlRestaurar.Visible = false;
            btnSalirLogin.Visible = false;
            btnVolver.Visible = false;
            pnlVerificador.Visible = true;
            pnlUsuarios.Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            mostrarCorreos();
            pnlRestaurar.Visible = true;
            btnSalirLogin.Visible = false;
            btnVolver.Visible = true;
            pnlVerificador.Visible = false;
            pnlUsuarios.Visible = false;
        }

        private void btnSalirLogin_Click(object sender, EventArgs e)
        {
            pnlRestaurar.Visible = false;
            btnSalirLogin.Visible = false;
            btnVolver.Visible = false;
            pnlVerificador.Visible = false;
            pnlUsuarios.Visible = true;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            mostrarCorreos();
            pnlRestaurar.Visible = true;
            btnSalirLogin.Visible = true;
            btnVolver.Visible = false;
            pnlVerificador.Visible = false;
            pnlUsuarios.Visible = false;
        }

        private void espera_Tick(object sender, EventArgs e)
        {
            espera.Stop();

            try
            {
                ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
                foreach (ManagementObject getserial in MOS.Get())
                {
                    lblSerial.Text = getserial.Properties["SerialNumber"].Value.ToString();

                    mostrarCajaPorSerial();
                    try
                    {
                        lblidCaja.Text = datalistado_caja.SelectedCells[1].Value.ToString();
                        lblCaja.Text = datalistado_caja.SelectedCells[2].Value.ToString();
                        idCajaCierre.Text = lblidCaja.Text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /***************/
        /*   Botones   */
        /***************/
        private void btn1_Click(object sender, EventArgs e)
        {
            txtpassword.Text = txtpassword.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtpassword.Text = txtpassword.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtpassword.Text = txtpassword.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtpassword.Text = txtpassword.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtpassword.Text = txtpassword.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtpassword.Text = txtpassword.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtpassword.Text = txtpassword.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtpassword.Text = txtpassword.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtpassword.Text = txtpassword.Text + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtpassword.Text = txtpassword.Text + "0";
        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            txtpassword.Clear();
        }

        public static string Mid(string param, int startIndex, int length)
        {
            string result = param.Substring(startIndex, length);
            return result;
        }

        private void btnborrarderecha_Click(object sender, EventArgs e)
        {
            try
            {
                int largo;
                if (txtpassword.Text != "")
                {
                    largo = txtpassword.Text.Length;
                    txtpassword.Text = Mid(txtpassword.Text, 1, largo - 1);
                }
            }
            catch{}
        }

        private void btn_insertar_Click(object sender, EventArgs e)
        {

        }

        private void tocultar_Click(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '*';
            tver.Visible = true;
            tocultar.Visible = false;
        }

        private void tver_Click(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '\0';
            tver.Visible = false;
            tocultar.Visible = true;
        }
    }
}

