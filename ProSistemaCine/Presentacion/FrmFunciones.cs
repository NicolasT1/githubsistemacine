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
    public partial class FrmFunciones : Form
    {
        ClsNeFuncion objNeFuncion = new ClsNeFuncion();
        ClsEnFuncion objEnFuncion = new ClsEnFuncion();

        ClsNePelicula objNePelicula = new ClsNePelicula();
        ClsNeSala objNeSala = new ClsNeSala();
        ClsNeTarifa objNeTarifa = new ClsNeTarifa();

        public FrmFunciones()
        {
            InitializeComponent();

            loadCmbPeliculas();
        }

        private void loadCmbPeliculas()
        {
            cmbPeliculas.DataSource = objNePelicula.MtdListarPelicula();
            cmbPeliculas.DisplayMember = "Nombre";
            cmbPeliculas.ValueMember = "Id";
        }

        private void loadCmbSalas(string tipo)
        {
            cmbSalas.DataSource = objNeSala.MtdListarSala();
            cmbSalas.DisplayMember = "display_member";
            cmbSalas.ValueMember = "Id";
        }

        private void loadCmbTarifas(string tipo)
        {
            cmbTarifas.DataSource = objNeTarifa.MtdBuscarTarifa(tipo);
            cmbTarifas.DisplayMember = "Dia";
            cmbTarifas.ValueMember = "Id";
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
            objEnFuncion.Pelicula_id = Int32.Parse(cmbPeliculas.SelectedValue.ToString());
            objEnFuncion.Sala_id = Int32.Parse(cmbSalas.SelectedValue.ToString());
            objEnFuncion.Tarifa_id = Int32.Parse(cmbTarifas.SelectedValue.ToString());
            objEnFuncion.Idioma = cmbIdiomas.Text;
            objEnFuncion.Hora = txtHora.Text;
            objEnFuncion.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNeFuncion.MtdAgregarFuncion(objEnFuncion);

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objEnFuncion.Pelicula_id = Int32.Parse(cmbPeliculas.SelectedValue.ToString());
            objEnFuncion.Sala_id = Int32.Parse(cmbSalas.SelectedValue.ToString());
            objEnFuncion.Tarifa_id = Int32.Parse(cmbTarifas.SelectedValue.ToString());
            objEnFuncion.Idioma = cmbIdiomas.Text;
            objEnFuncion.Hora = txtHora.Text;
            objEnFuncion.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNeFuncion.MtdModificarFuncion(objEnFuncion);

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void setForm(ClsEnFuncion objEnFuncion)
        {
            this.objEnFuncion = objEnFuncion;

            cmbPeliculas.SelectedValue = objEnFuncion.Pelicula_id;
            cmbSalas.SelectedValue = objEnFuncion.Sala_id;
            cmbTarifas.SelectedValue = objEnFuncion.Tarifa_id;
            cmbIdiomas.Text = objEnFuncion.Idioma;
            txtHora.Text = objEnFuncion.Hora;
            rdbActivo.Checked = objEnFuncion.Estado == 1;
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
            dgvFunciones.DataSource = objNeFuncion.MtdListarFuncion();
            setFormState(FormState.Listar);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            setForm(new ClsEnFuncion());
            setFormState(FormState.Nuevo);
        }

        private void dgvFunciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dgvFunciones.Rows[e.RowIndex].Cells[0].Value.ToString());

            setForm(objNeFuncion.MtdObtenerFuncion(id));
            setFormState(FormState.Modificando);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvFunciones.DataSource = objNeFuncion.MtdBuscarFuncion(txtBuscar.Text);
            setFormState(FormState.Buscar);
        }

        private void cmbPeliculas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView row = cmbPeliculas.SelectedItem as DataRowView;
            if (row == null) return;
            int pelicula_id = Int32.Parse(row["id"].ToString());
            int idioma_dob = Int32.Parse(row["idioma_dob"].ToString());
            int idioma_sub = Int32.Parse(row["idioma_sub"].ToString());

            loadCmbSalas(null);
            loadCmbIdiomas(idioma_dob, idioma_sub);
        }

        private void cmbSalas_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView row = cmbSalas.SelectedItem as DataRowView;
            if (row == null) return;
            string tipo_sala = row["tipo"].ToString();

            loadCmbTarifas(tipo_sala);
        }

        private void cmbTarifas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
