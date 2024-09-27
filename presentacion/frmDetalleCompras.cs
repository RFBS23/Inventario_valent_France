using Entidad;
using iTextSharp.text;
using iTextSharp.text.pdf;
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
    public partial class frmDetalleCompras : Form
    {
        public frmDetalleCompras()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Compra oCompras = new Ncompras().ObtenerCompra(txtbuscar.Text);
            if (oCompras.idcompra != 0)
            {
                txtnumerocomprobante.Text = oCompras.numerodocumento;
                txtfecha.Text = oCompras.fecharegistro;
                txtcomprobante.Text = oCompras.tipodocumento;
                txtusuario.Text = oCompras.oUsuarios.nombreusuario;

                txtdocumento.Text = oCompras.oProveedor.documento;
                txtnombreproveedor.Text = oCompras.oProveedor.nombreproveedor;
                tabladetallescompras.Rows.Clear();
                foreach (Detalle_compra dv in oCompras.oDetallescompra)
                {
                    tabladetallescompras.Rows.Add(new object[] { dv.oProductos.nombre + " " + dv.oProductos.descripcion + " " + dv.oProductos.colores + " " + dv.oProductos.oTallasropa, dv.preciocompra, dv.cantidad, dv.montototal});
                }
                txtmontototal.Text = oCompras.montototal.ToString("0.00");
            }
        }

        private void frmDetalleCompras_Load(object sender, EventArgs e)
        {
            txtbuscar.Select();
        }

        private void btnfactura_Click(object sender, EventArgs e)
        {
            if (txtcomprobante.Text == "")
            {
                MessageBox.Show("No se encontraron resultados", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string Factura_Html = Properties.Resources.Facturascompras.ToString();
            Negocios odatos = new NNegocio().ObtenerDatos();

            Factura_Html = Factura_Html.Replace("@rucnegocio", odatos.ruc);
            Factura_Html = Factura_Html.Replace("@nombrenegocio", odatos.nombre.ToUpper());
            Factura_Html = Factura_Html.Replace("@direcnegocio", odatos.direccion);

            Factura_Html = Factura_Html.Replace("@tipodocumento", txtcomprobante.Text.ToUpper());
            Factura_Html = Factura_Html.Replace("@numerodocumento", txtnumerocomprobante.Text.ToUpper());
            Factura_Html = Factura_Html.Replace("@fecharegistro", txtfecha.Text);
            Factura_Html = Factura_Html.Replace("@usuarioregistro", txtusuario.Text.ToUpper());
            Factura_Html = Factura_Html.Replace("@nombrecliente", txtnombreproveedor.Text.ToUpper());
            Factura_Html = Factura_Html.Replace("@doccliente", txtdocumento.Text.ToUpper());

            string filas = string.Empty;
            foreach (DataGridViewRow row in tabladetallescompras.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + row.Cells["nombre"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["preciocompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["stock"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["total"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Factura_Html = Factura_Html.Replace("@filas", filas);
            Factura_Html = Factura_Html.Replace("@montototal", txtmontototal.Text);

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

            string Ticket_Html = Properties.Resources.boletocompra.ToString();
            Negocios odatos = new NNegocio().ObtenerDatos();

            Ticket_Html = Ticket_Html.Replace("@rucnegocio", odatos.ruc);
            Ticket_Html = Ticket_Html.Replace("@nombrenegocio", odatos.nombre.ToUpper());
            Ticket_Html = Ticket_Html.Replace("@direcnegocio", odatos.direccion);
            Ticket_Html = Ticket_Html.Replace("@tipodocumento", txtcomprobante.Text.ToUpper());
            Ticket_Html = Ticket_Html.Replace("@numerodocumento", txtnumerocomprobante.Text.ToUpper());
            Ticket_Html = Ticket_Html.Replace("@fecharegistro", txtfecha.Text);
            Ticket_Html = Ticket_Html.Replace("@usuarioregistro", txtusuario.Text.ToUpper());
            Ticket_Html = Ticket_Html.Replace("@nombrecliente", txtnombreproveedor.Text.ToUpper());
            Ticket_Html = Ticket_Html.Replace("@doccliente", txtdocumento.Text.ToUpper());

            string filas = string.Empty;
            foreach (DataGridViewRow row in tabladetallescompras.Rows)
            {
                filas += "<tr>";
                filas += "<th>" + row.Cells["nombre"].Value.ToString() + "</th>";
                filas += "<td>" + row.Cells["preciocompra"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["stock"].Value.ToString() + "</td>";
                filas += "<td>" + row.Cells["total"].Value.ToString() + "</td>";
                filas += "</tr>";
            }
            Ticket_Html = Ticket_Html.Replace("@filas", filas);
            Ticket_Html = Ticket_Html.Replace("@montototal", txtmontototal.Text);

            string enlace = "https://rfbs23.github.io/portafolio";

            string urlServicioQR = $"https://api.qrserver.com/v1/create-qr-code/?data={enlace}&size=60x60";

            Ticket_Html = Ticket_Html.Replace("@urlCodigoQR", urlServicioQR);

            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = string.Format("Venta_{0}_Boleto.pdf", txtnumerocomprobante.Text);
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

        private void txtbuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            Compra oCompras = new Ncompras().ObtenerCompra(txtbuscar.Text);
            if (oCompras.idcompra != 0)
            {
                txtnumerocomprobante.Text = oCompras.numerodocumento;
                txtfecha.Text = oCompras.fecharegistro;
                txtcomprobante.Text = oCompras.tipodocumento;
                txtusuario.Text = oCompras.oUsuarios.nombreusuario;

                txtdocumento.Text = oCompras.oProveedor.documento;
                txtnombreproveedor.Text = oCompras.oProveedor.nombreproveedor;
                tabladetallescompras.Rows.Clear();
                foreach (Detalle_compra dv in oCompras.oDetallescompra)
                {
                    tabladetallescompras.Rows.Add(new object[] { dv.oProductos.nombre + " " + dv.oProductos.descripcion + " " + dv.oProductos.colores + " " + dv.oProductos.oTallasropa, dv.preciocompra, dv.cantidad, dv.montototal });
                }
                txtmontototal.Text = oCompras.montototal.ToString("0.00");
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {

        }
    }
}
