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
    public partial class FrmReportesTotalVentasDia : Form
    {
        public FrmReportesTotalVentasDia()
        {
            InitializeComponent();
        }

        private void FrmReportesTotalVentasDia_Load(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt = new ClsNeVenta().MtdObtenerTotalVentaDia(dateTimePicker1.Value.ToShortDateString());

            ReportParameter[] rptParametros = new ReportParameter[]{
                new ReportParameter("fecha", dateTimePicker1.Value.ToShortDateString())
            };

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.SetParameters(rptParametros);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DSTVDia", dt));
            reportViewer1.RefreshReport();
        }
    }
}
