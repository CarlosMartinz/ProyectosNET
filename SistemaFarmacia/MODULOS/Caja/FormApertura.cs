using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;

namespace SistemaFarmacia.MODULOS.Caja
{
    public partial class FormApertura : Form
    {
        public FormApertura()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Data.db_conexion.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("DineroInicial", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCaja", lbliCaja.Text);
                cmd.Parameters.AddWithValue("@saldo", txtDineroCaja.Text);

                cmd.ExecuteNonQuery();
                con.Close();

                this.Hide();
                FormPrincipal frm = new FormPrincipal();
                frm.ShowDialog();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
                da.SelectCommand.Parameters.AddWithValue("@Serial", lblSerialPC.Text);
                da.Fill(dt);
                dataListar.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }


        private void FormApertura_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CO");
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = ",";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = ",";
            ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
            foreach (ManagementObject getserial in MOS.Get())
            {
                lblSerialPC.Text = getserial.Properties["SerialNumber"].Value.ToString();
                mostrarCajaPorSerial();
                try
                {
                    lbliCaja.Text = dataListar.Rows[0].Cells[0].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Data.db_conexion.conexion;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("DineroInicial", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCaja", lbliCaja.Text);
                cmd.Parameters.AddWithValue("@saldo", 0);

                cmd.ExecuteNonQuery();
                con.Close();

                this.Hide();
                FormPrincipal frm = new FormPrincipal();
                frm.ShowDialog();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtDineroCaja.Text = txtDineroCaja.Text + "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtDineroCaja.Text = txtDineroCaja.Text + "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtDineroCaja.Text = txtDineroCaja.Text + "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtDineroCaja.Text = txtDineroCaja.Text + "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtDineroCaja.Text = txtDineroCaja.Text + "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtDineroCaja.Text = txtDineroCaja.Text + "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtDineroCaja.Text = txtDineroCaja.Text + "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtDineroCaja.Text = txtDineroCaja.Text + "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtDineroCaja.Text = txtDineroCaja.Text + "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtDineroCaja.Text = txtDineroCaja.Text + "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtDineroCaja.Text = txtDineroCaja.Text + ".";
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
                if (txtDineroCaja.Text != "")
                {
                    largo = txtDineroCaja.Text.Length;
                    txtDineroCaja.Text = Mid(txtDineroCaja.Text, 1, largo - 1);
                }
            }
            catch { }
        }

        private void btnborrartodo_Click(object sender, EventArgs e)
        {
            txtDineroCaja.Clear();
        }
    }
}
