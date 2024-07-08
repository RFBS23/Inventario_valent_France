using Entidad;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public partial class frmDetalleVentas : Form
    {
        public frmDetalleVentas()
        {
            InitializeComponent();
        }

        private void DetalleVentas_Load(object sender, EventArgs e)
        {
            txtbuscar.Select();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Ventas oVentas = new NVentas().ObtenerVentas(txtbuscar.Text);
            if (oVentas.idventa != 0)
            {
                txtnumerocomprobante.Text = oVentas.numerodocumento;
                txtfecha.Text = oVentas.fecharegistro;
                txtcomprobante.Text = oVentas.tipodocumento;
                txtusuario.Text = oVentas.oUsuarios.nombreusuario;

                txtdocumento.Text = oVentas.documentocliente;
                txtnombrecliente.Text = oVentas.nombrecliente;
                tabladetallesventas.Rows.Clear();
                foreach (DetallesVentas dv in oVentas.oDetalle_Venta)
                {
                    tabladetallesventas.Rows.Add(new object[] { dv.oProductos.nombre + " " + dv.oProductos.descripcion + " " + dv.oProductos.colores + " " + dv.oProductos.oTallasropa, dv.cantidad, dv.precioventa, dv.oProductos.descuento, dv.subtotal });
                }
                txtmontototal.Text = oVentas.montototal.ToString("0.00");
                txtpagocon.Text = oVentas.montopago.ToString("0.00");
                txtvuelto.Text = oVentas.montocambio.ToString("0.00");
            }
        }

        private void btnfactura_Click(object sender, EventArgs e)
        {
            if (txtcomprobante.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string Factura_Html = Properties.Resources.Facturas.ToString();
            Negocios odatos = new NNegocio().ObtenerDatos();

            Factura_Html = Factura_Html.Replace("@rucnegocio", odatos.ruc);
            Factura_Html = Factura_Html.Replace("@nombrenegocio", odatos.nombre.ToUpper());
            Factura_Html = Factura_Html.Replace("@direcnegocio", odatos.direccion);

            Factura_Html = Factura_Html.Replace("@tipodocumento", txtcomprobante.Text.ToUpper());
            Factura_Html = Factura_Html.Replace("@numerodocumento", txtnumerocomprobante.Text.ToUpper());
            Factura_Html = Factura_Html.Replace("@fecharegistro", txtfecha.Text);
            Factura_Html = Factura_Html.Replace("@usuarioregistro", txtusuario.Text.ToUpper());
            Factura_Html = Factura_Html.Replace("@nombrecliente", txtnombrecliente.Text.ToUpper());
            Factura_Html = Factura_Html.Replace("@doccliente", txtdocumento.Text.ToUpper());

            string filas = string.Empty;
            foreach (DataGridViewRow row in tabladetallesventas.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["nombre"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["precioventa"].Value.ToString() + "</td>";                
                filas += "<td>" + row.Cells["stock"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["descuento"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["subtotal"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Factura_Html = Factura_Html.Replace("@filas", filas);
            Factura_Html = Factura_Html.Replace("@montototal", txtmontototal.Text);
            Factura_Html = Factura_Html.Replace("@pagocon", txtpagocon.Text);
            Factura_Html = Factura_Html.Replace("@cambio", txtvuelto.Text);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Venta_{0}_Facturas.pdf", txtnumerocomprobante.Text);
            savefile.Filter = "Pdf Files|*.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    bool obtenido = true;
                    byte[] byteImage = new NNegocio().ObtenerLogo(out obtenido);

                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(60, 60);
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(51));
                        pdfDoc.Add(img);
                    }

                    using (StringReader sr = new StringReader(Factura_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }

                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(savefile.FileName);
                }
            }
        }

        private void btnboleto_Click(object sender, EventArgs e)
        {
            if (txtcomprobante.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string Ticket_Html = Properties.Resources.boleto.ToString();
            Negocios odatos = new NNegocio().ObtenerDatos();

            Ticket_Html = Ticket_Html.Replace("@rucnegocio", odatos.ruc);
            Ticket_Html = Ticket_Html.Replace("@nombrenegocio", odatos.nombre.ToUpper());
            Ticket_Html = Ticket_Html.Replace("@direcnegocio", odatos.direccion);
            Ticket_Html = Ticket_Html.Replace("@tipodocumento", txtcomprobante.Text.ToUpper());
            Ticket_Html = Ticket_Html.Replace("@numerodocumento", txtnumerocomprobante.Text.ToUpper());
            Ticket_Html = Ticket_Html.Replace("@fecharegistro", txtfecha.Text);
            Ticket_Html = Ticket_Html.Replace("@usuarioregistro", txtusuario.Text.ToUpper());
            Ticket_Html = Ticket_Html.Replace("@nombrecliente", txtnombrecliente.Text.ToUpper());
            Ticket_Html = Ticket_Html.Replace("@doccliente", txtdocumento.Text.ToUpper());


            string filas = string.Empty;
            foreach (DataGridViewRow row in tabladetallesventas.Rows)
            {
                filas += "<tr>";
                filas += "<th>" + row.Cells["nombre"].Value.ToString() + "</th>";
                filas += "<th>" + row.Cells["descuento"].Value.ToString() + "</th>";
                filas += "<th>" + row.Cells["precioventa"].Value.ToString() + "</th>";
                filas += "<th>" + row.Cells["stock"].Value.ToString() + "</th>";
                filas += "<th>" + row.Cells["subtotal"].Value.ToString() + "</th>";
                filas += "</tr>";
            }
            Ticket_Html = Ticket_Html.Replace("@filas", filas);
            Ticket_Html = Ticket_Html.Replace("@montototal", txtmontototal.Text);
            Ticket_Html = Ticket_Html.Replace("@pagocon", txtpagocon.Text);
            Ticket_Html = Ticket_Html.Replace("@cambio", txtvuelto.Text);

            string enlace = "https://rfbs23.github.io/portafolio";

            string urlServicioQR = $"https://api.qrserver.com/v1/create-qr-code/?data={enlace}&size=60x60";

            Ticket_Html = Ticket_Html.Replace("@urlCodigoQR", urlServicioQR);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Venta_{0}_Boleto.pdf", txtcomprobante.Text);
            savefile.Filter = "Pdf Files|*.pdf";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefile.FileName, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.A7, 5, 5, 5, 5);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                    bool obtenido = true;
                    byte[] byteImage = new NNegocio().ObtenerLogo(out obtenido);
                    if (obtenido)
                    {
                        iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(byteImage);
                        img.ScaleToFit(30, 30); // Ajusta el tamaño del logo en el PDF
                        img.Alignment = iTextSharp.text.Image.UNDERLYING;
                        img.SetAbsolutePosition(pdfDoc.Left, pdfDoc.GetTop(41));
                        pdfDoc.Add(img);
                    }
                    using (StringReader sr = new StringReader(Ticket_Html))
                    {
                        XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                    }
                    pdfDoc.Close();
                    stream.Close();
                    MessageBox.Show("Documento Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(savefile.FileName);
                }
            }
        }
    }
}
