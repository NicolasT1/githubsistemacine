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
    public partial class FrmPeliculas : Form
    {
        ClsNePelicula objNePelicula = new ClsNePelicula();
        ClsEnPelicula objEnPelicula = new ClsEnPelicula();

        ClsNeGenero objNeGenero = new ClsNeGenero();
        public FrmPeliculas()
        {
            InitializeComponent();
            loadCmbGeneros();
        }

        private void loadCmbGeneros()
        {
            cmbGeneros.DataSource = objNeGenero.MtdListarGenero();
            cmbGeneros.DisplayMember = "Nombre";
            cmbGeneros.ValueMember = "Id";
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            listarTabla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
            objEnPelicula.Genero_id = Int32.Parse(cmbGeneros.SelectedValue.ToString());
            objEnPelicula.Nombre = txtNombre.Text;
            objEnPelicula.Descripcion = txtDescripcion.Text;
            objEnPelicula.Duracion = txtDuracion.Text;
            objEnPelicula.Idioma_dob = chbDOB.Checked ? 1:0;
            objEnPelicula.Idioma_sub = chbSUB.Checked ? 1 : 0;
            objEnPelicula.Sensura = getSensura();
            objEnPelicula.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNePelicula.MtdAgregarPelicula(objEnPelicula);

            MessageBox.Show(rpt);

            listarTabla();
        }

        private int getSensura()
        {
            if (rdb14.Checked) return 1;
            if (rdb14DNI.Checked) return 2;
            if (rdbAPT.Checked) return 3;

            return 0;
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            objEnPelicula.Genero_id = Int32.Parse(cmbGeneros.SelectedValue.ToString());
            objEnPelicula.Nombre = txtNombre.Text;
            objEnPelicula.Descripcion = txtDescripcion.Text;
            objEnPelicula.Duracion = txtDuracion.Text;
            objEnPelicula.Idioma_dob = chbDOB.Checked ? 1 : 0;
            objEnPelicula.Idioma_sub = chbSUB.Checked ? 1 : 0;
            objEnPelicula.Sensura = getSensura();
            objEnPelicula.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNePelicula.MtdModificarPelicula(objEnPelicula);

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void setForm(ClsEnPelicula objEnPelicula)
        {
            this.objEnPelicula = objEnPelicula;
            cmbGeneros.SelectedValue = objEnPelicula.Genero_id;
            txtNombre.Text = objEnPelicula.Nombre;
            txtDescripcion.Text = objEnPelicula.Descripcion;
            txtDuracion.Text = objEnPelicula.Duracion;

            chbDOB.Checked = objEnPelicula.Idioma_dob == 1;
            chbSUB.Checked = objEnPelicula.Idioma_sub == 1;

            chbDOB.Checked = objEnPelicula.Idioma_dob == 1;
            chbSUB.Checked = objEnPelicula.Idioma_sub == 1;

            rdb14.Checked = objEnPelicula.Sensura == 1;
            rdb14DNI.Checked = objEnPelicula.Sensura == 2;
            rdbAPT.Checked = objEnPelicula.Sensura == 3;

            rdbActivo.Checked = objEnPelicula.Estado == 1;
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
            dgvPeliculas.DataSource = objNePelicula.MtdListarPelicula();
            setFormState(FormState.Listar);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            setForm(new ClsEnPelicula());
            setFormState(FormState.Nuevo);
        }

        private void dgvPeliculas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dgvPeliculas.Rows[e.RowIndex].Cells[0].Value.ToString());

            setForm(objNePelicula.MtdObtenerPelicula(id));
            setFormState(FormState.Modificando);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvPeliculas.DataSource = objNePelicula.MtdBuscarPelicula(txtBuscar.Text);
            setFormState(FormState.Buscar);
        }
    }
}
