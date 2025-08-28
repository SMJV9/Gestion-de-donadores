using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        private bool mostrarContrasena = false;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Enfocar el campo de usuario
            txtUsuario.Focus();
        }

        // URL base de tu Firebase (Realtime Database)
        private const string firebaseUrl = "https://base-de-datos-sistemadegestion-default-rtdb.firebaseio.com/usuarios.json";

        // Clase auxiliar para deserializar usuarios
        public class UsuarioFirebase
        {
            public string usuario { get; set; }
            public string contrasena { get; set; }
            public int nivel { get; set; } // Asegura que el nivel se lea como int
        }

        // Validar credenciales contra Firebase y obtener nivel
        private async Task<UsuarioFirebase> ObtenerUsuarioFirebaseAsync(string usuario, string contrasena)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(firebaseUrl);
                string result = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(result) || result == "null")
                    return null;
                var usuariosDict = JsonConvert.DeserializeObject<Dictionary<string, UsuarioFirebase>>(result);
                if (usuariosDict == null)
                    return null;
                foreach (var item in usuariosDict.Values)
                {
                    if (item.usuario == usuario && item.contrasena == contrasena)
                        return item;
                }
                return null;
            }
        }

        private async void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Por favor ingrese su usuario.", "Campo requerido", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Por favor ingrese su contraseña.", "Campo requerido", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Focus();
                return;
            }
            // Validar contra Firebase y obtener usuario
            var usuarioFirebase = await ObtenerUsuarioFirebaseAsync(txtUsuario.Text, txtContrasena.Text);
            if (usuarioFirebase != null)
            {
                Form1.cuenta = usuarioFirebase.usuario;
                Form1.nivel = usuarioFirebase.nivel;
                MessageBox.Show("¡Bienvenido al sistema!", "Acceso concedido", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", 
                    "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Clear();
                txtUsuario.Focus();
                txtUsuario.SelectAll();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Está seguro de que desea salir de la aplicación?", 
                "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (resultado == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                Application.Exit();
            }
        }

        private void btnMostrarContrasena_Click(object sender, EventArgs e)
        {
            mostrarContrasena = !mostrarContrasena;
            
            if (mostrarContrasena)
            {
                txtContrasena.PasswordChar = '\0';
                btnMostrarContrasena.Text = "🙈";
            }
            else
            {
                txtContrasena.PasswordChar = '*';
                btnMostrarContrasena.Text = "👁";
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtContrasena.Focus();
                e.Handled = true;
            }
        }

        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnIniciarSesion_Click(sender, e);
                e.Handled = true;
            }
        }

        // Override para manejar teclas especiales
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                btnCancelar_Click(null, null);
                return true;
            }
            
            return base.ProcessDialogKey(keyData);
        }

        // Método para guardar un usuario de prueba en Firebase
        private async Task GuardarEnFirebaseAsync(object datos)
        {
            var json = JsonConvert.SerializeObject(datos);
            using (var client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(firebaseUrl, content);
                string result = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Respuesta de Firebase: {result}");
            }
        }

        // Método para leer usuarios desde Firebase
        private async Task LeerDeFirebaseAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(firebaseUrl);
                string result = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"Datos en Firebase: {result}");
            }
        }

        // Evento para el botón de prueba de conexión
        private async void btnProbarFirebase_Click(object sender, EventArgs e)
        {
            // Guardar usuario de prueba
            var usuario = new { usuario = "prueba", fecha = System.DateTime.Now };
            await GuardarEnFirebaseAsync(usuario);
            // Leer usuarios
            await LeerDeFirebaseAsync();
        }
    }
}
