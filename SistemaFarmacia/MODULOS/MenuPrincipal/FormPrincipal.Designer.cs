
namespace SistemaFarmacia.MODULOS
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.pnlinformacion = new System.Windows.Forms.Panel();
            this.BtnCerrar_turno = new System.Windows.Forms.Button();
            this.Panel17 = new System.Windows.Forms.Panel();
            this.dtempresaok = new System.Windows.Forms.DataGridView();
            this.DataGridViewCheckBoxColumn7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Panel14 = new System.Windows.Forms.Panel();
            this.LBLnotificaciones = new System.Windows.Forms.Label();
            this.PictureBox18 = new System.Windows.Forms.PictureBox();
            this.ImagenEmpresaTRUE = new System.Windows.Forms.PictureBox();
            this.MenuStrip5 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem22 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip6 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem23 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarTurnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtempresaok)).BeginInit();
            this.Panel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenEmpresaTRUE)).BeginInit();
            this.MenuStrip5.SuspendLayout();
            this.MenuStrip6.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlinformacion
            // 
            this.pnlinformacion.BackColor = System.Drawing.Color.White;
            this.pnlinformacion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlinformacion.Location = new System.Drawing.Point(0, 337);
            this.pnlinformacion.Name = "pnlinformacion";
            this.pnlinformacion.Size = new System.Drawing.Size(796, 44);
            this.pnlinformacion.TabIndex = 5;
            // 
            // BtnCerrar_turno
            // 
            this.BtnCerrar_turno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCerrar_turno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(1)))));
            this.BtnCerrar_turno.FlatAppearance.BorderSize = 0;
            this.BtnCerrar_turno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar_turno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCerrar_turno.Location = new System.Drawing.Point(3, 7);
            this.BtnCerrar_turno.Name = "BtnCerrar_turno";
            this.BtnCerrar_turno.Size = new System.Drawing.Size(142, 37);
            this.BtnCerrar_turno.TabIndex = 601;
            this.BtnCerrar_turno.Text = "Cerrar Turno";
            this.BtnCerrar_turno.UseVisualStyleBackColor = false;
            this.BtnCerrar_turno.Click += new System.EventHandler(this.BtnCerrar_turno_Click);
            // 
            // Panel17
            // 
            this.Panel17.BackColor = System.Drawing.Color.White;
            this.Panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel17.Controls.Add(this.dtempresaok);
            this.Panel17.Controls.Add(this.Panel14);
            this.Panel17.Controls.Add(this.menuStrip1);
            this.Panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel17.Location = new System.Drawing.Point(0, 0);
            this.Panel17.Name = "Panel17";
            this.Panel17.Size = new System.Drawing.Size(796, 52);
            this.Panel17.TabIndex = 509;
            // 
            // dtempresaok
            // 
            this.dtempresaok.AllowUserToAddRows = false;
            this.dtempresaok.AllowUserToDeleteRows = false;
            this.dtempresaok.BackgroundColor = System.Drawing.Color.White;
            this.dtempresaok.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtempresaok.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dtempresaok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtempresaok.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewCheckBoxColumn7});
            this.dtempresaok.EnableHeadersVisualStyles = false;
            this.dtempresaok.Location = new System.Drawing.Point(845, 52);
            this.dtempresaok.Name = "dtempresaok";
            this.dtempresaok.ReadOnly = true;
            this.dtempresaok.RowHeadersVisible = false;
            this.dtempresaok.RowHeadersWidth = 5;
            this.dtempresaok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtempresaok.Size = new System.Drawing.Size(27, 20);
            this.dtempresaok.TabIndex = 584;
            // 
            // DataGridViewCheckBoxColumn7
            // 
            this.DataGridViewCheckBoxColumn7.DataPropertyName = "Activo";
            this.DataGridViewCheckBoxColumn7.HeaderText = "Activo";
            this.DataGridViewCheckBoxColumn7.Name = "DataGridViewCheckBoxColumn7";
            this.DataGridViewCheckBoxColumn7.ReadOnly = true;
            this.DataGridViewCheckBoxColumn7.Visible = false;
            // 
            // Panel14
            // 
            this.Panel14.BackColor = System.Drawing.Color.Transparent;
            this.Panel14.Controls.Add(this.BtnCerrar_turno);
            this.Panel14.Controls.Add(this.LBLnotificaciones);
            this.Panel14.Controls.Add(this.PictureBox18);
            this.Panel14.Controls.Add(this.ImagenEmpresaTRUE);
            this.Panel14.Controls.Add(this.MenuStrip5);
            this.Panel14.Controls.Add(this.MenuStrip6);
            this.Panel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.Panel14.Location = new System.Drawing.Point(476, 0);
            this.Panel14.Name = "Panel14";
            this.Panel14.Size = new System.Drawing.Size(318, 50);
            this.Panel14.TabIndex = 599;
            // 
            // LBLnotificaciones
            // 
            this.LBLnotificaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LBLnotificaciones.AutoSize = true;
            this.LBLnotificaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(63)))), ((int)(((byte)(67)))));
            this.LBLnotificaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.LBLnotificaciones.ForeColor = System.Drawing.Color.White;
            this.LBLnotificaciones.Location = new System.Drawing.Point(247, 6);
            this.LBLnotificaciones.Name = "LBLnotificaciones";
            this.LBLnotificaciones.Size = new System.Drawing.Size(13, 13);
            this.LBLnotificaciones.TabIndex = 599;
            this.LBLnotificaciones.Text = "0";
            this.LBLnotificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBLnotificaciones.Visible = false;
            // 
            // PictureBox18
            // 
            this.PictureBox18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox18.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox18.Image")));
            this.PictureBox18.Location = new System.Drawing.Point(235, 13);
            this.PictureBox18.Name = "PictureBox18";
            this.PictureBox18.Size = new System.Drawing.Size(27, 24);
            this.PictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox18.TabIndex = 592;
            this.PictureBox18.TabStop = false;
            // 
            // ImagenEmpresaTRUE
            // 
            this.ImagenEmpresaTRUE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagenEmpresaTRUE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImagenEmpresaTRUE.Location = new System.Drawing.Point(268, 6);
            this.ImagenEmpresaTRUE.Name = "ImagenEmpresaTRUE";
            this.ImagenEmpresaTRUE.Size = new System.Drawing.Size(41, 34);
            this.ImagenEmpresaTRUE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagenEmpresaTRUE.TabIndex = 598;
            this.ImagenEmpresaTRUE.TabStop = false;
            // 
            // MenuStrip5
            // 
            this.MenuStrip5.AutoSize = false;
            this.MenuStrip5.BackColor = System.Drawing.Color.Transparent;
            this.MenuStrip5.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem22});
            this.MenuStrip5.Location = new System.Drawing.Point(193, 9);
            this.MenuStrip5.Name = "MenuStrip5";
            this.MenuStrip5.Size = new System.Drawing.Size(42, 31);
            this.MenuStrip5.TabIndex = 591;
            this.MenuStrip5.Text = "MenuStrip5";
            // 
            // ToolStripMenuItem22
            // 
            this.ToolStripMenuItem22.BackColor = System.Drawing.Color.Transparent;
            this.ToolStripMenuItem22.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolStripMenuItem22.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItem22.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem22.Image")));
            this.ToolStripMenuItem22.Name = "ToolStripMenuItem22";
            this.ToolStripMenuItem22.Size = new System.Drawing.Size(28, 27);
            this.ToolStripMenuItem22.Text = "ToolStripMenuItem16";
            // 
            // MenuStrip6
            // 
            this.MenuStrip6.AutoSize = false;
            this.MenuStrip6.BackColor = System.Drawing.Color.Transparent;
            this.MenuStrip6.Dock = System.Windows.Forms.DockStyle.None;
            this.MenuStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem23});
            this.MenuStrip6.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.MenuStrip6.Location = new System.Drawing.Point(162, 9);
            this.MenuStrip6.Name = "MenuStrip6";
            this.MenuStrip6.ShowItemToolTips = true;
            this.MenuStrip6.Size = new System.Drawing.Size(34, 31);
            this.MenuStrip6.TabIndex = 593;
            this.MenuStrip6.Text = "MenuStrip6";
            // 
            // ToolStripMenuItem23
            // 
            this.ToolStripMenuItem23.BackColor = System.Drawing.Color.Transparent;
            this.ToolStripMenuItem23.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.ToolStripMenuItem23.ForeColor = System.Drawing.Color.Black;
            this.ToolStripMenuItem23.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripMenuItem23.Image")));
            this.ToolStripMenuItem23.Name = "ToolStripMenuItem23";
            this.ToolStripMenuItem23.Size = new System.Drawing.Size(28, 27);
            this.ToolStripMenuItem23.ToolTipText = "Configuracion";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, -1);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(236, 52);
            this.menuStrip1.TabIndex = 600;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarTurnoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.archivoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("archivoToolStripMenuItem.Image")));
            this.archivoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(99, 48);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // cerrarTurnoToolStripMenuItem
            // 
            this.cerrarTurnoToolStripMenuItem.Name = "cerrarTurnoToolStripMenuItem";
            this.cerrarTurnoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cerrarTurnoToolStripMenuItem.Text = "Cerrar turno";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click_2);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(796, 381);
            this.Controls.Add(this.Panel17);
            this.Controls.Add(this.pnlinformacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPrincipal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.Panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtempresaok)).EndInit();
            this.Panel14.ResumeLayout(false);
            this.Panel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenEmpresaTRUE)).EndInit();
            this.MenuStrip5.ResumeLayout(false);
            this.MenuStrip5.PerformLayout();
            this.MenuStrip6.ResumeLayout(false);
            this.MenuStrip6.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlinformacion;
        internal System.Windows.Forms.Button BtnCerrar_turno;
        internal System.Windows.Forms.Panel Panel17;
        public System.Windows.Forms.DataGridView dtempresaok;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn DataGridViewCheckBoxColumn7;
        internal System.Windows.Forms.Panel Panel14;
        internal System.Windows.Forms.Label LBLnotificaciones;
        internal System.Windows.Forms.PictureBox PictureBox18;
        internal System.Windows.Forms.PictureBox ImagenEmpresaTRUE;
        internal System.Windows.Forms.MenuStrip MenuStrip5;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem22;
        internal System.Windows.Forms.MenuStrip MenuStrip6;
        internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem23;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarTurnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}