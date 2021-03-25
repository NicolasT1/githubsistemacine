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
    public partial class FrmReportesTotalVentasAnio : Form
    {
        public FrmReportesTotalVentasAnio()
        {
            InitializeComponent();
        }

        private void FrmReportesTotalVentasAnio_Load(object sender, EventArgs e)
        {
        }

        private void cmbAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new ClsNeVenta().MtdObtenerTotalVentaAnio(Int32.Parse(cmbAnios.Text));

            ReportParameter[] rptParametros = new ReportParameter[]{
                new ReportParameter("anio", cmbAnios.Text)
            };

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.SetParameters(rptParametros);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DSTVAnio", dt));
            reportViewer1.RefreshReport();
        }
    }
}
