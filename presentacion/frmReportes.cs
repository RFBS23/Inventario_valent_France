using ClosedXML.Excel;
using Entidad;
using Negocio;
using presentacion.Utilidades;
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
    public partial class frmReportes : Form
    {
        public frmReportes()
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

        private void frmReportes_Load(object sender, EventArgs e)
        {

        }

        private void btnrepcompras_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmreportescompras());
        }

        private void btnrepventas_Click(object sender, EventArgs e)
        {
            formularioAbierto(new frmreportesventas());
        }
    }
}
