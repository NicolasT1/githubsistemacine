using ProSistemaCine.Entidad;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProSistemaCine.Utilidades
{
    public class ControlButacas
    {
        private static int FILAS = 5;
        private static int COLUMNAS = 15;

        private List<ClsEnButaca> selectedButacas = new List<ClsEnButaca>();

        private Label[] labels = new Label[FILAS];
        private ButacaButton[][] botones = new ButacaButton[FILAS][];

        public FlowLayoutPanel Contenedor { get; set; }

        public string getLetra(int index)
        {
            switch (index)
            {
                case 0:
                    return "A";
                case 1:
                    return "B";
                case 2:
                    return "C";
                case 3:
                    return "D";
                case 4:
                    return "E";
                case 5:
                    return "F";
                case 6:
                    return "G";
                case 7:
                    return "H";
                case 8:
                    return "I";
            }

            return "?";
        }

        public void renderButacas()
        {
            Contenedor.Controls.Clear();
            
            for (int i = 0; i < FILAS; i++)
            {
                string rowName = getLetra(i);

                labels[i] = new Label();
                labels[i].AutoSize = true;
                labels[i].Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                labels[i].Name = "lbl" + rowName;
                labels[i].Size = new Size(27, 25);
                labels[i].Text = rowName;

                Contenedor.Controls.Add(labels[i]);

                botones[i] = new ButacaButton[COLUMNAS];
                for (int k = 0; k < COLUMNAS; k++)
                {
                    botones[i][k] = new ButacaButton();
                    botones[i][k].RowName = rowName;
                    botones[i][k].Row = i;
                    botones[i][k].Column = k;
                    
                    if (selectedButacas.Exists(x => x.Fila == i && x.Columna == k))
                    {
                        botones[i][k].Checked = true;
                    }
                    
                    if(Butacas.Count > 0)
                    {
                        var butaca = Butacas.Select(b => b).Where(x => x.Fila == i && x.Columna == k).SingleOrDefault();

                        if (butaca != null)
                        {
                            botones[i][k].Id = butaca.Id;
                            botones[i][k].State = butaca.Tipo == 0 ? StateButaca.Libre : StateButaca.Ocupado;
                        }
                        else
                        {
                            botones[i][k].State = StateButaca.Invisible;
                        }
                    }

                    botones[i][k].Click += new EventHandler(btnButacas_Click);

                    this.Contenedor.Controls.Add(botones[i][k]);
                }
            }
            
        }
        public delegate void ButacaEventHandler(List<ClsEnButaca> taskResult);

        public ButacaEventHandler Click;
        private void btnButacas_Click(object sender, EventArgs e)
        {
            if (Click == null) return;
            Click(SelectedButacas);
        }

        public List<ClsEnButaca> Butacas { get; set; } = new List<ClsEnButaca>();
        public List<ClsEnButaca> SelectedButacas
        {
            get
            {
                this.selectedButacas = new List<ClsEnButaca>();

                for (int i = 0; i < FILAS; i++)
                {
                    for (int k = 0; k < COLUMNAS; k++)
                    {
                        if (botones[i][k].Checked)
                        {
                            ClsEnButaca butaca = new ClsEnButaca();
                            butaca.Id = botones[i][k].Id;
                            butaca.Fila = i;
                            butaca.Columna = k;
                            butaca.Tipo = 0;

                            this.selectedButacas.Add(butaca);
                        }
                    }
                }

                return this.selectedButacas;
            }
            set
            {
                this.selectedButacas = value;
            }
        }
    }
}
