using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ReporteGastos : Form
    {
        // DataTables para datos
        private DataTable dtGastos;
        private DataTable dtCategorias;
        private DataTable dtReporte;

        public ReporteGastos()
        {
            InitializeComponent();
            InicializarDatos();
        }

        private void ReporteGastos_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();
            CargarCombos();
            ConfigurarFiltrosMensual(); // Por defecto mensual
        }

        private void InicializarDatos()
        {
            // Simular datos de gastos (en un sistema real vendría de la base de datos)
            dtGastos = new DataTable();
            dtGastos.Columns.Add("IdGasto", typeof(int));
            dtGastos.Columns.Add("Nombre", typeof(string));
            dtGastos.Columns.Add("Importe", typeof(decimal));
            dtGastos.Columns.Add("TipoGasto", typeof(string));
            dtGastos.Columns.Add("IdCategoria", typeof(int));
            dtGastos.Columns.Add("NombreCategoria", typeof(string));
            dtGastos.Columns.Add("FechaGasto", typeof(DateTime));

            // Agregar datos de ejemplo con diferentes fechas para probar reportes
            Random random = new Random();
            DateTime fechaBase = DateTime.Now.AddMonths(-6);

            // Generar gastos para los últimos 6 meses
            for (int i = 0; i < 100; i++)
            {
                DateTime fechaGasto = fechaBase.AddDays(random.Next(0, 180));
                string[] categorias = { "Servicios Públicos", "Mantenimiento", "Suministros de Oficina", 
                                      "Personal", "Transporte", "Comunicaciones", "Marketing", "Seguros" };
                string[] tipos = { "Fijo", "Variable" };
                string[] nombres = { "Electricidad", "Agua", "Gas", "Internet", "Teléfono", "Gasolina", 
                                   "Papelería", "Limpieza", "Reparaciones", "Salarios", "Publicidad", "Seguros" };

                int categoriaIndex = random.Next(categorias.Length);
                string categoria = categorias[categoriaIndex];
                string tipo = tipos[random.Next(tipos.Length)];
                string nombre = nombres[random.Next(nombres.Length)];
                decimal importe = (decimal)(random.NextDouble() * 5000 + 100);

                dtGastos.Rows.Add(i + 1, $"{nombre} {fechaGasto:MMM}", Math.Round(importe, 2), 
                    tipo, categoriaIndex + 1, categoria, fechaGasto);
            }

            // Crear DataTable para categorías
            dtCategorias = new DataTable();
            dtCategorias.Columns.Add("IdCategoria", typeof(int));
            dtCategorias.Columns.Add("NombreCategoria", typeof(string));

            string[] listaCategorias = { "Servicios Públicos", "Mantenimiento", "Suministros de Oficina", 
                                       "Personal", "Transporte", "Comunicaciones", "Marketing", "Seguros" };
            for (int i = 0; i < listaCategorias.Length; i++)
            {
                dtCategorias.Rows.Add(i + 1, listaCategorias[i]);
            }
        }

        private void ConfigurarFormulario()
        {
            // Configurar DataGridView
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarCombos()
        {
            // Cargar años (últimos 5 años y próximos 2)
            cmbAno.Items.Clear();
            for (int year = DateTime.Now.Year - 5; year <= DateTime.Now.Year + 2; year++)
            {
                cmbAno.Items.Add(year);
            }
            cmbAno.SelectedItem = DateTime.Now.Year;

            // Cargar meses
            cmbMes.Items.Clear();
            string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                              "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };
            for (int i = 0; i < meses.Length; i++)
            {
                cmbMes.Items.Add(new { Texto = meses[i], Valor = i + 1 });
            }
            cmbMes.DisplayMember = "Texto";
            cmbMes.ValueMember = "Valor";
            cmbMes.SelectedIndex = DateTime.Now.Month - 1;

            // Cargar categorías
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.Add(new { Texto = "Todas las categorías", Valor = -1 });
            foreach (DataRow row in dtCategorias.Rows)
            {
                cmbCategoria.Items.Add(new { 
                    Texto = row["NombreCategoria"].ToString(), 
                    Valor = Convert.ToInt32(row["IdCategoria"]) 
                });
            }
            cmbCategoria.DisplayMember = "Texto";
            cmbCategoria.ValueMember = "Valor";
            cmbCategoria.SelectedIndex = 0;

            // Cargar tipos de gasto
            cmbTipoGasto.Items.Clear();
            cmbTipoGasto.Items.Add(new { Texto = "Todos los tipos", Valor = "" });
            cmbTipoGasto.Items.Add(new { Texto = "Fijo", Valor = "Fijo" });
            cmbTipoGasto.Items.Add(new { Texto = "Variable", Valor = "Variable" });
            cmbTipoGasto.DisplayMember = "Texto";
            cmbTipoGasto.ValueMember = "Valor";
            cmbTipoGasto.SelectedIndex = 0;
        }

        private void TipoReporte_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return;

            // Habilitar/deshabilitar controles según el tipo de reporte
            if (rb == rbDiario)
            {
                ConfigurarFiltrosDiario();
            }
            else if (rb == rbSemanal)
            {
                ConfigurarFiltrosSemanal();
            }
            else if (rb == rbMensual)
            {
                ConfigurarFiltrosMensual();
            }
            else if (rb == rbAnual)
            {
                ConfigurarFiltrosAnual();
            }
            else if (rb == rbPersonalizado)
            {
                ConfigurarFiltrosPersonalizado();
            }
        }

        private void ConfigurarFiltrosDiario()
        {
            cmbAno.Enabled = true;
            cmbMes.Enabled = true;
            cmbSemana.Enabled = false;
            dtpFechaInicio.Enabled = true;
            dtpFechaFin.Enabled = false;

            // Configurar para fecha específica
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
        }

        private void ConfigurarFiltrosSemanal()
        {
            cmbAno.Enabled = true;
            cmbMes.Enabled = true;
            cmbSemana.Enabled = true;
            dtpFechaInicio.Enabled = false;
            dtpFechaFin.Enabled = false;

            CargarSemanas();
        }

        private void ConfigurarFiltrosMensual()
        {
            cmbAno.Enabled = true;
            cmbMes.Enabled = true;
            cmbSemana.Enabled = false;
            dtpFechaInicio.Enabled = false;
            dtpFechaFin.Enabled = false;
        }

        private void ConfigurarFiltrosAnual()
        {
            cmbAno.Enabled = true;
            cmbMes.Enabled = false;
            cmbSemana.Enabled = false;
            dtpFechaInicio.Enabled = false;
            dtpFechaFin.Enabled = false;
        }

        private void ConfigurarFiltrosPersonalizado()
        {
            cmbAno.Enabled = false;
            cmbMes.Enabled = false;
            cmbSemana.Enabled = false;
            dtpFechaInicio.Enabled = true;
            dtpFechaFin.Enabled = true;

            // Configurar rango del último mes por defecto
            dtpFechaInicio.Value = DateTime.Now.AddDays(-30);
            dtpFechaFin.Value = DateTime.Now;
        }

        private void CargarSemanas()
        {
            cmbSemana.Items.Clear();
            
            if (cmbAno.SelectedItem == null || cmbMes.SelectedItem == null) return;

            int año = (int)cmbAno.SelectedItem;
            int mes = ((dynamic)cmbMes.SelectedItem).Valor;

            DateTime primerDia = new DateTime(año, mes, 1);
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);

            // Calcular semanas del mes
            int semana = 1;
            DateTime inicioSemana = primerDia;

            while (inicioSemana <= ultimoDia)
            {
                DateTime finSemana = inicioSemana.AddDays(6);
                if (finSemana > ultimoDia) finSemana = ultimoDia;

                cmbSemana.Items.Add(new { 
                    Texto = $"Semana {semana} ({inicioSemana:dd} - {finSemana:dd})",
                    Inicio = inicioSemana,
                    Fin = finSemana
                });

                inicioSemana = inicioSemana.AddDays(7);
                semana++;
            }

            cmbSemana.DisplayMember = "Texto";
            if (cmbSemana.Items.Count > 0)
                cmbSemana.SelectedIndex = 0;
        }

        private void cmbAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbSemanal.Checked)
                CargarSemanas();
        }

        private void cmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbSemanal.Checked)
                CargarSemanas();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                GenerarReporte();
                CalcularResumen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarReporte()
        {
            // Obtener fechas según el tipo de reporte
            DateTime fechaInicio, fechaFin;
            ObtenerRangoFechas(out fechaInicio, out fechaFin);

            // Filtrar datos
            var gastosQuery = dtGastos.AsEnumerable()
                .Where(row => 
                {
                    DateTime fechaGasto = row.Field<DateTime>("FechaGasto");
                    return fechaGasto >= fechaInicio && fechaGasto <= fechaFin;
                });

            // Aplicar filtro de categoría
            dynamic categoriaSeleccionada = cmbCategoria.SelectedItem;
            if (categoriaSeleccionada != null && categoriaSeleccionada.Valor != -1)
            {
                gastosQuery = gastosQuery.Where(row => 
                    row.Field<int>("IdCategoria") == categoriaSeleccionada.Valor);
            }

            // Aplicar filtro de tipo de gasto
            dynamic tipoSeleccionado = cmbTipoGasto.SelectedItem;
            if (tipoSeleccionado != null && !string.IsNullOrEmpty(tipoSeleccionado.Valor))
            {
                gastosQuery = gastosQuery.Where(row => 
                    row.Field<string>("TipoGasto") == tipoSeleccionado.Valor);
            }

            // Crear DataTable del reporte
            if (gastosQuery.Any())
            {
                dtReporte = gastosQuery.CopyToDataTable();
            }
            else
            {
                dtReporte = dtGastos.Clone(); // Estructura vacía
            }

            // Configurar DataGridView
            dataGridView1.DataSource = dtReporte;
            ConfigurarColumnasReporte();

            if (dtReporte.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron gastos para los filtros seleccionados.", 
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ObtenerRangoFechas(out DateTime fechaInicio, out DateTime fechaFin)
        {
            if (rbDiario.Checked)
            {
                fechaInicio = dtpFechaInicio.Value.Date;
                fechaFin = fechaInicio.AddDays(1).AddTicks(-1);
            }
            else if (rbSemanal.Checked)
            {
                dynamic semanaSeleccionada = cmbSemana.SelectedItem;
                if (semanaSeleccionada != null)
                {
                    fechaInicio = ((DateTime)semanaSeleccionada.Inicio).Date;
                    fechaFin = ((DateTime)semanaSeleccionada.Fin).Date.AddDays(1).AddTicks(-1);
                }
                else
                {
                    fechaInicio = DateTime.Now.Date;
                    fechaFin = fechaInicio.AddDays(1).AddTicks(-1);
                }
            }
            else if (rbMensual.Checked)
            {
                int año = (int)cmbAno.SelectedItem;
                int mes = ((dynamic)cmbMes.SelectedItem).Valor;
                fechaInicio = new DateTime(año, mes, 1);
                fechaFin = fechaInicio.AddMonths(1).AddTicks(-1);
            }
            else if (rbAnual.Checked)
            {
                int año = (int)cmbAno.SelectedItem;
                fechaInicio = new DateTime(año, 1, 1);
                fechaFin = new DateTime(año, 12, 31, 23, 59, 59);
            }
            else // Personalizado
            {
                fechaInicio = dtpFechaInicio.Value.Date;
                fechaFin = dtpFechaFin.Value.Date.AddDays(1).AddTicks(-1);
            }
        }

        private void ConfigurarColumnasReporte()
        {
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["IdGasto"].HeaderText = "ID";
                dataGridView1.Columns["IdGasto"].Width = 50;
                dataGridView1.Columns["Nombre"].HeaderText = "Descripción";
                dataGridView1.Columns["Nombre"].Width = 200;
                dataGridView1.Columns["Importe"].HeaderText = "Importe";
                dataGridView1.Columns["Importe"].DefaultCellStyle.Format = "C2";
                dataGridView1.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["Importe"].Width = 100;
                dataGridView1.Columns["TipoGasto"].HeaderText = "Tipo";
                dataGridView1.Columns["TipoGasto"].Width = 80;
                dataGridView1.Columns["IdCategoria"].Visible = false;
                dataGridView1.Columns["NombreCategoria"].HeaderText = "Categoría";
                dataGridView1.Columns["NombreCategoria"].Width = 150;
                dataGridView1.Columns["FechaGasto"].HeaderText = "Fecha";
                dataGridView1.Columns["FechaGasto"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns["FechaGasto"].Width = 100;
            }
        }

        private void CalcularResumen()
        {
            if (dtReporte == null || dtReporte.Rows.Count == 0)
            {
                lblTotalGeneral.Text = "Total: $0.00";
                lblTotalFijos.Text = "Fijos: $0.00";
                lblTotalVariables.Text = "Variables: $0.00";
                lblCantidadRegistros.Text = "Registros: 0";
                lblPromedioGasto.Text = "Promedio: $0.00";
                return;
            }

            decimal totalGeneral = 0;
            decimal totalFijos = 0;
            decimal totalVariables = 0;
            int cantidadRegistros = dtReporte.Rows.Count;

            foreach (DataRow row in dtReporte.Rows)
            {
                decimal importe = Convert.ToDecimal(row["Importe"]);
                string tipo = row["TipoGasto"].ToString();

                totalGeneral += importe;
                if (tipo == "Fijo")
                    totalFijos += importe;
                else
                    totalVariables += importe;
            }

            decimal promedio = cantidadRegistros > 0 ? totalGeneral / cantidadRegistros : 0;

            lblTotalGeneral.Text = $"Total: {totalGeneral:C2}";
            lblTotalFijos.Text = $"Fijos: {totalFijos:C2}";
            lblTotalVariables.Text = $"Variables: {totalVariables:C2}";
            lblCantidadRegistros.Text = $"Registros: {cantidadRegistros}";
            lblPromedioGasto.Text = $"Promedio: {promedio:C2}";
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dtReporte == null || dtReporte.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar. Genere un reporte primero.", 
                    "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*";
            saveDialog.Title = "Exportar Reporte a CSV";
            saveDialog.FileName = $"ReporteGastos_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportarACSV(saveDialog.FileName);
                    MessageBox.Show($"Reporte exportado exitosamente a:\n{saveDialog.FileName}", 
                        "Exportación completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportarACSV(string rutaArchivo)
        {
            StringBuilder csv = new StringBuilder();
            
            // Escribir encabezados
            csv.AppendLine("ID,Descripción,Importe,Tipo,Categoría,Fecha");
            
            // Escribir datos
            foreach (DataRow row in dtReporte.Rows)
            {
                csv.AppendLine($"{row["IdGasto"]}," +
                              $"\"{row["Nombre"]}\"," +
                              $"{row["Importe"]}," +
                              $"\"{row["TipoGasto"]}\"," +
                              $"\"{row["NombreCategoria"]}\"," +
                              $"{Convert.ToDateTime(row["FechaGasto"]):dd/MM/yyyy}");
            }
            
            File.WriteAllText(rutaArchivo, csv.ToString(), Encoding.UTF8);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dtReporte == null || dtReporte.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir. Genere un reporte primero.", 
                    "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simulación de impresión (en un sistema real usarías PrintDocument)
            MessageBox.Show("Funcionalidad de impresión no implementada en esta demo.\n\n" +
                           "En un sistema completo, aquí se abriría el diálogo de impresión " +
                           "para imprimir el reporte actual.", 
                           "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Limpiar resultados
            dataGridView1.DataSource = null;
            dtReporte = null;
            
            // Resetear resumen
            lblTotalGeneral.Text = "Total: $0.00";
            lblTotalFijos.Text = "Fijos: $0.00";
            lblTotalVariables.Text = "Variables: $0.00";
            lblCantidadRegistros.Text = "Registros: 0";
            lblPromedioGasto.Text = "Promedio: $0.00";
            
            // Resetear filtros
            rbMensual.Checked = true;
            cmbAno.SelectedItem = DateTime.Now.Year;
            cmbMes.SelectedIndex = DateTime.Now.Month - 1;
            cmbCategoria.SelectedIndex = 0;
            cmbTipoGasto.SelectedIndex = 0;
            
            MessageBox.Show("Reporte limpiado correctamente.", "Limpiar", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
