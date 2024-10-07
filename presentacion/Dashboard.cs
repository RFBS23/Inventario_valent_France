using Entidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public partial class Dashboard : Form
    {
        private static Usuarios usuarioActual;
        public Dashboard(Entidad.Usuarios objusuario = null)
        {
            InitializeComponent();
            usuarioActual = objusuario;

            // Maximizar el formulario al iniciar
            this.WindowState = FormWindowState.Maximized;

            // Establecer redimensionamiento automático para el formulario
            this.AutoScaleMode = AutoScaleMode.Font;
        }

        private Form activeForm = null;
        private void formularioAbierto(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFormularios.Controls.Add(childForm);
            panelFormularios.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }

            panelFormularios.BringToFront();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmCategorias());
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblnombre.Text = "Bienvenido(a): " + usuarioActual.nombres + " " + usuarioActual.apellidos;
            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Now;
            lblfecha.Text = $"Fecha ingreso: {fechaActual.Day}/{fechaActual.Month}/{fechaActual.Year}";
            lblhora.Text = "Hora: " + DateTime.Now.ToString("hh:mm:ss tt");

            panelFormularios.Dock = DockStyle.Fill;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmUsuarios());
        }

        private void btnTallas_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmTallas());
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmProveedores());
        }

        private void btnventas_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmVentas(usuarioActual));
        }

        private void btnreportespdf_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmReportes());
        }

        private void btnconfiguracion_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmConfiguracion());
        }

        private void btninformacion_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frminformacion());
        }

        private void btnopreporte_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmReportes());
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnlistaproductos_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmAlmacenes());
        }

        private void btnagregarproducto_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmProductos());
        }

        private void btnDetVentas_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmDetalles());
        }

        private void btncompras_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmcompra(usuarioActual));
        }
    }
}
