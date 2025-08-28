using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class CrearUsuario : Form
    {
        private const string firebaseUrl = "https://base-de-datos-sistemadegestion-default-rtdb.firebaseio.com/usuarios.json";

        public CrearUsuario()
        {
            InitializeComponent();
            cmbNivel.Items.Clear();
            cmbNivel.Items.Add(new NivelItem { Text = "Administrador", Value = 2 });
            cmbNivel.Items.Add(new NivelItem { Text = "Usuario", Value = 1 });
            cmbNivel.DisplayMember = "Text";
            cmbNivel.SelectedIndex = 1; // Por defecto Usuario
        }

        private class NivelItem
        {
            public string Text { get; set; }
            public int Value { get; set; }
            public override string ToString() => Text;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text) || cmbNivel.SelectedItem == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int nivel = ((NivelItem)cmbNivel.SelectedItem).Value;
            var usuario = new {
                usuario = txtUsuario.Text.Trim(),
                contrasena = txtContrasena.Text.Trim(),
                nivel = nivel
            };
            var json = JsonConvert.SerializeObject(usuario);
            using (var client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(firebaseUrl, content);
                string result = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Usuario creado correctamente en Firebase.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
