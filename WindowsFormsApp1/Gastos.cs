using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class Gastos : Form
    {
        // DataTable para simular las tablas de la base de datos
        private DataTable dtGastos;
        private DataTable dtCategorias;
        private bool modoEdicion = false;
        private const string firebaseUrl = "https://base-de-datos-sistemadegestion-default-rtdb.firebaseio.com/gastos.json";
        private const string firebaseBaseUrl = "https://base-de-datos-sistemadegestion-default-rtdb.firebaseio.com/gastos";

        // Clase auxiliar para gasto
        public class GastoFirebase
        {
            public string Nombre { get; set; }
            public decimal Importe { get; set; }
            public string TipoGasto { get; set; }
            public int IdCategoria { get; set; }
            public string NombreCategoria { get; set; }
            public DateTime FechaGasto { get; set; }
        }

        public Gastos()
        {
            InitializeComponent();
            InicializarDataTables();
        }

        // Guardar gasto en Firebase
        private async Task GuardarGastoEnFirebaseAsync(GastoFirebase gasto)
        {
            var json = JsonConvert.SerializeObject(gasto);
            using (var client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(firebaseUrl, content);
                string result = await response.Content.ReadAsStringAsync();
                // Puedes mostrar un mensaje si quieres
                // MessageBox.Show($"Respuesta de Firebase: {result}");
            }
        }

        // Leer gastos desde Firebase y mostrarlos en el grid
        private async Task LeerGastosDeFirebaseAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(firebaseUrl);
                string result = await response.Content.ReadAsStringAsync();
                dtGastos.Rows.Clear();
                if (!string.IsNullOrWhiteSpace(result) && result != "null")
                {
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, GastoFirebase>>(result);
                    if (dict != null)
                    {
                        int id = 1;
                        foreach (var kvp in dict)
                        {
                            var item = kvp.Value;
                            string firebaseId = kvp.Key;
                            dtGastos.Rows.Add(id++, firebaseId, item.Nombre, item.Importe, item.TipoGasto, item.IdCategoria, item.NombreCategoria, item.FechaGasto);
                        }
                    }
                }
            }
            CargarDatos();
        }

        private void Gastos_Load(object sender, EventArgs e)
        {
            // Configurar el formulario al cargar
            dtpFechaGasto.Value = DateTime.Now;
            cmbTipoGasto.SelectedIndex = 0; // Seleccionar "Fijo" por defecto
            CargarCategorias();
            LimpiarCampos();
            _ = LeerGastosDeFirebaseAsync();
        }

        private void InicializarDataTables()
        {
            // Crear la estructura de datos que simula la tabla Categorias
            dtCategorias = new DataTable();
            dtCategorias.Columns.Add("IdCategoria", typeof(int));
            dtCategorias.Columns.Add("NombreCategoria", typeof(string));

            // Agregar categorías de ejemplo
            dtCategorias.Rows.Add(1, "Servicios Públicos");
            dtCategorias.Rows.Add(2, "Mantenimiento");
            dtCategorias.Rows.Add(3, "Suministros de Oficina");
            dtCategorias.Rows.Add(4, "Personal");
            dtCategorias.Rows.Add(5, "Transporte");
            dtCategorias.Rows.Add(6, "Comunicaciones");
            dtCategorias.Rows.Add(7, "Capacitación");
            dtCategorias.Rows.Add(8, "Marketing");
            dtCategorias.Rows.Add(9, "Seguros");
            dtCategorias.Rows.Add(10, "Otros");

            // Crear la estructura de datos que simula la tabla Gastos
            dtGastos = new DataTable();
            dtGastos.Columns.Add("IdGasto", typeof(int));
            dtGastos.Columns.Add("FirebaseId", typeof(string)); // Nueva columna para el ID de Firebase
            dtGastos.Columns.Add("Nombre", typeof(string));
            dtGastos.Columns.Add("Importe", typeof(decimal));
            dtGastos.Columns.Add("TipoGasto", typeof(string));
            dtGastos.Columns.Add("IdCategoria", typeof(int));
            dtGastos.Columns.Add("NombreCategoria", typeof(string)); // Para mostrar en el grid
            dtGastos.Columns.Add("FechaGasto", typeof(DateTime));

            // Agregar algunos gastos de ejemplo
            // dtGastos.Rows.Add(1, "Electricidad Febrero", 3500.00m, "Fijo", 1, "Servicios Públicos", DateTime.Now.AddDays(-25));
            // dtGastos.Rows.Add(2, "Agua Febrero", 1200.00m, "Fijo", 1, "Servicios Públicos", DateTime.Now.AddDays(-20));
            // dtGastos.Rows.Add(3, "Reparación Equipo", 2800.00m, "Variable", 2, "Mantenimiento", DateTime.Now.AddDays(-15));
            // dtGastos.Rows.Add(4, "Papel y Papelería", 850.00m, "Variable", 3, "Suministros de Oficina", DateTime.Now.AddDays(-10));
            // dtGastos.Rows.Add(5, "Salarios Equipo", 45000.00m, "Fijo", 4, "Personal", DateTime.Now.AddDays(-5));
            // dtGastos.Rows.Add(6, "Gasolina Vehículos", 2200.00m, "Variable", 5, "Transporte", DateTime.Now.AddDays(-3));
            // dtGastos.Rows.Add(7, "Internet y Teléfono", 1800.00m, "Fijo", 6, "Comunicaciones", DateTime.Now.AddDays(-1));
        }

        private void CargarCategorias()
        {
            // Limpiar el ComboBox
            cmbCategoria.Items.Clear();
            cmbCategoria.DisplayMember = "NombreCategoria";
            cmbCategoria.ValueMember = "IdCategoria";
            cmbCategoria.DataSource = dtCategorias;
        }

        private void CargarDatos()
        {
            // Cargar los datos en el DataGridView
            dataGridView1.DataSource = dtGastos;
            
            // Configurar las columnas del DataGridView
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["IdGasto"].HeaderText = "ID";
                dataGridView1.Columns["IdGasto"].Width = 50;
                dataGridView1.Columns["FirebaseId"].Visible = false; // Ocultar el ID de Firebase
                dataGridView1.Columns["Nombre"].HeaderText = "Nombre del Gasto";
                dataGridView1.Columns["Nombre"].Width = 180;
                dataGridView1.Columns["Importe"].HeaderText = "Importe";
                dataGridView1.Columns["Importe"].DefaultCellStyle.Format = "C2";
                dataGridView1.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["Importe"].Width = 100;
                dataGridView1.Columns["TipoGasto"].HeaderText = "Tipo";
                dataGridView1.Columns["TipoGasto"].Width = 70;
                dataGridView1.Columns["IdCategoria"].Visible = false; // Ocultar FK
                dataGridView1.Columns["NombreCategoria"].HeaderText = "Categoría";
                dataGridView1.Columns["NombreCategoria"].Width = 120;
                dataGridView1.Columns["FechaGasto"].HeaderText = "Fecha";
                dataGridView1.Columns["FechaGasto"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns["FechaGasto"].Width = 90;
            }
        }

        private void LimpiarCampos()
        {
            txtIdGasto.Clear();
            txtNombre.Clear();
            txtImporte.Clear();
            cmbTipoGasto.SelectedIndex = 0;
            if (cmbCategoria.Items.Count > 0)
                cmbCategoria.SelectedIndex = 0;
            dtpFechaGasto.Value = DateTime.Now;
            modoEdicion = false;
            
            // Habilitar/deshabilitar botones
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private void CargarDatosEnCampos(DataRowView row)
        {
            if (row != null)
            {
                txtIdGasto.Text = row["IdGasto"].ToString();
                txtNombre.Text = row["Nombre"].ToString();
                txtImporte.Text = Convert.ToDecimal(row["Importe"]).ToString("F2");
                
                // Seleccionar el tipo de gasto
                int indexTipo = cmbTipoGasto.FindStringExact(row["TipoGasto"].ToString());
                if (indexTipo >= 0)
                    cmbTipoGasto.SelectedIndex = indexTipo;
                
                // Seleccionar la categoría
                int idCategoria = Convert.ToInt32(row["IdCategoria"]);
                cmbCategoria.SelectedValue = idCategoria;
                
                if (DateTime.TryParse(row["FechaGasto"].ToString(), out DateTime fecha))
                    dtpFechaGasto.Value = fecha;

                modoEdicion = true;
                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre del Gasto es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtImporte.Text))
            {
                MessageBox.Show("El campo Importe es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtImporte.Focus();
                return false;
            }

            if (!decimal.TryParse(txtImporte.Text, out decimal importe) || importe <= 0)
            {
                MessageBox.Show("El importe debe ser un número válido mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtImporte.Focus();
                return false;
            }

            if (importe > 999999999.99m)
            {
                MessageBox.Show("El importe excede el límite máximo permitido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtImporte.Focus();
                return false;
            }

            if (cmbTipoGasto.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un Tipo de Gasto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoGasto.Focus();
                return false;
            }

            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una Categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
                return false;
            }

            return true;
        }

        private int ObtenerNuevoId()
        {
            if (dtGastos.Rows.Count == 0)
                return 1;
            
            return dtGastos.AsEnumerable().Max(r => r.Field<int>("IdGasto")) + 1;
        }

        private string ObtenerNombreCategoria(int idCategoria)
        {
            DataRow categoria = dtCategorias.AsEnumerable()
                .FirstOrDefault(r => r.Field<int>("IdCategoria") == idCategoria);
            
            return categoria != null ? categoria["NombreCategoria"].ToString() : "";
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                var gasto = new GastoFirebase
                {
                    Nombre = txtNombre.Text.Trim(),
                    Importe = Convert.ToDecimal(txtImporte.Text),
                    TipoGasto = cmbTipoGasto.Text,
                    IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue),
                    NombreCategoria = cmbCategoria.Text,
                    FechaGasto = dtpFechaGasto.Value.Date
                };
                await GuardarGastoEnFirebaseAsync(gasto);
                MessageBox.Show("Gasto registrado correctamente en la nube.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LeerGastosDeFirebaseAsync();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el registro en la nube: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Eliminar gasto en Firebase
        private async Task EliminarGastoEnFirebaseAsync(string firebaseId)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{firebaseBaseUrl}/{firebaseId}.json");
            }
        }

        // Modificar gasto en Firebase
        private async Task ModificarGastoEnFirebaseAsync(string firebaseId, GastoFirebase gasto)
        {
            var json = JsonConvert.SerializeObject(gasto);
            using (var client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                // Firebase acepta PUT para reemplazo total
                var response = await client.PutAsync($"{firebaseBaseUrl}/{firebaseId}.json", content);
            }
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            if (!modoEdicion || dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarCampos())
                return;

            try
            {
                int id = int.Parse(txtIdGasto.Text);
                DataRow fila = dtGastos.AsEnumerable().FirstOrDefault(r => r.Field<int>("IdGasto") == id);
                if (fila != null)
                {
                    string firebaseId = fila["FirebaseId"]?.ToString();
                    var gasto = new GastoFirebase
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Importe = Convert.ToDecimal(txtImporte.Text),
                        TipoGasto = cmbTipoGasto.Text,
                        IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue),
                        NombreCategoria = cmbCategoria.Text,
                        FechaGasto = dtpFechaGasto.Value.Date
                    };
                    if (!string.IsNullOrEmpty(firebaseId))
                    {
                        await ModificarGastoEnFirebaseAsync(firebaseId, gasto);
                    }
                    fila["Nombre"] = gasto.Nombre;
                    fila["Importe"] = gasto.Importe;
                    fila["TipoGasto"] = gasto.TipoGasto;
                    fila["IdCategoria"] = gasto.IdCategoria;
                    fila["NombreCategoria"] = gasto.NombreCategoria;
                    fila["FechaGasto"] = gasto.FechaGasto;

                    MessageBox.Show("Gasto modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!modoEdicion || dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este gasto?", 
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtIdGasto.Text);
                    DataRow fila = dtGastos.AsEnumerable().FirstOrDefault(r => r.Field<int>("IdGasto") == id);
                    if (fila != null)
                    {
                        string firebaseId = fila["FirebaseId"]?.ToString();
                        if (!string.IsNullOrEmpty(firebaseId))
                        {
                            await EliminarGastoEnFirebaseAsync(firebaseId);
                        }
                        dtGastos.Rows.Remove(fila);
                        MessageBox.Show("Gasto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarRegistros();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BuscarRegistros();
                e.Handled = true;
            }
        }

        private void BuscarRegistros()
        {
            string filtro = txtBuscar.Text.Trim();
            
            if (string.IsNullOrEmpty(filtro))
            {
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = "";
            }
            else
            {
                string filtroCompleto = $"Nombre LIKE '%{filtro}%' OR " +
                                      $"TipoGasto LIKE '%{filtro}%' OR " +
                                      $"NombreCategoria LIKE '%{filtro}%' OR " +
                                      $"Convert(Importe, 'System.String') LIKE '%{filtro}%'";
                
                ((DataTable)dataGridView1.DataSource).DefaultView.RowFilter = filtroCompleto;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.DataBoundItem != null)
            {
                DataRowView row = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                CargarDatosEnCampos(row);
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, punto decimal y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
