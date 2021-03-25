using ProSistemaCine.Entidad;
using ProSistemaCine.Negocio;
using ProSistemaCine.Utilidades;
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
    public partial class FrmTarifas : Form
    {
        ClsNeTarifa objNeTarifa = new ClsNeTarifa();
        ClsEnTarifa objEnTarifa = new ClsEnTarifa();
        public FrmTarifas()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            listarTabla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objEnTarifa.Dia = cmbDias.Text;
            objEnTarifa.Tipo = rdb2D.Checked ? "2D" : "3D";
            objEnTarifa.Precio_general = Decimal.Parse(txtPrecio_general.Text);
            objEnTarifa.Precio_ninos = Decimal.Parse(txtPrecio_ninos.Text);
            objEnTarifa.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNeTarifa.MtdAgregarTarifa(objEnTarifa);

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objEnTarifa.Dia = cmbDias.Text;
            objEnTarifa.Tipo = rdb2D.Checked ? "2D" : "3D";
            objEnTarifa.Precio_general = Decimal.Parse(txtPrecio_general.Text);
            objEnTarifa.Precio_ninos = Decimal.Parse(txtPrecio_ninos.Text);
            objEnTarifa.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNeTarifa.MtdModificarTarifa(objEnTarifa);

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void setForm(ClsEnTarifa objEnTarifa)
        {
            this.objEnTarifa = objEnTarifa;
            cmbDias.Text = objEnTarifa.Dia;
            rdb2D.Checked = objEnTarifa.Tipo == "2D";
            txtPrecio_general.Text = "" + objEnTarifa.Precio_general;
            txtPrecio_ninos.Text = "" + objEnTarifa.Precio_ninos;
            rdbActivo.Checked = objEnTarifa.Estado == 1;
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
            dgvTarifas.DataSource = objNeTarifa.MtdListarTarifa();
            setFormState(FormState.Listar);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            setForm(new ClsEnTarifa());
            setFormState(FormState.Nuevo);
        }

        private void dgvTarifas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dgvTarifas.Rows[e.RowIndex].Cells[0].Value.ToString());

            setForm(objNeTarifa.MtdObtenerTarifa(id));
            setFormState(FormState.Modificando);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvTarifas.DataSource = objNeTarifa.MtdBuscarTarifa(txtBuscar.Text);
            setFormState(FormState.Buscar);
        }
    }
}
