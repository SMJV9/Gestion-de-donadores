namespace WindowsFormsApp1
{
    partial class Donaciones
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
            this.groupBoxBusqueda = new System.Windows.Forms.GroupBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBoxDatos = new System.Windows.Forms.GroupBox();
            this.lblIdDonacion = new System.Windows.Forms.Label();
            this.txtIdDonacion = new System.Windows.Forms.TextBox();
            this.lblClienteDonante = new System.Windows.Forms.Label();
            this.cmbClienteDonante = new System.Windows.Forms.ComboBox();
            this.lblImporte = new System.Windows.Forms.Label();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.lblFactura = new System.Windows.Forms.Label();
            this.txtFactura = new System.Windows.Forms.TextBox();
            this.lblFechaDonacion = new System.Windows.Forms.Label();
            this.dtpFechaDonacion = new System.Windows.Forms.DateTimePicker();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBoxBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxBusqueda
            // 
            this.groupBoxBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBusqueda.Controls.Add(this.txtBuscar);
            this.groupBoxBusqueda.Controls.Add(this.btnBuscar);
            this.groupBoxBusqueda.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBusqueda.Name = "groupBoxBusqueda";
            this.groupBoxBusqueda.Size = new System.Drawing.Size(776, 60);
            this.groupBoxBusqueda.TabIndex = 0;
            this.groupBoxBusqueda.TabStop = false;
            this.groupBoxBusqueda.Text = "Búsqueda";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(15, 25);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(650, 20);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(680, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 78);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(776, 200);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // groupBoxDatos
            // 
            this.groupBoxDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDatos.Controls.Add(this.lblIdDonacion);
            this.groupBoxDatos.Controls.Add(this.txtIdDonacion);
            this.groupBoxDatos.Controls.Add(this.lblClienteDonante);
            this.groupBoxDatos.Controls.Add(this.cmbClienteDonante);
            this.groupBoxDatos.Controls.Add(this.lblImporte);
            this.groupBoxDatos.Controls.Add(this.txtImporte);
            this.groupBoxDatos.Controls.Add(this.lblFactura);
            this.groupBoxDatos.Controls.Add(this.txtFactura);
            this.groupBoxDatos.Controls.Add(this.lblFechaDonacion);
            this.groupBoxDatos.Controls.Add(this.dtpFechaDonacion);
            this.groupBoxDatos.Location = new System.Drawing.Point(12, 284);
            this.groupBoxDatos.Name = "groupBoxDatos";
            this.groupBoxDatos.Size = new System.Drawing.Size(776, 140);
            this.groupBoxDatos.TabIndex = 2;
            this.groupBoxDatos.TabStop = false;
            this.groupBoxDatos.Text = "Datos de la Donación";
            // 
            // lblIdDonacion
            // 
            this.lblIdDonacion.AutoSize = true;
            this.lblIdDonacion.Location = new System.Drawing.Point(15, 25);
            this.lblIdDonacion.Name = "lblIdDonacion";
            this.lblIdDonacion.Size = new System.Drawing.Size(70, 13);
            this.lblIdDonacion.TabIndex = 0;
            this.lblIdDonacion.Text = "ID Donación:";
            // 
            // txtIdDonacion
            // 
            this.txtIdDonacion.Location = new System.Drawing.Point(120, 22);
            this.txtIdDonacion.Name = "txtIdDonacion";
            this.txtIdDonacion.ReadOnly = true;
            this.txtIdDonacion.Size = new System.Drawing.Size(100, 20);
            this.txtIdDonacion.TabIndex = 1;
            // 
            // lblClienteDonante
            // 
            this.lblClienteDonante.AutoSize = true;
            this.lblClienteDonante.Location = new System.Drawing.Point(15, 55);
            this.lblClienteDonante.Name = "lblClienteDonante";
            this.lblClienteDonante.Size = new System.Drawing.Size(89, 13);
            this.lblClienteDonante.TabIndex = 2;
            this.lblClienteDonante.Text = "Cliente/Donante:";
            // 
            // cmbClienteDonante
            // 
            this.cmbClienteDonante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClienteDonante.FormattingEnabled = true;
            this.cmbClienteDonante.Location = new System.Drawing.Point(120, 52);
            this.cmbClienteDonante.Name = "cmbClienteDonante";
            this.cmbClienteDonante.Size = new System.Drawing.Size(300, 21);
            this.cmbClienteDonante.TabIndex = 3;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(15, 85);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(45, 13);
            this.lblImporte.TabIndex = 4;
            this.lblImporte.Text = "Importe:";
            // 
            // txtImporte
            // 
            this.txtImporte.Location = new System.Drawing.Point(120, 82);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(120, 20);
            this.txtImporte.TabIndex = 5;
            this.txtImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // lblFactura
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Location = new System.Drawing.Point(260, 85);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(46, 13);
            this.lblFactura.TabIndex = 6;
            this.lblFactura.Text = "Factura:";
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new System.Drawing.Point(320, 82);
            this.txtFactura.MaxLength = 50;
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(150, 20);
            this.txtFactura.TabIndex = 7;
            // 
            // lblFechaDonacion
            // 
            this.lblFechaDonacion.AutoSize = true;
            this.lblFechaDonacion.Location = new System.Drawing.Point(15, 115);
            this.lblFechaDonacion.Name = "lblFechaDonacion";
            this.lblFechaDonacion.Size = new System.Drawing.Size(85, 13);
            this.lblFechaDonacion.TabIndex = 8;
            this.lblFechaDonacion.Text = "Fecha Donación:";
            // 
            // dtpFechaDonacion
            // 
            this.dtpFechaDonacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDonacion.Location = new System.Drawing.Point(120, 112);
            this.dtpFechaDonacion.Name = "dtpFechaDonacion";
            this.dtpFechaDonacion.Size = new System.Drawing.Size(120, 20);
            this.dtpFechaDonacion.TabIndex = 9;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregar.Location = new System.Drawing.Point(12, 440);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 30);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModificar.Location = new System.Drawing.Point(93, 440);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 30);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Location = new System.Drawing.Point(174, 440);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 30);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.Location = new System.Drawing.Point(255, 440);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 30);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(713, 440);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 30);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Donaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 482);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.groupBoxDatos);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBoxBusqueda);
            this.MinimumSize = new System.Drawing.Size(816, 520);
            this.Name = "Donaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Donaciones";
            this.Load += new System.EventHandler(this.Donaciones_Load);
            this.groupBoxBusqueda.ResumeLayout(false);
            this.groupBoxBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxDatos.ResumeLayout(false);
            this.groupBoxDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBusqueda;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.Label lblIdDonacion;
        private System.Windows.Forms.TextBox txtIdDonacion;
        private System.Windows.Forms.Label lblClienteDonante;
        private System.Windows.Forms.ComboBox cmbClienteDonante;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.TextBox txtFactura;
        private System.Windows.Forms.Label lblFechaDonacion;
        private System.Windows.Forms.DateTimePicker dtpFechaDonacion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
    }
}