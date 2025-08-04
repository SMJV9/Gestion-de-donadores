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
    public partial class Proveedores : Form
    {
        // DataTable para simular la tabla de la base de datos
        private DataTable dtProveedores;
        private bool modoEdicion = false;

        public Proveedores()
        {
            InitializeComponent();
            InicializarDataTable();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            // Configurar el formulario al cargar
            cmbCategoria.SelectedIndex = 0; // Seleccionar primera categoría por defecto
            CargarDatos();
            LimpiarCampos();
        }

        private void InicializarDataTable()
        {
            // Crear la estructura de datos que simula la tabla Proveedores
            dtProveedores = new DataTable();
            dtProveedores.Columns.Add("IdProveedor", typeof(int));
            dtProveedores.Columns.Add("NombreRazon", typeof(string));
            dtProveedores.Columns.Add("Direccion", typeof(string));
            dtProveedores.Columns.Add("Correo", typeof(string));
            dtProveedores.Columns.Add("Categoria", typeof(string));

            // Agregar proveedores de ejemplo
            dtProveedores.Rows.Add(1, "Papelería San Miguel", "Av. Central #123, Col. Centro", "ventas@papeleriasanmiguel.com", "Papelería");
            dtProveedores.Rows.Add(2, "Transportes García S.A.", "Blvd. Industrial #456", "contacto@transportesgarcia.com", "Transporte");
            dtProveedores.Rows.Add(3, "Servicios Técnicos XYZ", "Calle Tecnología #789", "info@serviciosxyz.com", "Servicios");
            dtProveedores.Rows.Add(4, "CompuTech Solutions", "Torre Corporativa, Piso 5", "soporte@computech.com", "Tecnología");
            dtProveedores.Rows.Add(5, "Constructora Moderna", "Zona Industrial Norte", "proyectos@constructoramoderna.com", "Construcción");
            dtProveedores.Rows.Add(6, "LimpiezaTotal S.A.", "Av. Servicios #321", "admin@limpiezatotal.com", "Limpieza");
            dtProveedores.Rows.Add(7, "Distribuidora de Alimentos", "Mercado Central Local 15", "pedidos@distalimentos.com", "Alimentación");
            dtProveedores.Rows.Add(8, "Mantenimiento Industrial", "Parque Industrial #567", "servicios@mantind.com", "Mantenimiento");
            dtProveedores.Rows.Add(9, "Consultoría Empresarial ABC", "Centro Empresarial, Of. 304", "contacto@consultoriaabc.com", "Consultoría");
            dtProveedores.Rows.Add(10, "Suministros Varios", "Av. Comercial #890", "ventas@suministrosvarios.com", "Otros");
            dtProveedores.Rows.Add(11, "Oficina Express", "Plaza Comercial Local 12", "pedidos@oficinaexpress.com", "Papelería");
            dtProveedores.Rows.Add(12, "TechServ Pro", "Zona Rosa #445", "help@techservpro.com", "Tecnología");
        }

        private void CargarDatos()
        {
            // Cargar los datos en el DataGridView
            dataGridView1.DataSource = dtProveedores;
            
            // Configurar las columnas del DataGridView
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["IdProveedor"].HeaderText = "ID";
                dataGridView1.Columns["IdProveedor"].Width = 50;
                dataGridView1.Columns["NombreRazon"].HeaderText = "Nombre/Razón Social";
                dataGridView1.Columns["NombreRazon"].Width = 200;
                dataGridView1.Columns["Direccion"].HeaderText = "Dirección";
                dataGridView1.Columns["Direccion"].Width = 180;
                dataGridView1.Columns["Correo"].HeaderText = "Correo";
                dataGridView1.Columns["Correo"].Width = 150;
                dataGridView1.Columns["Categoria"].HeaderText = "Categoría";
                dataGridView1.Columns["Categoria"].Width = 100;
            }
        }

        private void LimpiarCampos()
        {
            txtIdProveedor.Clear();
            txtNombreRazon.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
            cmbCategoria.SelectedIndex = 0;
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
                txtIdProveedor.Text = row["IdProveedor"].ToString();
                txtNombreRazon.Text = row["NombreRazon"].ToString();
                txtDireccion.Text = row["Direccion"].ToString();
                txtCorreo.Text = row["Correo"].ToString();
                
                // Seleccionar la categoría en el combo
                int index = cmbCategoria.FindStringExact(row["Categoria"].ToString());
                if (index >= 0)
                    cmbCategoria.SelectedIndex = index;

                modoEdicion = true;
                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombreRazon.Text))
            {
                MessageBox.Show("El campo Nombre/Razón Social es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreRazon.Focus();
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

            // Verificar que no exista otro proveedor con el mismo nombre (excepto el actual en modo edición)
            string nombreNuevo = txtNombreRazon.Text.Trim();
            var proveedorDuplicado = dtProveedores.AsEnumerable()
                .Where(r => r.Field<string>("NombreRazon").Equals(nombreNuevo, StringComparison.OrdinalIgnoreCase));

            if (modoEdicion && !string.IsNullOrEmpty(txtIdProveedor.Text))
            {
                int idActual = int.Parse(txtIdProveedor.Text);
                proveedorDuplicado = proveedorDuplicado.Where(r => r.Field<int>("IdProveedor") != idActual);
            }

            if (proveedorDuplicado.Any())
            {
                MessageBox.Show("Ya existe un proveedor con ese nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreRazon.Focus();
                return false;
            }

            if (cmbCategoria.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategoria.Focus();
                return false;
            }

            return true;
        }

        private int ObtenerNuevoId()
        {
            if (dtProveedores.Rows.Count == 0)
                return 1;
            
            return dtProveedores.AsEnumerable().Max(r => r.Field<int>("IdProveedor")) + 1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                DataRow nuevaFila = dtProveedores.NewRow();
                nuevaFila["IdProveedor"] = ObtenerNuevoId();
                nuevaFila["NombreRazon"] = txtNombreRazon.Text.Trim();
                nuevaFila["Direccion"] = txtDireccion.Text.Trim();
                nuevaFila["Correo"] = txtCorreo.Text.Trim();
                nuevaFila["Categoria"] = cmbCategoria.Text;

                dtProveedores.Rows.Add(nuevaFila);
                
                MessageBox.Show("Proveedor agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!modoEdicion || dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un proveedor para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarCampos())
                return;

            try
            {
                int id = int.Parse(txtIdProveedor.Text);
                DataRow fila = dtProveedores.AsEnumerable().FirstOrDefault(r => r.Field<int>("IdProveedor") == id);
                
                if (fila != null)
                {
                    fila["NombreRazon"] = txtNombreRazon.Text.Trim();
                    fila["Direccion"] = txtDireccion.Text.Trim();
                    fila["Correo"] = txtCorreo.Text.Trim();
                    fila["Categoria"] = cmbCategoria.Text;

                    MessageBox.Show("Proveedor modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!modoEdicion || dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un proveedor para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nombreProveedor = txtNombreRazon.Text;
            DialogResult resultado = MessageBox.Show($"¿Está seguro de que desea eliminar el proveedor '{nombreProveedor}'?\n\nNota: Esto podría afectar registros relacionados.", 
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtIdProveedor.Text);
                    DataRow fila = dtProveedores.AsEnumerable().FirstOrDefault(r => r.Field<int>("IdProveedor") == id);
                    
                    if (fila != null)
                    {
                        dtProveedores.Rows.Remove(fila);
                        MessageBox.Show("Proveedor eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar el proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string filtroCompleto = $"NombreRazon LIKE '%{filtro}%' OR " +
                                      $"Direccion LIKE '%{filtro}%' OR " +
                                      $"Correo LIKE '%{filtro}%' OR " +
                                      $"Categoria LIKE '%{filtro}%'";

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

        // Método público para obtener todos los proveedores (útil para otros formularios)
        public DataTable ObtenerProveedores()
        {
            return dtProveedores.Copy();
        }

        // Método público para obtener proveedores por categoría
        public DataTable ObtenerProveedoresPorCategoria(string categoria)
        {
            var proveedoresFiltrados = dtProveedores.AsEnumerable()
                .Where(r => r.Field<string>("Categoria").Equals(categoria, StringComparison.OrdinalIgnoreCase));

            if (proveedoresFiltrados.Any())
            {
                return proveedoresFiltrados.CopyToDataTable();
            }
            
            return dtProveedores.Clone(); // Retorna estructura vacía
        }

        // Método público para verificar si existe un proveedor
        public bool ExisteProveedor(string nombreRazon)
        {
            return dtProveedores.AsEnumerable()
                .Any(r => r.Field<string>("NombreRazon").Equals(nombreRazon, StringComparison.OrdinalIgnoreCase));
        }
    }
}
