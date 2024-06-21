using Entidad;
using Negocio;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtusuario.Select();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btningresar_Click(object sender, EventArgs e)
        {
            Entidad.Usuarios usuariologin = new NUsuarios().IniciarSesion().Where(u => u.nombreusuario == txtusuario.Text && u.clave == txtpassword.Text).FirstOrDefault();
            if (usuariologin != null)
            {
                if (usuariologin.oNivelAcceso != null)
                {
                    switch (usuariologin.oNivelAcceso.nombreacceso.ToLower())
                    {
                        case "administrador":
                            // Usuario con nivel de acceso 'admin', muestra el Dashboard para admin
                            Dashboard dashboardAdmin = new Dashboard(usuariologin);
                            dashboardAdmin.Show();
                            break;

                        case "almacen":
                            // Usuario con nivel de acceso 'almacen', muestra el Dashboard para almacen
                            DashboardAlmacen almacen = new DashboardAlmacen(usuariologin);
                            almacen.Show();
                            break;

                        case "vendedor":
                            // Usuario con nivel de acceso 'vendedor', muestra el Dashboard para vendedor
                            DashboardVendedor vendedor = new DashboardVendedor(usuariologin);
                            vendedor.Show();
                            break;

                        default:
                            // Otros casos o niveles de acceso no manejados
                            MessageBox.Show("Nivel de acceso no manejado.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                    }
                }
                else
                {
                    // Manejo para situaciones donde el nivel de acceso es nulo
                    MessageBox.Show("Error en los datos de acceso.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Cerrar el formulario actual
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error al Iniciar Sesión", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Entidad.Usuarios usuariologin = new NUsuarios().IniciarSesion().Where(u => u.nombreusuario == txtusuario.Text && u.clave == txtpassword.Text).FirstOrDefault();
                if (usuariologin != null)
                {
                    if (usuariologin.oNivelAcceso != null)
                    {
                        switch (usuariologin.oNivelAcceso.nombreacceso.ToLower())
                        {
                            case "administrador":
                                // Usuario con nivel de acceso 'admin', muestra el Dashboard para admin
                                Dashboard dashboardAdmin = new Dashboard(usuariologin);
                                dashboardAdmin.Show();
                                break;

                            case "almacen":
                                // Usuario con nivel de acceso 'almacen', muestra el Dashboard para almacen
                                DashboardAlmacen almacen = new DashboardAlmacen(usuariologin);
                                almacen.Show();
                                break;

                            case "vendedor":
                                // Usuario con nivel de acceso 'vendedor', muestra el Dashboard para vendedor
                                DashboardVendedor vendedor = new DashboardVendedor(usuariologin);
                                vendedor.Show();
                                break;

                            default:
                                // Otros casos o niveles de acceso no manejados
                                MessageBox.Show("Nivel de acceso no esta activado comuniquese con el programador.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error en los datos de acceso.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error al Iniciar Sesión", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
