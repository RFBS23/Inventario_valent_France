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
    public partial class frmDetalles : Form
    {
        public frmDetalles()
        {
            InitializeComponent();
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

        private void btndetcompras_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmDetalleCompras());
        }

        private void btndetventas_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmDetalleVentas());
        }
    }
}
