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
    public partial class FrmFormatos : Form
    {
        ClsNeFormato objNeFormato = new ClsNeFormato();
        ClsEnFormato objEnFormato = new ClsEnFormato();
        public FrmFormatos()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            listarTabla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objEnFormato.Nombre = txtNombre.Text;
            objEnFormato.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNeFormato.MtdAgregarFormato(objEnFormato);

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objEnFormato.Nombre = txtNombre.Text;
            objEnFormato.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNeFormato.MtdModificarFormato(objEnFormato);

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void setForm(ClsEnFormato objEnFormato)
        {
            this.objEnFormato = objEnFormato;
            txtNombre.Text = objEnFormato.Nombre;
            rdbActivo.Checked = objEnFormato.Estado == 1;
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
            dgvFormatos.DataSource = objNeFormato.MtdListarFormato();
            setFormState(FormState.Listar);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            setForm(new ClsEnFormato());
            setFormState(FormState.Nuevo);
        }

        private void dgvFormatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dgvFormatos.Rows[e.RowIndex].Cells[0].Value.ToString());

            setForm(objNeFormato.MtdObtenerFormato(id));
            setFormState(FormState.Modificando);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvFormatos.DataSource = objNeFormato.MtdBuscarFormato(txtBuscar.Text);
            setFormState(FormState.Buscar);
        }

    }
}
