using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static string cuenta = "";
        public static int nivel = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Login Login = new Login();
            Login.ShowDialog();
            label1.Text = "Usuario: " + cuenta;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void altasClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir la forma de Altas de Clientes
            AltasClientes formAltasClientes = new AltasClientes();
            formAltasClientes.ShowDialog();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir la forma de Donaciones (Ingresos)
            Donaciones formDonaciones = new Donaciones();
            formDonaciones.ShowDialog();
        }

        private void altasProvedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir la forma de Gastos (Egresos)
            Gastos formGastos = new Gastos();
            formGastos.ShowDialog();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir la forma de Categorías
            Categorias formCategorias = new Categorias();
            formCategorias.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir la forma de Proveedores
            Proveedores formProveedores = new Proveedores();
            formProveedores.ShowDialog();
        }

        private void reporteGastosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Abrir la forma de Reporte de Gastos
            ReporteGastos formReporteGastos = new ReporteGastos();
            formReporteGastos.ShowDialog();
        }
    }
}
