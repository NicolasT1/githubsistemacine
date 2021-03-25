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
    public partial class FrmReportesUsuarios : Form
    {
        public FrmReportesUsuarios()
        {
            InitializeComponent();
        }

        private void FrmReportesUsuarios_Load(object sender, EventArgs e)
        {
            DataTable dt = new ClsNeUsuario().MtdListarUsuario();

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DSUsuarios", dt));
            reportViewer1.RefreshReport();
        }
    }
}
