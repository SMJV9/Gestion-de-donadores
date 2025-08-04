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

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (ValidarCredenciales())
            {
                // Simular autenticación exitosa
                Form1.cuenta = txtUsuario.Text;
                Form1.nivel = 1; // Nivel de acceso
                
                MessageBox.Show("¡Bienvenido al sistema!", "Acceso concedido", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.\n\nCredenciales válidas:\nUsuario: admin\nContraseña: admin", 
                    "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                // Limpiar contraseña y enfocar usuario
                txtContrasena.Clear();
                txtUsuario.Focus();
                txtUsuario.SelectAll();
            }
        }

        private bool ValidarCredenciales()
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Por favor ingrese su usuario.", "Campo requerido", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Por favor ingrese su contraseña.", "Campo requerido", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Focus();
                return false;
            }

            // Validación simple (en un sistema real sería con base de datos)
            return txtUsuario.Text.ToLower() == "admin" && txtContrasena.Text == "admin";
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
    }
}
