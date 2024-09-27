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
    public partial class frmAlmacenes : Form
    {
        public frmAlmacenes()
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

        private void btntienda_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmproductos_tienda());
        }

        private void btnralmacen_Click(object sender, EventArgs e)
        {
            formularioAbierto(new Form_listaproductos());
        }
    }
}
