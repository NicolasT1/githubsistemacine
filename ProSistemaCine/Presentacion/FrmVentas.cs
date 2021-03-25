using ProSistemaCine.Entidad;
using ProSistemaCine.Negocio;
using ProSistemaCine.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProSistemaCine.Presentacion.FrmLogin;
using static ProSistemaCine.Utilidades.ControlButacas;

namespace ProSistemaCine.Presentacion
{
    public partial class FrmVentas : Form
    {
        ClsNeVenta objNeVenta = new ClsNeVenta();
        ClsEnVenta objEnVenta = new ClsEnVenta();
        ClsNeDetalleVenta objNeDetalleVenta = new ClsNeDetalleVenta();
        
        ClsNeCliente objNeCliente = new ClsNeCliente();
        ClsNePelicula objNePelicula = new ClsNePelicula();

        ClsNeFuncion objNeFuncion = new ClsNeFuncion();
        ClsNeButaca objNeButaca = new ClsNeButaca();

        ControlButacas ctrButacas = new ControlButacas();

        public FrmVentas()
        {
            InitializeComponent();

            loadCmbClientes();
            loadCmbPeliculas();

            ctrButacas.Contenedor = flowLayoutPanel1;
            ctrButacas.Click += new ButacaEventHandler(btnButacas_Click);

            txtSessionUsuario.Text = Session.Usuario.Usuario;
            txtSessionRol.Text = Session.Usuario.Rol;

            ///######## TEMPORAL ############
            btnModificar.Enabled = false;
            ///##############################
        }

        private void btnButacas_Click(List<ClsEnButaca> SelectedButacas)
        {
            txtCantidad.Text = SelectedButacas.Count.ToString();
            lblButacasSeleccionadas.Text = string.Join<String>(",", SelectedButacas.Select(x => ctrButacas.getLetra(x.Fila) + x.Columna).Cast<String>().ToArray());
        }

        private void loadCmbClientes()
        {
            cmbClientes.DataSource = objNeCliente.MtdListarCliente();
            cmbClientes.DisplayMember = "dni";
            cmbClientes.ValueMember = "id";
        }
        private void loadCmbPeliculas()
        {
            cmbPeliculas.DataSource = objNePelicula.MtdListarPelicula();
            cmbPeliculas.DisplayMember = "Nombre";
            cmbPeliculas.ValueMember = "Id";
        }
        private void loadCmbIdiomas(int Idioma_dob, int Idioma_sub)
        {
            cmbIdiomas.Items.Clear();

            if (Idioma_dob == 1)
            {
                cmbIdiomas.Items.Add("DOB");
            }

            if (Idioma_sub == 1)
            {
                cmbIdiomas.Items.Add("SUB");
            }
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            listarTabla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objEnVenta.Usuario_id = Session.Usuario.Id;
            objEnVenta.Cliente_id = Int32.Parse(cmbClientes.SelectedValue.ToString());
            objEnVenta.Funcion_id = Int32.Parse(dgvFuncionesDisponibles.CurrentRow.Cells["id"].Value.ToString());
            objEnVenta.Fecha = dtpFecha.Value.ToShortDateString();
            objEnVenta.Cantidad = Int32.Parse(txtCantidad.Text);
            objEnVenta.Cantidad_general = Int32.Parse(txtCantidad_general.Text);
            objEnVenta.Cantidad_ninos = Int32.Parse(txtCantidad_ninos.Text);
            objEnVenta.Precio_general = Decimal.Parse(txtPrecio_general.Text);
            objEnVenta.Precio_ninos = Decimal.Parse(txtPrecio_ninos.Text);
            objEnVenta.Precio_total = Decimal.Parse(txtPrecio_total.Text);

            objEnVenta.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNeVenta.MtdAgregarVenta(objEnVenta);
            
            foreach (ClsEnButaca butaca in ctrButacas.SelectedButacas)
            {
                ClsEnDetalleVenta objEnDetalleVenta = new ClsEnDetalleVenta();

                objEnDetalleVenta.Venta_id = objEnVenta.Id;
                objEnDetalleVenta.Butaca_id = butaca.Id;

                objNeDetalleVenta.MtdAgregarDetalleVenta(objEnDetalleVenta);
            }
            
            MessageBox.Show(rpt);

            imprimirVenta();
            listarTabla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objEnVenta.Usuario_id = Session.Usuario.Id;
            objEnVenta.Cliente_id = Int32.Parse(cmbClientes.SelectedValue.ToString());
            objEnVenta.Funcion_id = Int32.Parse(dgvFuncionesDisponibles.CurrentRow.Cells["id"].Value.ToString());
            objEnVenta.Fecha = dtpFecha.Value.ToShortDateString();
            objEnVenta.Cantidad = Int32.Parse(txtCantidad.Text);
            objEnVenta.Cantidad_general = Int32.Parse(txtCantidad_general.Text);
            objEnVenta.Cantidad_ninos = Int32.Parse(txtCantidad_ninos.Text);
            objEnVenta.Precio_general = Decimal.Parse(txtPrecio_general.Text);
            objEnVenta.Precio_ninos = Decimal.Parse(txtPrecio_ninos.Text);
            objEnVenta.Precio_total = Decimal.Parse(txtPrecio_total.Text);

            string rpt = objNeVenta.MtdModificarVenta(objEnVenta);

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void setForm(ClsEnVenta objEnVenta)
        {
            this.objEnVenta = objEnVenta;

            cmbClientes.SelectedValue = objEnVenta.Cliente_id;
            //txtFuncion_id.Text = objEnVenta.Funcion_id;
            dtpFecha.Value = objEnVenta.Fecha == null ? DateTime.Now: DateTime.Parse(objEnVenta.Fecha);
            txtCantidad.Text = "" + objEnVenta.Cantidad;
            txtCantidad_general.Text = "" + objEnVenta.Cantidad_general;
            txtCantidad_ninos.Text = "" + objEnVenta.Cantidad_ninos;
            txtPrecio_general.Text = "" + objEnVenta.Precio_general;
            txtPrecio_ninos.Text = "" + objEnVenta.Precio_ninos;
            txtPrecio_total.Text = "" + objEnVenta.Precio_total;

            rdbActivo.Checked = objEnVenta.Estado == 1;
        }


        private void setFormState(FormState estado)
        {
            switch (estado)
            {
                case FormState.Nuevo:
                    btnNuevo.Enabled = false;
                    btnListar.Enabled = true;
                    btnGuardar.Enabled = true;
                    btnModificar.Enabled = false;
                    break;
                case FormState.Listar:
                case FormState.Buscar:
                case FormState.Guardar:
                case FormState.Modificar:
                    btnNuevo.Enabled = true;
                    btnListar.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnModificar.Enabled = false;
                    break;
                case FormState.Modificando:
                    btnNuevo.Enabled = true;
                    btnListar.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnModificar.Enabled = true;
                    break;
            }
        }

        private void listarTabla()
        {
            //dgvVentas.DataSource = objNeVenta.MtdListarVenta();
            setFormState(FormState.Listar);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            setForm(new ClsEnVenta());
            setFormState(FormState.Nuevo);
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            int id = Int32.Parse(dgvVentas.Rows[e.RowIndex].Cells[0].Value.ToString());

            setForm(objNeVenta.MtdObtenerVenta(id));
            setFormState(FormState.Modificando);
            */
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView row = cmbClientes.SelectedItem as DataRowView;
            if (row == null)
            {
                txtClienteNombre.Text = "-";
                txtClienteTipo.Text = "-";
            }
            else
            {
                txtClienteNombre.Text = row["nombres"].ToString() + " " + row["apellidos"].ToString();
                txtClienteTipo.Text = row["tipo"].ToString() == "1" ? "Frecuente" : "No Frecuente";
            }
        }

        private void cmbPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView row = cmbPeliculas.SelectedItem as DataRowView;
            if (row == null)
            {
                loadCmbIdiomas(0, 0);
            }
            else
            {
                int pelicula_id = Int32.Parse(row["id"].ToString());
                int idioma_dob = Int32.Parse(row["idioma_dob"].ToString());
                int idioma_sub = Int32.Parse(row["idioma_sub"].ToString());

                //loadCmbSalas(null);
                loadCmbIdiomas(idioma_dob, idioma_sub);
            }
        }

        private void cmbIdiomas_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarTablaFuncionesDisponibles();
        }

        private void listarTablaFuncionesDisponibles()
        {
            DataRowView row = cmbPeliculas.SelectedItem as DataRowView;
            if (row == null) return;
            int pelicula_id = Int32.Parse(row["id"].ToString());

            dgvFuncionesDisponibles.DataSource = objNeFuncion.MtdFiltrarFuncion(pelicula_id, dtpFecha.Value.ToShortDateString(), cmbIdiomas.Text);
            dgvFuncionesDisponibles.Columns["id"].Visible = false;
            dgvFuncionesDisponibles.Columns["sala_id"].Visible = false;
            dgvFuncionesDisponibles.Columns["precio_general"].Visible = false;
            dgvFuncionesDisponibles.Columns["precio_ninos"].Visible = false;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            listarTablaFuncionesDisponibles();
        }

        private void dgvFuncionesDisponibles_SelectionChanged(object sender, EventArgs e)
        {
            var row = dgvFuncionesDisponibles.CurrentRow;

            int funcion_id = Int32.Parse(row.Cells["id"].Value.ToString());

            txtPrecio_general.Text = row.Cells["precio_general"].Value.ToString();
            txtPrecio_ninos.Text = row.Cells["precio_ninos"].Value.ToString();

            Cursor.Current = Cursors.WaitCursor;
            ctrButacas.SelectedButacas = new List<ClsEnButaca>() {};
            ctrButacas.Butacas = objNeButaca.MtdListarButacaFunciones(funcion_id, dtpFecha.Value.ToShortDateString());
            ctrButacas.renderButacas();
            Cursor.Current = Cursors.Default;
        }
        private void calcularTotal()
        {
            decimal Precio_general = Decimal.Parse(txtPrecio_general.Text);
            int Cantidad_general = Int32.Parse(txtCantidad_general.Value.ToString());

            decimal Precio_ninos = Decimal.Parse(txtPrecio_ninos.Text);
            int Cantidad_ninos = Int32.Parse(txtCantidad_ninos.Value.ToString());

            decimal Total = (Precio_general * Cantidad_general) + (Precio_ninos * Cantidad_ninos);

            txtPrecio_total.Text = Total.ToString();
        }
        private void txtCantidad_general_ValueChanged(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void txtCantidad_ninos_ValueChanged(object sender, EventArgs e)
        {
            calcularTotal();
        }

        private void imprimirVenta()
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("PaperA6", 600, 500);
            pd.PrintPage += new PrintPageEventHandler(this.doc_PrintPage);

            PrintDialog printdlg = new PrintDialog();
            PrintPreviewDialog printPrvDlg = new PrintPreviewDialog();

            printPrvDlg.Document = pd;
            printPrvDlg.ShowDialog();

            printdlg.Document = pd;

            if (printdlg.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Single leftMargin = e.MarginBounds.Left;
            Single topMargin = e.MarginBounds.Top;

            Single yPos = topMargin + 10;

            using (Font printFont = new Font("Consolas", 12))
            {
                e.Graphics.DrawString(cmbPeliculas.Text + " [" + cmbIdiomas.Text + "][" + dgvFuncionesDisponibles.CurrentRow.Cells["tipo"].Value.ToString() + "]", printFont, Brushes.Black, leftMargin+40, yPos, new StringFormat());
                yPos += 25;
                e.Graphics.DrawString(dgvFuncionesDisponibles.CurrentRow.Cells["sala"].Value.ToString() + "   FUNCION: " + objEnVenta.Fecha + " " + dgvFuncionesDisponibles.CurrentRow.Cells["hora"].Value.ToString(), printFont, Brushes.Black, leftMargin, yPos);
                yPos += 25;
                e.Graphics.DrawString("TOTAL ENTRADAS " + txtCantidad.Text, printFont, Brushes.Black, leftMargin + 70, yPos);
                yPos += 25;
                e.Graphics.DrawString(txtClienteNombre.Text, printFont, Brushes.Black, leftMargin + 70, yPos);
                yPos += 35;
                e.Graphics.DrawString("Boleta: " + objEnVenta.Id, printFont, Brushes.Black, leftMargin, yPos);
                e.Graphics.DrawString("Cajero: " + Session.Usuario.Usuario, printFont, Brushes.Black, leftMargin + 150, yPos);
                yPos += 33;
                e.Graphics.DrawString("Butaca: " + lblButacasSeleccionadas.Text, printFont, Brushes.Black, leftMargin, yPos);
                yPos += 33;
                e.Graphics.DrawString("Precio Total: S/" + txtPrecio_total.Text, printFont, Brushes.Black, leftMargin + 150, yPos);
                yPos += 33;
                e.Graphics.DrawString("Fecha: " + DateTime.Now, printFont, Brushes.Black, leftMargin + 70, yPos);
            }

        }
    }
}
