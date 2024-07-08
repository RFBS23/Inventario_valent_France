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
    public partial class DashboardAlmacen : Form
    {
        private static Entidad.Usuarios usuarioActual;
        public DashboardAlmacen(Entidad.Usuarios objusuario = null)
        {
            InitializeComponent();
            usuarioActual = objusuario;
        }

        private void DashboardAlmacen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form login = new Login();
            login.Show();
            this.Hide();
        }

        private void DashboardAlmacen_Load(object sender, EventArgs e)
        {

        }
    }
}
