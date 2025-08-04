namespace WindowsFormsApp1
{
    partial class ReporteGastos
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.rbPersonalizado = new System.Windows.Forms.RadioButton();
            this.rbAnual = new System.Windows.Forms.RadioButton();
            this.rbMensual = new System.Windows.Forms.RadioButton();
            this.rbSemanal = new System.Windows.Forms.RadioButton();
            this.rbDiario = new System.Windows.Forms.RadioButton();
            this.lblTipoReporte = new System.Windows.Forms.Label();
            this.lblAno = new System.Windows.Forms.Label();
            this.cmbAno = new System.Windows.Forms.ComboBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.lblSemana = new System.Windows.Forms.Label();
            this.cmbSemana = new System.Windows.Forms.ComboBox();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblTipoGasto = new System.Windows.Forms.Label();
            this.cmbTipoGasto = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBoxResumen = new System.Windows.Forms.GroupBox();
            this.lblTotalGeneral = new System.Windows.Forms.Label();
            this.lblTotalFijos = new System.Windows.Forms.Label();
            this.lblTotalVariables = new System.Windows.Forms.Label();
            this.lblCantidadRegistros = new System.Windows.Forms.Label();
            this.lblPromedioGasto = new System.Windows.Forms.Label();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.btnExportarExcel = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBoxFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(171, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reporte de Gastos";
            // 
            // groupBoxFiltros
            // 
            this.groupBoxFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFiltros.Controls.Add(this.rbPersonalizado);
            this.groupBoxFiltros.Controls.Add(this.rbAnual);
            this.groupBoxFiltros.Controls.Add(this.rbMensual);
            this.groupBoxFiltros.Controls.Add(this.rbSemanal);
            this.groupBoxFiltros.Controls.Add(this.rbDiario);
            this.groupBoxFiltros.Controls.Add(this.lblTipoReporte);
            this.groupBoxFiltros.Controls.Add(this.lblAno);
            this.groupBoxFiltros.Controls.Add(this.cmbAno);
            this.groupBoxFiltros.Controls.Add(this.lblMes);
            this.groupBoxFiltros.Controls.Add(this.cmbMes);
            this.groupBoxFiltros.Controls.Add(this.lblSemana);
            this.groupBoxFiltros.Controls.Add(this.cmbSemana);
            this.groupBoxFiltros.Controls.Add(this.lblFechaInicio);
            this.groupBoxFiltros.Controls.Add(this.dtpFechaInicio);
            this.groupBoxFiltros.Controls.Add(this.lblFechaFin);
            this.groupBoxFiltros.Controls.Add(this.dtpFechaFin);
            this.groupBoxFiltros.Controls.Add(this.lblCategoria);
            this.groupBoxFiltros.Controls.Add(this.cmbCategoria);
            this.groupBoxFiltros.Controls.Add(this.lblTipoGasto);
            this.groupBoxFiltros.Controls.Add(this.cmbTipoGasto);
            this.groupBoxFiltros.Location = new System.Drawing.Point(12, 50);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Size = new System.Drawing.Size(960, 180);
            this.groupBoxFiltros.TabIndex = 1;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros de Reporte";
            // 
            // rbPersonalizado
            // 
            this.rbPersonalizado.AutoSize = true;
            this.rbPersonalizado.Location = new System.Drawing.Point(390, 45);
            this.rbPersonalizado.Name = "rbPersonalizado";
            this.rbPersonalizado.Size = new System.Drawing.Size(92, 17);
            this.rbPersonalizado.TabIndex = 19;
            this.rbPersonalizado.Text = "Personalizado";
            this.rbPersonalizado.UseVisualStyleBackColor = true;
            this.rbPersonalizado.CheckedChanged += new System.EventHandler(this.TipoReporte_CheckedChanged);
            // 
            // rbAnual
            // 
            this.rbAnual.AutoSize = true;
            this.rbAnual.Location = new System.Drawing.Point(330, 45);
            this.rbAnual.Name = "rbAnual";
            this.rbAnual.Size = new System.Drawing.Size(54, 17);
            this.rbAnual.TabIndex = 18;
            this.rbAnual.Text = "Anual";
            this.rbAnual.UseVisualStyleBackColor = true;
            this.rbAnual.CheckedChanged += new System.EventHandler(this.TipoReporte_CheckedChanged);
            // 
            // rbMensual
            // 
            this.rbMensual.AutoSize = true;
            this.rbMensual.Checked = true;
            this.rbMensual.Location = new System.Drawing.Point(260, 45);
            this.rbMensual.Name = "rbMensual";
            this.rbMensual.Size = new System.Drawing.Size(65, 17);
            this.rbMensual.TabIndex = 17;
            this.rbMensual.TabStop = true;
            this.rbMensual.Text = "Mensual";
            this.rbMensual.UseVisualStyleBackColor = true;
            this.rbMensual.CheckedChanged += new System.EventHandler(this.TipoReporte_CheckedChanged);
            // 
            // rbSemanal
            // 
            this.rbSemanal.AutoSize = true;
            this.rbSemanal.Location = new System.Drawing.Point(190, 45);
            this.rbSemanal.Name = "rbSemanal";
            this.rbSemanal.Size = new System.Drawing.Size(66, 17);
            this.rbSemanal.TabIndex = 16;
            this.rbSemanal.Text = "Semanal";
            this.rbSemanal.UseVisualStyleBackColor = true;
            this.rbSemanal.CheckedChanged += new System.EventHandler(this.TipoReporte_CheckedChanged);
            // 
            // rbDiario
            // 
            this.rbDiario.AutoSize = true;
            this.rbDiario.Location = new System.Drawing.Point(130, 45);
            this.rbDiario.Name = "rbDiario";
            this.rbDiario.Size = new System.Drawing.Size(54, 17);
            this.rbDiario.TabIndex = 15;
            this.rbDiario.Text = "Diario";
            this.rbDiario.UseVisualStyleBackColor = true;
            this.rbDiario.CheckedChanged += new System.EventHandler(this.TipoReporte_CheckedChanged);
            // 
            // lblTipoReporte
            // 
            this.lblTipoReporte.AutoSize = true;
            this.lblTipoReporte.Location = new System.Drawing.Point(15, 47);
            this.lblTipoReporte.Name = "lblTipoReporte";
            this.lblTipoReporte.Size = new System.Drawing.Size(95, 13);
            this.lblTipoReporte.TabIndex = 14;
            this.lblTipoReporte.Text = "Período de tiempo:";
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Location = new System.Drawing.Point(15, 80);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(29, 13);
            this.lblAno.TabIndex = 0;
            this.lblAno.Text = "Año:";
            // 
            // cmbAno
            // 
            this.cmbAno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAno.FormattingEnabled = true;
            this.cmbAno.Location = new System.Drawing.Point(50, 77);
            this.cmbAno.Name = "cmbAno";
            this.cmbAno.Size = new System.Drawing.Size(80, 21);
            this.cmbAno.TabIndex = 1;
            this.cmbAno.SelectedIndexChanged += new System.EventHandler(this.cmbAno_SelectedIndexChanged);
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Location = new System.Drawing.Point(150, 80);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(30, 13);
            this.lblMes.TabIndex = 2;
            this.lblMes.Text = "Mes:";
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(185, 77);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(120, 21);
            this.cmbMes.TabIndex = 3;
            this.cmbMes.SelectedIndexChanged += new System.EventHandler(this.cmbMes_SelectedIndexChanged);
            // 
            // lblSemana
            // 
            this.lblSemana.AutoSize = true;
            this.lblSemana.Location = new System.Drawing.Point(325, 80);
            this.lblSemana.Name = "lblSemana";
            this.lblSemana.Size = new System.Drawing.Size(49, 13);
            this.lblSemana.TabIndex = 4;
            this.lblSemana.Text = "Semana:";
            // 
            // cmbSemana
            // 
            this.cmbSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSemana.FormattingEnabled = true;
            this.cmbSemana.Location = new System.Drawing.Point(380, 77);
            this.cmbSemana.Name = "cmbSemana";
            this.cmbSemana.Size = new System.Drawing.Size(120, 21);
            this.cmbSemana.TabIndex = 5;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(520, 80);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(68, 13);
            this.lblFechaInicio.TabIndex = 6;
            this.lblFechaInicio.Text = "Fecha inicio:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(595, 77);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaInicio.TabIndex = 7;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(715, 80);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(54, 13);
            this.lblFechaFin.TabIndex = 8;
            this.lblFechaFin.Text = "Fecha fin:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(775, 77);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaFin.TabIndex = 9;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(15, 115);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(57, 13);
            this.lblCategoria.TabIndex = 10;
            this.lblCategoria.Text = "Categoría:";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(80, 112);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(200, 21);
            this.cmbCategoria.TabIndex = 11;
            // 
            // lblTipoGasto
            // 
            this.lblTipoGasto.AutoSize = true;
            this.lblTipoGasto.Location = new System.Drawing.Point(300, 115);
            this.lblTipoGasto.Name = "lblTipoGasto";
            this.lblTipoGasto.Size = new System.Drawing.Size(68, 13);
            this.lblTipoGasto.TabIndex = 12;
            this.lblTipoGasto.Text = "Tipo Gasto:";
            // 
            // cmbTipoGasto
            // 
            this.cmbTipoGasto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoGasto.FormattingEnabled = true;
            this.cmbTipoGasto.Location = new System.Drawing.Point(375, 112);
            this.cmbTipoGasto.Name = "cmbTipoGasto";
            this.cmbTipoGasto.Size = new System.Drawing.Size(120, 21);
            this.cmbTipoGasto.TabIndex = 13;
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 250);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(760, 300);
            this.dataGridView1.TabIndex = 2;
            // 
            // groupBoxResumen
            // 
            this.groupBoxResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxResumen.Controls.Add(this.lblTotalGeneral);
            this.groupBoxResumen.Controls.Add(this.lblTotalFijos);
            this.groupBoxResumen.Controls.Add(this.lblTotalVariables);
            this.groupBoxResumen.Controls.Add(this.lblCantidadRegistros);
            this.groupBoxResumen.Controls.Add(this.lblPromedioGasto);
            this.groupBoxResumen.Location = new System.Drawing.Point(778, 250);
            this.groupBoxResumen.Name = "groupBoxResumen";
            this.groupBoxResumen.Size = new System.Drawing.Size(194, 300);
            this.groupBoxResumen.TabIndex = 3;
            this.groupBoxResumen.TabStop = false;
            this.groupBoxResumen.Text = "Resumen del Reporte";
            // 
            // lblTotalGeneral
            // 
            this.lblTotalGeneral.AutoSize = true;
            this.lblTotalGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalGeneral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTotalGeneral.Location = new System.Drawing.Point(15, 30);
            this.lblTotalGeneral.Name = "lblTotalGeneral";
            this.lblTotalGeneral.Size = new System.Drawing.Size(99, 17);
            this.lblTotalGeneral.TabIndex = 0;
            this.lblTotalGeneral.Text = "Total: $0.00";
            // 
            // lblTotalFijos
            // 
            this.lblTotalFijos.AutoSize = true;
            this.lblTotalFijos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalFijos.Location = new System.Drawing.Point(15, 60);
            this.lblTotalFijos.Name = "lblTotalFijos";
            this.lblTotalFijos.Size = new System.Drawing.Size(79, 13);
            this.lblTotalFijos.TabIndex = 1;
            this.lblTotalFijos.Text = "Fijos: $0.00";
            // 
            // lblTotalVariables
            // 
            this.lblTotalVariables.AutoSize = true;
            this.lblTotalVariables.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalVariables.Location = new System.Drawing.Point(15, 85);
            this.lblTotalVariables.Name = "lblTotalVariables";
            this.lblTotalVariables.Size = new System.Drawing.Size(96, 13);
            this.lblTotalVariables.TabIndex = 2;
            this.lblTotalVariables.Text = "Variables: $0.00";
            // 
            // lblCantidadRegistros
            // 
            this.lblCantidadRegistros.AutoSize = true;
            this.lblCantidadRegistros.Location = new System.Drawing.Point(15, 115);
            this.lblCantidadRegistros.Name = "lblCantidadRegistros";
            this.lblCantidadRegistros.Size = new System.Drawing.Size(66, 13);
            this.lblCantidadRegistros.TabIndex = 3;
            this.lblCantidadRegistros.Text = "Registros: 0";
            // 
            // lblPromedioGasto
            // 
            this.lblPromedioGasto.AutoSize = true;
            this.lblPromedioGasto.Location = new System.Drawing.Point(15, 140);
            this.lblPromedioGasto.Name = "lblPromedioGasto";
            this.lblPromedioGasto.Size = new System.Drawing.Size(82, 13);
            this.lblPromedioGasto.TabIndex = 4;
            this.lblPromedioGasto.Text = "Promedio: $0.00";
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGenerarReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGenerarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReporte.ForeColor = System.Drawing.Color.White;
            this.btnGenerarReporte.Location = new System.Drawing.Point(12, 570);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(120, 30);
            this.btnGenerarReporte.TabIndex = 4;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = false;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportarExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnExportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportarExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportarExcel.Location = new System.Drawing.Point(138, 570);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(100, 30);
            this.btnExportarExcel.TabIndex = 5;
            this.btnExportarExcel.Text = "Exportar Excel";
            this.btnExportarExcel.UseVisualStyleBackColor = false;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimir.Location = new System.Drawing.Point(244, 570);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 30);
            this.btnImprimir.TabIndex = 6;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLimpiar.Location = new System.Drawing.Point(325, 570);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 30);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(897, 570);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 30);
            this.btnSalir.TabIndex = 8;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // ReporteGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnGenerarReporte);
            this.Controls.Add(this.groupBoxResumen);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBoxFiltros);
            this.Controls.Add(this.lblTitulo);
            this.MinimumSize = new System.Drawing.Size(1000, 660);
            this.Name = "ReporteGastos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión - Reporte de Gastos";
            this.Load += new System.EventHandler(this.ReporteGastos_Load);
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxResumen.ResumeLayout(false);
            this.groupBoxResumen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.ComboBox cmbAno;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label lblSemana;
        private System.Windows.Forms.ComboBox cmbSemana;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblTipoGasto;
        private System.Windows.Forms.ComboBox cmbTipoGasto;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxResumen;
        private System.Windows.Forms.Label lblTotalGeneral;
        private System.Windows.Forms.Label lblTotalFijos;
        private System.Windows.Forms.Label lblTotalVariables;
        private System.Windows.Forms.Label lblCantidadRegistros;
        private System.Windows.Forms.Label lblPromedioGasto;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Button btnExportarExcel;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.RadioButton rbPersonalizado;
        private System.Windows.Forms.RadioButton rbAnual;
        private System.Windows.Forms.RadioButton rbMensual;
        private System.Windows.Forms.RadioButton rbSemanal;
        private System.Windows.Forms.RadioButton rbDiario;
        private System.Windows.Forms.Label lblTipoReporte;
    }
}