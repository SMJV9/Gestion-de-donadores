using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AltasClientes : Form
    {
        // DataTable para simular la base de datos (reemplazar con conexión real)
        private DataTable dtClientesDonantes;
        private bool modoEdicion = false;

        public AltasClientes()
        {
            InitializeComponent();
            InicializarDataTable();
        }

        private void AltasClientes_Load(object sender, EventArgs e)
        {
            // Configurar el formulario al cargar
            dtpFechaRegistro.Value = DateTime.Now;
            cmbFormaPago.SelectedIndex = 0; // Seleccionar "Efectivo" por defecto
            CargarDatos();
            LimpiarCampos();
        }

        private void InicializarDataTable()
        {
            // Crear la estructura de datos que simula la tabla ClientesDonantes
            dtClientesDonantes = new DataTable();
            dtClientesDonantes.Columns.Add("IdClienteDonante", typeof(int));
            dtClientesDonantes.Columns.Add("NombreRazonSocial", typeof(string));
            dtClientesDonantes.Columns.Add("RegistroFiscal", typeof(string));
            dtClientesDonantes.Columns.Add("Direccion", typeof(string));
            dtClientesDonantes.Columns.Add("Telefono", typeof(string));
            dtClientesDonantes.Columns.Add("Correo", typeof(string));
            dtClientesDonantes.Columns.Add("Contacto", typeof(string));
            dtClientesDonantes.Columns.Add("FormaPago", typeof(string));
            dtClientesDonantes.Columns.Add("FechaRegistro", typeof(DateTime));

            // Sin datos de ejemplo
        }

        private void CargarDatos()
        {
            // Cargar los datos en el DataGridView
            dataGridView1.DataSource = dtClientesDonantes;
            
            // Configurar las columnas del DataGridView
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["IdClienteDonante"].HeaderText = "ID";
                dataGridView1.Columns["IdClienteDonante"].Width = 50;
                dataGridView1.Columns["NombreRazonSocial"].HeaderText = "Nombre/Razón Social";
                dataGridView1.Columns["RegistroFiscal"].HeaderText = "RFC/CURP";
                dataGridView1.Columns["Direccion"].HeaderText = "Dirección";
                dataGridView1.Columns["Telefono"].HeaderText = "Teléfono";
                dataGridView1.Columns["Correo"].HeaderText = "Correo";
                dataGridView1.Columns["Contacto"].HeaderText = "Contacto";
                dataGridView1.Columns["FormaPago"].HeaderText = "Forma de Pago";
                dataGridView1.Columns["FechaRegistro"].HeaderText = "Fecha Registro";
                dataGridView1.Columns["FechaRegistro"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void LimpiarCampos()
        {
            txtIdClienteDonante.Clear();
            txtNombreRazonSocial.Clear();
            txtRegistroFiscal.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtContacto.Clear();
            cmbFormaPago.SelectedIndex = 0;
            dtpFechaRegistro.Value = DateTime.Now;
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
                txtIdClienteDonante.Text = row["IdClienteDonante"].ToString();
                txtNombreRazonSocial.Text = row["NombreRazonSocial"].ToString();
                txtRegistroFiscal.Text = row["RegistroFiscal"].ToString();
                txtDireccion.Text = row["Direccion"].ToString();
                txtTelefono.Text = row["Telefono"].ToString();
                txtCorreo.Text = row["Correo"].ToString();
                txtContacto.Text = row["Contacto"].ToString();
                
                // Seleccionar la forma de pago en el combo
                int index = cmbFormaPago.FindStringExact(row["FormaPago"].ToString());
                if (index >= 0)
                    cmbFormaPago.SelectedIndex = index;
                
                if (DateTime.TryParse(row["FechaRegistro"].ToString(), out DateTime fecha))
                    dtpFechaRegistro.Value = fecha;

                modoEdicion = true;
                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreRazonSocial.Text))
            {
                MessageBox.Show("El campo Nombre/Razón Social es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreRazonSocial.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRegistroFiscal.Text))
            {
                MessageBox.Show("El campo RFC/CURP es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRegistroFiscal.Focus();
                return false;
            }

            // Validar formato de correo si se proporcionó
            if (!string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                try
                {
                    var email = new System.Net.Mail.MailAddress(txtCorreo.Text);
                }
                catch
                {
                    MessageBox.Show("El formato del correo electrónico no es válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCorreo.Focus();
                    return false;
                }
            }

            return true;
        }

        private int ObtenerNuevoId()
        {
            if (dtClientesDonantes.Rows.Count == 0)
                return 1;
            
            return dtClientesDonantes.AsEnumerable().Max(r => r.Field<int>("IdClienteDonante")) + 1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                DataRow nuevaFila = dtClientesDonantes.NewRow();
                nuevaFila["IdClienteDonante"] = ObtenerNuevoId();
                nuevaFila["NombreRazonSocial"] = txtNombreRazonSocial.Text.Trim();
                nuevaFila["RegistroFiscal"] = txtRegistroFiscal.Text.Trim();
                nuevaFila["Direccion"] = txtDireccion.Text.Trim();
                nuevaFila["Telefono"] = txtTelefono.Text.Trim();
                nuevaFila["Correo"] = txtCorreo.Text.Trim();
                nuevaFila["Contacto"] = txtContacto.Text.Trim();
                nuevaFila["FormaPago"] = cmbFormaPago.Text;
                nuevaFila["FechaRegistro"] = dtpFechaRegistro.Value;

                dtClientesDonantes.Rows.Add(nuevaFila);
                
                MessageBox.Show("Cliente/Donante agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                int id = int.Parse(txtIdClienteDonante.Text);
                DataRow fila = dtClientesDonantes.AsEnumerable().FirstOrDefault(r => r.Field<int>("IdClienteDonante") == id);
                
                if (fila != null)
                {
                    fila["NombreRazonSocial"] = txtNombreRazonSocial.Text.Trim();
                    fila["RegistroFiscal"] = txtRegistroFiscal.Text.Trim();
                    fila["Direccion"] = txtDireccion.Text.Trim();
                    fila["Telefono"] = txtTelefono.Text.Trim();
                    fila["Correo"] = txtCorreo.Text.Trim();
                    fila["Contacto"] = txtContacto.Text.Trim();
                    fila["FormaPago"] = cmbFormaPago.Text;
                    fila["FechaRegistro"] = dtpFechaRegistro.Value;

                    MessageBox.Show("Cliente/Donante modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este registro?", 
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtIdClienteDonante.Text);
                    DataRow fila = dtClientesDonantes.AsEnumerable().FirstOrDefault(r => r.Field<int>("IdClienteDonante") == id);
                    
                    if (fila != null)
                    {
                        dtClientesDonantes.Rows.Remove(fila);
                        MessageBox.Show("Cliente/Donante eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string filtroCompleto = $"NombreRazonSocial LIKE '%{filtro}%' OR " +
                                      $"RegistroFiscal LIKE '%{filtro}%' OR " +
                                      $"Direccion LIKE '%{filtro}%' OR " +
                                      $"Telefono LIKE '%{filtro}%' OR " +
                                      $"Correo LIKE '%{filtro}%' OR " +
                                      $"Contacto LIKE '%{filtro}%'";
                
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
    }
}
