using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Donaciones : Form
    {
        // DataTable para simular las tablas de la base de datos
        private DataTable dtDonaciones;
        private DataTable dtClientesDonantes;
        private bool modoEdicion = false;

        public Donaciones()
        {
            InitializeComponent();
            InicializarDataTables();
        }

        private void Donaciones_Load(object sender, EventArgs e)
        {
            // Configurar el formulario al cargar
            dtpFechaDonacion.Value = DateTime.Now;
            CargarClientesDonantes();
            CargarDatos();
            LimpiarCampos();
        }

        private void InicializarDataTables()
        {
            // Crear la estructura de datos que simula la tabla ClientesDonantes
            dtClientesDonantes = new DataTable();
            dtClientesDonantes.Columns.Add("IdClienteDonante", typeof(int));
            dtClientesDonantes.Columns.Add("NombreRazonSocial", typeof(string));
            dtClientesDonantes.Columns.Add("RegistroFiscal", typeof(string));
            dtClientesDonantes.Columns.Add("Telefono", typeof(string));
            dtClientesDonantes.Columns.Add("Correo", typeof(string));

            // Agregar algunos clientes/donantes de ejemplo
            dtClientesDonantes.Rows.Add(1, "Juan Pérez García", "PEGJ800101ABC", "555-1234", "juan.perez@email.com");
            dtClientesDonantes.Rows.Add(2, "Empresas ABC S.A. de C.V.", "EAB990515XYZ", "555-5678", "contacto@empresasabc.com");
            dtClientesDonantes.Rows.Add(3, "Ana López Martínez", "LOMA850320DEF", "555-9012", "ana.lopez@email.com");
            dtClientesDonantes.Rows.Add(4, "Fundación Benéfica XYZ", "FBX070815HIJ", "555-3456", "info@fundacionxyz.org");

            // Crear la estructura de datos que simula la tabla Donaciones
            dtDonaciones = new DataTable();
            dtDonaciones.Columns.Add("IdDonacion", typeof(int));
            dtDonaciones.Columns.Add("IdClienteDonante", typeof(int));
            dtDonaciones.Columns.Add("NombreCompleto", typeof(string)); // Para mostrar en el grid
            dtDonaciones.Columns.Add("Importe", typeof(decimal));
            dtDonaciones.Columns.Add("Factura", typeof(string));
            dtDonaciones.Columns.Add("FechaDonacion", typeof(DateTime));

            // Agregar algunas donaciones de ejemplo
            dtDonaciones.Rows.Add(1, 1, "Juan Pérez García", 5000.00m, "FAC-001", DateTime.Now.AddDays(-15));
            dtDonaciones.Rows.Add(2, 2, "Empresas ABC S.A. de C.V.", 25000.00m, "FAC-002", DateTime.Now.AddDays(-10));
            dtDonaciones.Rows.Add(3, 1, "Juan Pérez García", 3000.00m, "", DateTime.Now.AddDays(-5));
            dtDonaciones.Rows.Add(4, 3, "Ana López Martínez", 7500.00m, "FAC-003", DateTime.Now.AddDays(-3));
            dtDonaciones.Rows.Add(5, 4, "Fundación Benéfica XYZ", 15000.00m, "FAC-004", DateTime.Now.AddDays(-1));
        }

        private void CargarClientesDonantes()
        {
            // Limpiar el ComboBox
            cmbClienteDonante.Items.Clear();
            cmbClienteDonante.DisplayMember = "NombreRazonSocial";
            cmbClienteDonante.ValueMember = "IdClienteDonante";
            cmbClienteDonante.DataSource = dtClientesDonantes;
        }

        private void CargarDatos()
        {
            // Cargar los datos en el DataGridView
            dataGridView1.DataSource = dtDonaciones;
            
            // Configurar las columnas del DataGridView
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["IdDonacion"].HeaderText = "ID";
                dataGridView1.Columns["IdDonacion"].Width = 50;
                dataGridView1.Columns["IdClienteDonante"].Visible = false; // Ocultar FK
                dataGridView1.Columns["NombreCompleto"].HeaderText = "Cliente/Donante";
                dataGridView1.Columns["NombreCompleto"].Width = 200;
                dataGridView1.Columns["Importe"].HeaderText = "Importe";
                dataGridView1.Columns["Importe"].DefaultCellStyle.Format = "C2";
                dataGridView1.Columns["Importe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dataGridView1.Columns["Importe"].Width = 100;
                dataGridView1.Columns["Factura"].HeaderText = "Factura";
                dataGridView1.Columns["Factura"].Width = 100;
                dataGridView1.Columns["FechaDonacion"].HeaderText = "Fecha Donación";
                dataGridView1.Columns["FechaDonacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns["FechaDonacion"].Width = 100;
            }
        }

        private void LimpiarCampos()
        {
            txtIdDonacion.Clear();
            if (cmbClienteDonante.Items.Count > 0)
                cmbClienteDonante.SelectedIndex = 0;
            txtImporte.Clear();
            txtFactura.Clear();
            dtpFechaDonacion.Value = DateTime.Now;
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
                txtIdDonacion.Text = row["IdDonacion"].ToString();
                
                // Seleccionar el cliente/donante en el combo
                int idCliente = Convert.ToInt32(row["IdClienteDonante"]);
                cmbClienteDonante.SelectedValue = idCliente;
                
                txtImporte.Text = Convert.ToDecimal(row["Importe"]).ToString("F2");
                txtFactura.Text = row["Factura"].ToString();
                
                if (DateTime.TryParse(row["FechaDonacion"].ToString(), out DateTime fecha))
                    dtpFechaDonacion.Value = fecha;

                modoEdicion = true;
                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private bool ValidarCampos()
        {
            if (cmbClienteDonante.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un Cliente/Donante.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbClienteDonante.Focus();
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

            return true;
        }

        private int ObtenerNuevoId()
        {
            if (dtDonaciones.Rows.Count == 0)
                return 1;
            
            return dtDonaciones.AsEnumerable().Max(r => r.Field<int>("IdDonacion")) + 1;
        }

        private string ObtenerNombreCliente(int idCliente)
        {
            DataRow cliente = dtClientesDonantes.AsEnumerable()
                .FirstOrDefault(r => r.Field<int>("IdClienteDonante") == idCliente);
            
            return cliente != null ? cliente["NombreRazonSocial"].ToString() : "";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                DataRow nuevaFila = dtDonaciones.NewRow();
                nuevaFila["IdDonacion"] = ObtenerNuevoId();
                nuevaFila["IdClienteDonante"] = Convert.ToInt32(cmbClienteDonante.SelectedValue);
                nuevaFila["NombreCompleto"] = cmbClienteDonante.Text;
                nuevaFila["Importe"] = Convert.ToDecimal(txtImporte.Text);
                nuevaFila["Factura"] = txtFactura.Text.Trim();
                nuevaFila["FechaDonacion"] = dtpFechaDonacion.Value.Date;

                dtDonaciones.Rows.Add(nuevaFila);
                
                MessageBox.Show("Donación registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
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
                int id = int.Parse(txtIdDonacion.Text);
                DataRow fila = dtDonaciones.AsEnumerable().FirstOrDefault(r => r.Field<int>("IdDonacion") == id);
                
                if (fila != null)
                {
                    fila["IdClienteDonante"] = Convert.ToInt32(cmbClienteDonante.SelectedValue);
                    fila["NombreCompleto"] = cmbClienteDonante.Text;
                    fila["Importe"] = Convert.ToDecimal(txtImporte.Text);
                    fila["Factura"] = txtFactura.Text.Trim();
                    fila["FechaDonacion"] = dtpFechaDonacion.Value.Date;

                    MessageBox.Show("Donación modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el registro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!modoEdicion || dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar esta donación?", 
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtIdDonacion.Text);
                    DataRow fila = dtDonaciones.AsEnumerable().FirstOrDefault(r => r.Field<int>("IdDonacion") == id);
                    
                    if (fila != null)
                    {
                        dtDonaciones.Rows.Remove(fila);
                        MessageBox.Show("Donación eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string filtroCompleto = $"NombreCompleto LIKE '%{filtro}%' OR " +
                                      $"Factura LIKE '%{filtro}%' OR " +
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
