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
    public partial class FrmClientes : Form
    {
        ClsNeCliente objNeCliente = new ClsNeCliente();
        ClsEnCliente objEnCliente = new ClsEnCliente();
        public FrmClientes()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            listarTabla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objEnCliente.Nombres = txtNombres.Text;
            objEnCliente.Apellidos = txtApellidos.Text;
            objEnCliente.Dni = txtDni.Text;
            objEnCliente.Fecha_nacimiento = txtFecha_nacimiento.Text;
            objEnCliente.Email = txtEmail.Text;
            objEnCliente.Direccion = txtDireccion.Text;
            objEnCliente.Genero = cmbGenero.Text;
            objEnCliente.Tipo = rdbActivo.Checked ? 1 : 0;
            objEnCliente.Estado = rdbFrecuente.Checked ? 1:0;

            string rpt = objNeCliente.MtdAgregarCliente(objEnCliente);

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objEnCliente.Nombres = txtNombres.Text;
            objEnCliente.Apellidos = txtApellidos.Text;
            objEnCliente.Dni = txtDni.Text;
            objEnCliente.Fecha_nacimiento = txtFecha_nacimiento.Text;
            objEnCliente.Email = txtEmail.Text;
            objEnCliente.Direccion = txtDireccion.Text;
            objEnCliente.Genero = cmbGenero.Text;
            objEnCliente.Tipo = rdbFrecuente.Checked ? 1 : 0;
            objEnCliente.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNeCliente.MtdModificarCliente(objEnCliente);

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void setForm(ClsEnCliente objEnCliente)
        {
            this.objEnCliente = objEnCliente;
            txtNombres.Text = objEnCliente.Nombres;
            txtApellidos.Text = objEnCliente.Apellidos;
            txtDni.Text = objEnCliente.Dni;
            txtFecha_nacimiento.Text = objEnCliente.Fecha_nacimiento;
            txtEmail.Text = objEnCliente.Email;
            txtDireccion.Text = objEnCliente.Direccion;
            cmbGenero.Text = objEnCliente.Genero;

            rdbFrecuente.Checked = objEnCliente.Tipo == 1;
            rdbActivo.Checked = objEnCliente.Estado == 1;
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
            dgvClientes.DataSource = objNeCliente.MtdListarCliente();
            setFormState(FormState.Listar);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            setForm(new ClsEnCliente());
            setFormState(FormState.Nuevo);
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dgvClientes.Rows[e.RowIndex].Cells[0].Value.ToString());

            setForm(objNeCliente.MtdObtenerCliente(id));
            setFormState(FormState.Modificando);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvClientes.DataSource = objNeCliente.MtdBuscarCliente(txtBuscar.Text);
            setFormState(FormState.Buscar);
        }
    }
}
