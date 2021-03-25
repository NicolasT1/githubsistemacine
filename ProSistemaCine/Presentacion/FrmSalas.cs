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
    public partial class FrmSalas : Form
    {
        ClsNeSala objNeSala = new ClsNeSala();
        ClsEnSala objEnSala = new ClsEnSala();

        ClsNeFormato objNeFormato = new ClsNeFormato();
        ClsNeButaca obNeButaca = new ClsNeButaca();

        List<ClsEnButaca> butacas = new List<ClsEnButaca>();
        public FrmSalas()
        {
            InitializeComponent();

            loadCmbFormatos();
        }

        private void loadCmbFormatos()
        {
            cmbFormatos.DataSource = objNeFormato.MtdListarFormato();
            cmbFormatos.DisplayMember = "Nombre";
            cmbFormatos.ValueMember = "Id";
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            listarTabla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objEnSala.Formato_id = Int32.Parse(cmbFormatos.SelectedValue.ToString());
            objEnSala.Tipo = rdb2D.Checked ? "2D" : "3D";
            objEnSala.Nombre = txtNombre.Text;
            objEnSala.Capacidad = Int32.Parse(txtCapacidad.Text);
            objEnSala.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNeSala.MtdAgregarSala(objEnSala);

            foreach(ClsEnButaca butaca in butacas)
            {
                butaca.Sala_id = objEnSala.Id;

                obNeButaca.MtdAgregarButaca(butaca);
            }

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objEnSala.Formato_id = Int32.Parse(cmbFormatos.SelectedValue.ToString());
            objEnSala.Tipo = rdb2D.Checked ? "2D" : "3D";
            objEnSala.Nombre = txtNombre.Text;
            objEnSala.Capacidad = Int32.Parse(txtCapacidad.Text);
            objEnSala.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNeSala.MtdModificarSala(objEnSala);

            obNeButaca.MtdEliminarButacaBySala(objEnSala.Id);

            foreach (ClsEnButaca butaca in butacas)
            {
                butaca.Sala_id = objEnSala.Id;

                obNeButaca.MtdAgregarButaca(butaca);
            }

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void setForm(ClsEnSala objEnSala)
        {
            this.objEnSala = objEnSala;
            cmbFormatos.SelectedValue = objEnSala.Formato_id;
            txtNombre.Text = objEnSala.Nombre;
            txtCapacidad.Text = "" + objEnSala.Capacidad;

            rdbActivo.Checked = objEnSala.Estado == 1;
            rdb2D.Checked = objEnSala.Tipo == "2D";

            butacas = obNeButaca.MtdObtenerButacaBySala(objEnSala.Id);
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
            dgvSalas.DataSource = objNeSala.MtdListarSala();
            setFormState(FormState.Listar);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            setForm(new ClsEnSala());
            setFormState(FormState.Nuevo);
        }

        private void dgvSalas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dgvSalas.Rows[e.RowIndex].Cells[0].Value.ToString());

            setForm(objNeSala.MtdObtenerSala(id));
            setFormState(FormState.Modificando);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvSalas.DataSource = objNeSala.MtdBuscarSala(txtBuscar.Text);
            setFormState(FormState.Buscar);
        }

        private void btnVerButacas_Click(object sender, EventArgs e)
        {
            FrmButacas frm = new FrmButacas();

            frm.ctrButacas.SelectedButacas = butacas;
            frm.ctrButacas.renderButacas();

            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                frm.Close();
            }
            else if (dr == DialogResult.OK)
            {
                butacas = frm.ctrButacas.SelectedButacas;
                txtCapacidad.Text = "" + butacas.Count;
                frm.Close();
            }
        }
    }
}
