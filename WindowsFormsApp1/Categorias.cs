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
    public partial class Categorias : Form
    {
        // DataTable para simular la tabla de la base de datos
        private DataTable dtCategorias;
        private bool modoEdicion = false;

        public Categorias()
        {
            InitializeComponent();
            InicializarDataTable();
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            // Configurar el formulario al cargar
            dtpFechaCreacion.Value = DateTime.Now;
            CargarDatos();
            LimpiarCampos();
        }

        private void InicializarDataTable()
        {
            // Crear la estructura de datos que simula la tabla Categorias
            dtCategorias = new DataTable();
            dtCategorias.Columns.Add("IdCategoria", typeof(int));
            dtCategorias.Columns.Add("Nombre", typeof(string));
            dtCategorias.Columns.Add("FechaCreacion", typeof(DateTime));
            dtCategorias.Columns.Add("TieneFecha", typeof(bool)); // Para controlar si tiene fecha o es NULL
            // Sin datos de ejemplo
        }

        private void CargarDatos()
        {
            // Cargar los datos en el DataGridView
            dataGridView1.DataSource = dtCategorias;
            
            // Configurar las columnas del DataGridView
            if (dataGridView1.Columns.Count > 0)
            {
                dataGridView1.Columns["IdCategoria"].HeaderText = "ID";
                dataGridView1.Columns["IdCategoria"].Width = 50;
                dataGridView1.Columns["Nombre"].HeaderText = "Nombre de Categoría";
                dataGridView1.Columns["Nombre"].Width = 200;
                dataGridView1.Columns["FechaCreacion"].HeaderText = "Fecha Creación";
                dataGridView1.Columns["FechaCreacion"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dataGridView1.Columns["FechaCreacion"].Width = 120;
                dataGridView1.Columns["TieneFecha"].Visible = false; // Ocultar columna de control
            }
        }

        private void LimpiarCampos()
        {
            txtIdCategoria.Clear();
            txtNombre.Clear();
            chkFechaCreacion.Checked = false;
            dtpFechaCreacion.Value = DateTime.Now;
            dtpFechaCreacion.Enabled = false;
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
                txtIdCategoria.Text = row["IdCategoria"].ToString();
                txtNombre.Text = row["Nombre"].ToString();
                
                bool tieneFecha = Convert.ToBoolean(row["TieneFecha"]);
                chkFechaCreacion.Checked = tieneFecha;
                dtpFechaCreacion.Enabled = tieneFecha;
                
                if (tieneFecha && row["FechaCreacion"] != DBNull.Value)
                {
                    dtpFechaCreacion.Value = Convert.ToDateTime(row["FechaCreacion"]);
                }

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
                MessageBox.Show("El campo Nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            // Verificar que no exista otra categoría con el mismo nombre (excepto la actual en modo edición)
            string nombreNuevo = txtNombre.Text.Trim();
            var categoriaDuplicada = dtCategorias.AsEnumerable()
                .Where(r => r.Field<string>("Nombre").Equals(nombreNuevo, StringComparison.OrdinalIgnoreCase));

            if (modoEdicion && !string.IsNullOrEmpty(txtIdCategoria.Text))
            {
                int idActual = int.Parse(txtIdCategoria.Text);
                categoriaDuplicada = categoriaDuplicada.Where(r => r.Field<int>("IdCategoria") != idActual);
            }

            if (categoriaDuplicada.Any())
            {
                MessageBox.Show("Ya existe una categoría con ese nombre.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }

            return true;
        }

        private int ObtenerNuevoId()
        {
            if (dtCategorias.Rows.Count == 0)
                return 1;
            
            return dtCategorias.AsEnumerable().Max(r => r.Field<int>("IdCategoria")) + 1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                DataRow nuevaFila = dtCategorias.NewRow();
                nuevaFila["IdCategoria"] = ObtenerNuevoId();
                nuevaFila["Nombre"] = txtNombre.Text.Trim();
                
                if (chkFechaCreacion.Checked)
                {
                    nuevaFila["FechaCreacion"] = dtpFechaCreacion.Value.Date;
                    nuevaFila["TieneFecha"] = true;
                }
                else
                {
                    nuevaFila["FechaCreacion"] = DBNull.Value;
                    nuevaFila["TieneFecha"] = false;
                }

                dtCategorias.Rows.Add(nuevaFila);
                
                MessageBox.Show("Categoría agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!modoEdicion || dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una categoría para modificar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!ValidarCampos())
                return;

            try
            {
                int id = int.Parse(txtIdCategoria.Text);
                DataRow fila = dtCategorias.AsEnumerable().FirstOrDefault(r => r.Field<int>("IdCategoria") == id);
                
                if (fila != null)
                {
                    fila["Nombre"] = txtNombre.Text.Trim();
                    
                    if (chkFechaCreacion.Checked)
                    {
                        fila["FechaCreacion"] = dtpFechaCreacion.Value.Date;
                        fila["TieneFecha"] = true;
                    }
                    else
                    {
                        fila["FechaCreacion"] = DBNull.Value;
                        fila["TieneFecha"] = false;
                    }

                    MessageBox.Show("Categoría modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!modoEdicion || dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una categoría para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nombreCategoria = txtNombre.Text;
            DialogResult resultado = MessageBox.Show($"¿Está seguro de que desea eliminar la categoría '{nombreCategoria}'?\n\nNota: Esto podría afectar los gastos que usan esta categoría.", 
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtIdCategoria.Text);
                    DataRow fila = dtCategorias.AsEnumerable().FirstOrDefault(r => r.Field<int>("IdCategoria") == id);
                    
                    if (fila != null)
                    {
                        dtCategorias.Rows.Remove(fila);
                        MessageBox.Show("Categoría eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string filtroCompleto = $"Nombre LIKE '%{filtro}%'";
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

        private void chkFechaCreacion_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaCreacion.Enabled = chkFechaCreacion.Checked;
            if (chkFechaCreacion.Checked && !modoEdicion)
            {
                dtpFechaCreacion.Value = DateTime.Now;
            }
        }

        // Método público para obtener todas las categorías (útil para otros formularios)
        public DataTable ObtenerCategorias()
        {
            return dtCategorias.Copy();
        }

        // Método público para agregar una nueva categoría desde otros formularios
        public bool AgregarCategoriaProgramaticamente(string nombre, DateTime? fechaCreacion = null)
        {
            try
            {
                // Verificar que no exista
                var existe = dtCategorias.AsEnumerable()
                    .Any(r => r.Field<string>("Nombre").Equals(nombre, StringComparison.OrdinalIgnoreCase));

                if (existe)
                    return false;

                DataRow nuevaFila = dtCategorias.NewRow();
                nuevaFila["IdCategoria"] = ObtenerNuevoId();
                nuevaFila["Nombre"] = nombre;
                
                if (fechaCreacion.HasValue)
                {
                    nuevaFila["FechaCreacion"] = fechaCreacion.Value;
                    nuevaFila["TieneFecha"] = true;
                }
                else
                {
                    nuevaFila["FechaCreacion"] = DBNull.Value;
                    nuevaFila["TieneFecha"] = false;
                }

                dtCategorias.Rows.Add(nuevaFila);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
