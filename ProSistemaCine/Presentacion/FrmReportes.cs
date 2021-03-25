using Microsoft.Reporting.WinForms;
using ProSistemaCine.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProSistemaCine.Presentacion
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {

        }

        private void btnRptClientes_Click(object sender, EventArgs e)
        {
            FrmReportesClientes frm = new FrmReportesClientes();
            frm.Show();
        }

        private void btnRptPeliculas_Click(object sender, EventArgs e)
        {
            FrmReportesPeliculas frm = new FrmReportesPeliculas();
            frm.Show();
        }

        private void btnRptUsuarios_Click(object sender, EventArgs e)
        {
            FrmReportesUsuarios frm = new FrmReportesUsuarios();
            frm.Show();
        }
        
        private void btnRptTVDia_Click(object sender, EventArgs e)
        {
            FrmReportesTotalVentasDia frm = new FrmReportesTotalVentasDia();
            frm.Show();
        }

        private void btnRptTVSemana_Click(object sender, EventArgs e)
        {
            FrmReportesTotalVentasSemana frm = new FrmReportesTotalVentasSemana();
            frm.Show();
        }

        private void btnRptTVMes_Click(object sender, EventArgs e)
        {
            FrmReportesTotalVentasMes frm = new FrmReportesTotalVentasMes();
            frm.Show();
        }

        private void btnRptTVAnio_Click(object sender, EventArgs e)
        {
            FrmReportesTotalVentasAnio frm = new FrmReportesTotalVentasAnio();
            frm.Show();
        }
    }
}
