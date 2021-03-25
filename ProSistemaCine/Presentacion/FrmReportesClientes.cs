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
    public partial class FrmReportesClientes : Form
    {
        public FrmReportesClientes()
        {
            InitializeComponent();
        }

        private void FrmReportesClientes_Load(object sender, EventArgs e)
        {
            DataTable dt = new ClsNeCliente().MtdListarCliente();

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DSCine", dt));
            reportViewer1.RefreshReport();
        }
    }
}
