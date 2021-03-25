using ProSistemaCine.Entidad;
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
    public partial class FrmButacas : Form
    {
        public ControlButacas ctrButacas = new ControlButacas();

        public FrmButacas()
        {
            InitializeComponent();

            ctrButacas.Contenedor = flowLayoutPanel1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

    }
}
