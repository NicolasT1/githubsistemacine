using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ProSistemaCine.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            abrirFrm(new FrmUsuarios());
        }

        private void FrmPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Console.WriteLine("click2?");
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            FrmPrincipal.ActiveForm.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            FrmPrincipal.ActiveForm.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            abrirFrm(new FrmClientes());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            abrirFrm(new FrmGeneros());
        }

        private void abrirFrm(Form frm)
        {
            panelContenedor.Controls.Clear();

            frm.TopLevel = false;
            frm.AutoScroll = true;
            panelContenedor.Controls.Add(frm);
            frm.Show();
        }

        private void btnFormatos_Click(object sender, EventArgs e)
        {
            abrirFrm(new FrmFormatos());
        }

        private void btnEmpresa_Click(object sender, EventArgs e)
        {
            abrirFrm(new FrmSalas());
        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            abrirFrm(new FrmPeliculas());
        }

        private void btnFunciones_Click(object sender, EventArgs e)
        {
            abrirFrm(new FrmFunciones());
        }

        private void btnTarifas_Click(object sender, EventArgs e)
        {
            abrirFrm(new FrmTarifas());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            abrirFrm(new FrmVentas());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            abrirFrm(new FrmReportes());
        }
    }
}
