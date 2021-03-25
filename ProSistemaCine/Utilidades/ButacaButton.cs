using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProSistemaCine.Utilidades
{
    public partial class ButacaButton : UserControl
    {
        public int Id { get; set; }
        public string Name {
            get
            {
                return RowName + "" + Column;
            }
            set
            {
            }
        }
        public string RowName { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        private StateButaca state = StateButaca.Libre;

        private bool isChecked = false;
        public ButacaButton()
        {
            InitializeComponent();
        }

        

        public StateButaca State
        {
            get
            {
                return this.state;
            }
            set
            {
                switch (value)
                {
                    case StateButaca.Invisible:
                        this.Enabled = false;
                        this.BackColor = Color.Transparent;
                        this.BorderStyle = BorderStyle.None;
                        break;
                    case StateButaca.Libre:
                        this.Enabled = true;
                        this.BorderStyle = BorderStyle.FixedSingle;
                        Checked = isChecked;
                        break;
                    case StateButaca.Ocupado:
                        this.Enabled = false;
                        this.BackColor = Color.Red;
                        this.BorderStyle = BorderStyle.FixedSingle;
                        break;
                }
                
                this.state = value;
            }
        }

        public bool Checked
        {
            get
            {
                return this.isChecked;
            }
            set
            {
                if (value)
                {
                    this.BackColor = SystemColors.Highlight;
                }
                else
                {
                    this.BackColor = SystemColors.Control;
                }
                
                this.isChecked = value;
            }
        }

        private void ButacaButton_Click(object sender, EventArgs e)
        {
            Checked = !isChecked;
        }
        
    }

    public enum StateButaca { Invisible, Libre, Ocupado }
}
