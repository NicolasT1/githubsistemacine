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
    public partial class FrmReportesTotalVentasMes : Form
    {
        public FrmReportesTotalVentasMes()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable dt = new ClsNeVenta().MtdObtenerTotalVentaMes(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);

            ReportParameter[] rptParametros = new ReportParameter[]{
                new ReportParameter("anio", dateTimePicker1.Value.Year.ToString()),
                new ReportParameter("mes", dateTimePicker1.Value.ToString("MMMM"))
            };

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.SetParameters(rptParametros);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DSTVMes", dt));
            reportViewer1.RefreshReport();
        }

        private void FrmReportesTotalVentasMes_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
