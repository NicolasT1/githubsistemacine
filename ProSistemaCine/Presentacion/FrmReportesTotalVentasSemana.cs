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
    public partial class FrmReportesTotalVentasSemana : Form
    {
        public FrmReportesTotalVentasSemana()
        {
            InitializeComponent();

            mcSemana.MaxDate = DateTime.Now;
        }

        private void FrmReportesTotalVentasSemana_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void mcSemana_DateChanged(object sender, DateRangeEventArgs e)
        {
            DataTable dt = new ClsNeVenta().MtdObtenerTotalVentaSemana(e.Start.ToShortDateString(), e.End.ToShortDateString());

            ReportParameter[] rptParametros = new ReportParameter[]{
                new ReportParameter("fecha_inicio", e.Start.ToShortDateString()),
                new ReportParameter("fecha_fin", e.End.ToShortDateString())
            };

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.SetParameters(rptParametros);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DSTVSemana", dt));
            reportViewer1.RefreshReport();
        }

        private void mcSemana_DateSelected(object sender, DateRangeEventArgs e)
        {
            mcSemana.SelectionRange = new SelectionRange(e.Start, e.Start.AddDays(-6));
        }
    }
}
