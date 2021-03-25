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
    public partial class FrmGeneros : Form
    {
        ClsNeGenero objNeGenero = new ClsNeGenero();
        ClsEnGenero objEnGenero = new ClsEnGenero();
        public FrmGeneros()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            listarTabla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objEnGenero.Nombre = txtNombre.Text;
            objEnGenero.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNeGenero.MtdAgregarGenero(objEnGenero);

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objEnGenero.Nombre = txtNombre.Text;
            objEnGenero.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNeGenero.MtdModificarGenero(objEnGenero);

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void setForm(ClsEnGenero objEnGenero)
        {
            this.objEnGenero = objEnGenero;
            txtNombre.Text = objEnGenero.Nombre;

            rdbActivo.Checked = objEnGenero.Estado == 1;
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
            dgvGeneros.DataSource = objNeGenero.MtdListarGenero();
            setFormState(FormState.Listar);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            setForm(new ClsEnGenero());
            setFormState(FormState.Nuevo);
        }

        private void dgvGeneros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dgvGeneros.Rows[e.RowIndex].Cells[0].Value.ToString());

            setForm(objNeGenero.MtdObtenerGenero(id));
            setFormState(FormState.Modificando);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvGeneros.DataSource = objNeGenero.MtdBuscarGenero(txtBuscar.Text);
            setFormState(FormState.Buscar);
        }
    }
}
