namespace ProSistemaCine.Presentacion
{
    partial class FrmPeliculas
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
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbInactivo = new System.Windows.Forms.RadioButton();
            this.rdbActivo = new System.Windows.Forms.RadioButton();
            this.cmbGeneros = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvPeliculas = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtDuracion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdb14 = new System.Windows.Forms.RadioButton();
            this.rdb14DNI = new System.Windows.Forms.RadioButton();
            this.rdbAPT = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chbSUB = new System.Windows.Forms.CheckBox();
            this.chbDOB = new System.Windows.Forms.CheckBox();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeliculas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.groupBox3);
            this.GroupBox1.Controls.Add(this.groupBox2);
            this.GroupBox1.Controls.Add(this.label4);
            this.GroupBox1.Controls.Add(this.txtDuracion);
            this.GroupBox1.Controls.Add(this.txtDescripcion);
            this.GroupBox1.Controls.Add(this.rdbInactivo);
            this.GroupBox1.Controls.Add(this.rdbActivo);
            this.GroupBox1.Controls.Add(this.cmbGeneros);
            this.GroupBox1.Controls.Add(this.label3);
            this.GroupBox1.Controls.Add(this.label2);
            this.GroupBox1.Controls.Add(this.txtNombre);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.btnModificar);
            this.GroupBox1.Controls.Add(this.btnListar);
            this.GroupBox1.Controls.Add(this.btnNuevo);
            this.GroupBox1.Controls.Add(this.btnGuardar);
            this.GroupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.ForeColor = System.Drawing.Color.White;
            this.GroupBox1.Location = new System.Drawing.Point(12, 64);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(751, 232);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "DATOS DE PELICULA";
            // 
            // rdbInactivo
            // 
            this.rdbInactivo.AutoSize = true;
            this.rdbInactivo.Location = new System.Drawing.Point(187, 192);
            this.rdbInactivo.Name = "rdbInactivo";
            this.rdbInactivo.Size = new System.Drawing.Size(83, 23);
            this.rdbInactivo.TabIndex = 23;
            this.rdbInactivo.TabStop = true;
            this.rdbInactivo.Text = "Inactivo";
            this.rdbInactivo.UseVisualStyleBackColor = true;
            // 
            // rdbActivo
            // 
            this.rdbActivo.AutoSize = true;
            this.rdbActivo.Location = new System.Drawing.Point(104, 192);
            this.rdbActivo.Name = "rdbActivo";
            this.rdbActivo.Size = new System.Drawing.Size(71, 23);
            this.rdbActivo.TabIndex = 22;
            this.rdbActivo.TabStop = true;
            this.rdbActivo.Text = "Activo";
            this.rdbActivo.UseVisualStyleBackColor = true;
            // 
            // cmbGeneros
            // 
            this.cmbGeneros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGeneros.FormattingEnabled = true;
            this.cmbGeneros.Items.AddRange(new object[] {
            "Administrador",
            "Taquillero"});
            this.cmbGeneros.Location = new System.Drawing.Point(391, 45);
            this.cmbGeneros.Name = "cmbGeneros";
            this.cmbGeneros.Size = new System.Drawing.Size(201, 27);
            this.cmbGeneros.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Descripcion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "Genero:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(104, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(177, 27);
            this.txtNombre.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre:";
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnModificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.Black;
            this.btnModificar.Location = new System.Drawing.Point(636, 175);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 40);
            this.btnModificar.TabIndex = 9;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnListar.FlatAppearance.BorderSize = 0;
            this.btnListar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnListar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnListar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.ForeColor = System.Drawing.Color.Black;
            this.btnListar.Location = new System.Drawing.Point(636, 83);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(90, 40);
            this.btnListar.TabIndex = 8;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.Black;
            this.btnNuevo.Location = new System.Drawing.Point(636, 37);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 40);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Location = new System.Drawing.Point(636, 129);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 40);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvPeliculas
            // 
            this.dgvPeliculas.AllowUserToAddRows = false;
            this.dgvPeliculas.AllowUserToDeleteRows = false;
            this.dgvPeliculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeliculas.Location = new System.Drawing.Point(12, 302);
            this.dgvPeliculas.Name = "dgvPeliculas";
            this.dgvPeliculas.ReadOnly = true;
            this.dgvPeliculas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPeliculas.Size = new System.Drawing.Size(751, 170);
            this.dgvPeliculas.TabIndex = 5;
            this.dgvPeliculas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPeliculas_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 46);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProSistemaCine.Properties.Resources.imagen2;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(258, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(255, 25);
            this.label7.TabIndex = 7;
            this.label7.Text = "REGISTRO DE PELICULAS";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(517, 478);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(150, 20);
            this.txtBuscar.TabIndex = 7;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(673, 478);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 22);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(458, 479);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Buscar:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(104, 80);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(178, 62);
            this.txtDescripcion.TabIndex = 24;
            // 
            // txtDuracion
            // 
            this.txtDuracion.Location = new System.Drawing.Point(104, 151);
            this.txtDuracion.Name = "txtDuracion";
            this.txtDuracion.Size = new System.Drawing.Size(119, 27);
            this.txtDuracion.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 19);
            this.label4.TabIndex = 26;
            this.label4.Text = "Duracion:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbAPT);
            this.groupBox2.Controls.Add(this.rdb14DNI);
            this.groupBox2.Controls.Add(this.rdb14);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(323, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 67);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cencura:";
            // 
            // rdb14
            // 
            this.rdb14.AutoSize = true;
            this.rdb14.Location = new System.Drawing.Point(19, 26);
            this.rdb14.Name = "rdb14";
            this.rdb14.Size = new System.Drawing.Size(57, 23);
            this.rdb14.TabIndex = 0;
            this.rdb14.TabStop = true;
            this.rdb14.Text = "+14";
            this.rdb14.UseVisualStyleBackColor = true;
            // 
            // rdb14DNI
            // 
            this.rdb14DNI.AutoSize = true;
            this.rdb14DNI.Location = new System.Drawing.Point(101, 26);
            this.rdb14DNI.Name = "rdb14DNI";
            this.rdb14DNI.Size = new System.Drawing.Size(90, 23);
            this.rdb14DNI.TabIndex = 1;
            this.rdb14DNI.TabStop = true;
            this.rdb14DNI.Text = "+14 DNI";
            this.rdb14DNI.UseVisualStyleBackColor = true;
            // 
            // rdbAPT
            // 
            this.rdbAPT.AutoSize = true;
            this.rdbAPT.Location = new System.Drawing.Point(197, 26);
            this.rdbAPT.Name = "rdbAPT";
            this.rdbAPT.Size = new System.Drawing.Size(57, 23);
            this.rdbAPT.TabIndex = 2;
            this.rdbAPT.TabStop = true;
            this.rdbAPT.Text = "APT";
            this.rdbAPT.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chbDOB);
            this.groupBox3.Controls.Add(this.chbSUB);
            this.groupBox3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Location = new System.Drawing.Point(323, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 64);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Idioma:";
            // 
            // chbSUB
            // 
            this.chbSUB.AutoSize = true;
            this.chbSUB.Location = new System.Drawing.Point(30, 24);
            this.chbSUB.Name = "chbSUB";
            this.chbSUB.Size = new System.Drawing.Size(107, 23);
            this.chbSUB.TabIndex = 0;
            this.chbSUB.Text = "Subtitulada";
            this.chbSUB.UseVisualStyleBackColor = true;
            // 
            // chbDOB
            // 
            this.chbDOB.AutoSize = true;
            this.chbDOB.Location = new System.Drawing.Point(143, 24);
            this.chbDOB.Name = "chbDOB";
            this.chbDOB.Size = new System.Drawing.Size(86, 23);
            this.chbDOB.TabIndex = 1;
            this.chbDOB.Text = "Doblada";
            this.chbDOB.UseVisualStyleBackColor = true;
            // 
            // FrmPeliculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(778, 571);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvPeliculas);
            this.Controls.Add(this.GroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPeliculas";
            this.Text = "FrmEmpleado";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeliculas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnListar;
        internal System.Windows.Forms.Button btnGuardar;
        internal System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dgvPeliculas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.RadioButton rdbInactivo;
        private System.Windows.Forms.RadioButton rdbActivo;
        private System.Windows.Forms.ComboBox cmbGeneros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbAPT;
        private System.Windows.Forms.RadioButton rdb14DNI;
        private System.Windows.Forms.RadioButton rdb14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDuracion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chbDOB;
        private System.Windows.Forms.CheckBox chbSUB;
    }
}