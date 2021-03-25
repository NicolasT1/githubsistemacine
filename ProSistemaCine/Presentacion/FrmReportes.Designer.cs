namespace ProSistemaCine.Presentacion
{
    partial class FrmReportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRptClientes = new System.Windows.Forms.Button();
            this.btnRptPeliculas = new System.Windows.Forms.Button();
            this.btnRptUsuarios = new System.Windows.Forms.Button();
            this.btnRptTVDia = new System.Windows.Forms.Button();
            this.btnRptTVSemana = new System.Windows.Forms.Button();
            this.btnRptTVMes = new System.Windows.Forms.Button();
            this.btnRptTVAnio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRptClientes
            // 
            this.btnRptClientes.Location = new System.Drawing.Point(12, 12);
            this.btnRptClientes.Name = "btnRptClientes";
            this.btnRptClientes.Size = new System.Drawing.Size(125, 46);
            this.btnRptClientes.TabIndex = 0;
            this.btnRptClientes.Text = "Clientes";
            this.btnRptClientes.UseVisualStyleBackColor = true;
            this.btnRptClientes.Click += new System.EventHandler(this.btnRptClientes_Click);
            // 
            // btnRptPeliculas
            // 
            this.btnRptPeliculas.Location = new System.Drawing.Point(143, 12);
            this.btnRptPeliculas.Name = "btnRptPeliculas";
            this.btnRptPeliculas.Size = new System.Drawing.Size(116, 46);
            this.btnRptPeliculas.TabIndex = 1;
            this.btnRptPeliculas.Text = "Peliculas";
            this.btnRptPeliculas.UseVisualStyleBackColor = true;
            this.btnRptPeliculas.Click += new System.EventHandler(this.btnRptPeliculas_Click);
            // 
            // btnRptUsuarios
            // 
            this.btnRptUsuarios.Location = new System.Drawing.Point(265, 12);
            this.btnRptUsuarios.Name = "btnRptUsuarios";
            this.btnRptUsuarios.Size = new System.Drawing.Size(102, 46);
            this.btnRptUsuarios.TabIndex = 2;
            this.btnRptUsuarios.Text = "Usuarios";
            this.btnRptUsuarios.UseVisualStyleBackColor = true;
            this.btnRptUsuarios.Click += new System.EventHandler(this.btnRptUsuarios_Click);
            // 
            // btnRptTVDia
            // 
            this.btnRptTVDia.Location = new System.Drawing.Point(12, 64);
            this.btnRptTVDia.Name = "btnRptTVDia";
            this.btnRptTVDia.Size = new System.Drawing.Size(171, 44);
            this.btnRptTVDia.TabIndex = 3;
            this.btnRptTVDia.Text = "Total de Ventas en el Dia";
            this.btnRptTVDia.UseVisualStyleBackColor = true;
            this.btnRptTVDia.Click += new System.EventHandler(this.btnRptTVDia_Click);
            // 
            // btnRptTVSemana
            // 
            this.btnRptTVSemana.Location = new System.Drawing.Point(12, 114);
            this.btnRptTVSemana.Name = "btnRptTVSemana";
            this.btnRptTVSemana.Size = new System.Drawing.Size(171, 41);
            this.btnRptTVSemana.TabIndex = 4;
            this.btnRptTVSemana.Text = "Total de Ventas en la Semana";
            this.btnRptTVSemana.UseVisualStyleBackColor = true;
            this.btnRptTVSemana.Click += new System.EventHandler(this.btnRptTVSemana_Click);
            // 
            // btnRptTVMes
            // 
            this.btnRptTVMes.Location = new System.Drawing.Point(12, 161);
            this.btnRptTVMes.Name = "btnRptTVMes";
            this.btnRptTVMes.Size = new System.Drawing.Size(171, 43);
            this.btnRptTVMes.TabIndex = 5;
            this.btnRptTVMes.Text = "Total de Ventas en el Mes";
            this.btnRptTVMes.UseVisualStyleBackColor = true;
            this.btnRptTVMes.Click += new System.EventHandler(this.btnRptTVMes_Click);
            // 
            // btnRptTVAnio
            // 
            this.btnRptTVAnio.Location = new System.Drawing.Point(12, 210);
            this.btnRptTVAnio.Name = "btnRptTVAnio";
            this.btnRptTVAnio.Size = new System.Drawing.Size(171, 41);
            this.btnRptTVAnio.TabIndex = 6;
            this.btnRptTVAnio.Text = "Total de Ventas en el Año";
            this.btnRptTVAnio.UseVisualStyleBackColor = true;
            this.btnRptTVAnio.Click += new System.EventHandler(this.btnRptTVAnio_Click);
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 360);
            this.Controls.Add(this.btnRptTVAnio);
            this.Controls.Add(this.btnRptTVMes);
            this.Controls.Add(this.btnRptTVSemana);
            this.Controls.Add(this.btnRptTVDia);
            this.Controls.Add(this.btnRptUsuarios);
            this.Controls.Add(this.btnRptPeliculas);
            this.Controls.Add(this.btnRptClientes);
            this.Name = "FrmReportes";
            this.Text = "Reportes del Sistema";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRptClientes;
        private System.Windows.Forms.Button btnRptPeliculas;
        private System.Windows.Forms.Button btnRptUsuarios;
        private System.Windows.Forms.Button btnRptTVDia;
        private System.Windows.Forms.Button btnRptTVSemana;
        private System.Windows.Forms.Button btnRptTVMes;
        private System.Windows.Forms.Button btnRptTVAnio;
    }
}