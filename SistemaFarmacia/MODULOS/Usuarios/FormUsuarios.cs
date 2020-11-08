using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
             
        }
    }
}
