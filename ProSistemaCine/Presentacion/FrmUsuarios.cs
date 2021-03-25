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
    public partial class FrmUsuarios : Form
    {
        ClsNeUsuario objNeUsuario = new ClsNeUsuario();
        ClsEnUsuario objEnUsuario = new ClsEnUsuario();
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            listarTabla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            objEnUsuario.Nombres = txtNombres.Text;
            objEnUsuario.Apellidos = txtApellidos.Text;
            objEnUsuario.Usuario = txtUsuario.Text;
            objEnUsuario.Password = txtPassword.Text;
            objEnUsuario.Email = txtEmail.Text;
            objEnUsuario.Rol = cmbRoles.Text;
            objEnUsuario.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNeUsuario.MtdAgregarUsuario(objEnUsuario);

            MessageBox.Show(rpt);

            listarTabla();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            objEnUsuario.Nombres = txtNombres.Text;
            objEnUsuario.Apellidos = txtApellidos.Text;
            objEnUsuario.Usuario = txtUsuario.Text;
            objEnUsuario.Password = txtPassword.Text;
            objEnUsuario.Email = txtEmail.Text;
            objEnUsuario.Rol = cmbRoles.Text;
            objEnUsuario.Estado = rdbActivo.Checked ? 1 : 0;

            string rpt = objNeUsuario.MtdModificarUsuario(objEnUsuario);

            MessageBox.Show(rpt);

            listarTabla();
        }
        
        private void setForm(ClsEnUsuario objEnUsuario)
        {
            this.objEnUsuario = objEnUsuario;
            txtNombres.Text = objEnUsuario.Nombres;
            txtApellidos.Text = objEnUsuario.Apellidos;
            txtUsuario.Text = objEnUsuario.Usuario;
            txtPassword.Text = objEnUsuario.Password;
            txtEmail.Text = objEnUsuario.Email;
            cmbRoles.Text = objEnUsuario.Rol;
            rdbActivo.Checked = objEnUsuario.Estado == 1;
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
            dgvUsuarios.DataSource = objNeUsuario.MtdListarUsuario();
            setFormState(FormState.Listar);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            setForm(new ClsEnUsuario());
            setFormState(FormState.Nuevo);
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Int32.Parse(dgvUsuarios.Rows[e.RowIndex].Cells[0].Value.ToString());
            
            setForm(objNeUsuario.MtdObtenerUsuario(id));
            setFormState(FormState.Modificando);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = objNeUsuario.MtdBuscarUsuario(txtBuscar.Text);
            setFormState(FormState.Buscar);
        }
    }
}
