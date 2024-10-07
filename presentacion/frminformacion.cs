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
    public partial class frminformacion : Form
    {
        public frminformacion()
        {
            InitializeComponent();
        }

        private void frminformacion_Load(object sender, EventArgs e)
        {
            Label lblFooter = new Label();
            lblFooter.Text = "© 2024 FabriDev. Todos los derechos reservados.";
            lblFooter.Dock = DockStyle.Bottom; // Para que el label esté al final del formulario
            lblFooter.TextAlign = ContentAlignment.MiddleCenter; // Centra el texto
            lblFooter.AutoSize = false;
            lblFooter.Height = 30; // Tamaño del footer
            lblFooter.BackColor = Color.LightGray; // Color de fondo opcional
            this.Controls.Add(lblFooter);

            /*Links de portafolio y sitio web*/

            // portafolio
            LinkLabel linkPortfolio = new LinkLabel();
            linkPortfolio.Text = "Visita mi portafolio";
            linkPortfolio.AutoSize = true;
            linkPortfolio.Location = new Point(10, 10); // Ajusta la ubicación dentro del formulario
            linkPortfolio.LinkClicked += new LinkLabelLinkClickedEventHandler(linkPortfolio_LinkClicked);

            // sitio web
            LinkLabel linkWebsite = new LinkLabel();
            linkWebsite.Text = "Visita mi sitio web";
            linkWebsite.AutoSize = true;
            linkWebsite.Location = new Point(10, 40); // Ajusta la ubicación dentro del formulario
            linkWebsite.LinkClicked += new LinkLabelLinkClickedEventHandler(linkWebsite_LinkClicked);

            // Agregar los enlaces al formulario
            this.Controls.Add(linkPortfolio);
            this.Controls.Add(linkWebsite);
        }

        private void linkPortfolio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://portafolio-fabridev.vercel.app/",
                UseShellExecute = true
            });
        }

        private void linkWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://portafolio-fabridev.vercel.app/",
                UseShellExecute = true
            });
        }
    }
}
