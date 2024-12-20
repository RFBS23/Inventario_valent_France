﻿using Entidad;
using Negocio;
using presentacion.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public partial class frmVentas : Form
    {
        private Usuarios _usuarios;
        public frmVentas(Usuarios oUsuarios = null)
        {
            _usuarios = oUsuarios;

            InitializeComponent();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            lblfecha.Text = $"{fechaActual.Day}/{fechaActual.Month}/{fechaActual.Year}";

            cbbolfac.Items.Add(new OpcionesComboBox() { Valor = "Boleta", Texto = "Boleta" });
            cbbolfac.Items.Add(new OpcionesComboBox() { Valor = "Factura", Texto = "Factura" });
            cbbolfac.DisplayMember = "Texto";
            cbbolfac.ValueMember = "Valor";
            cbbolfac.SelectedIndex = 0;
            txtstock.Text = "0";
            txtprecio.Text = "0.00";
            txtidproducto.Text = "0";
            txtpagocon.Text = "0.00";
            txtcambio.Text = "0.00";
            txttotalpagar.Text = "0.00";
            txtdescuento.Text = "0.00";

            this.promo2x1.CheckedChanged += new System.EventHandler(this.promo2x1_CheckedChanged);
            btnAgregar.Visible = true;
            btn2x1.Visible = false;

            btnpromo.Visible = false;
            txtcodigopromo.Visible = false;
            txtnombrepromo.Visible = false;
            txttallaspromo.Visible = false;
            txtcolopromo.Visible = false;
            txtpreciopromo.Visible = false;
            txtdescuentopromo.Visible = false;
            txtcantpromo.Visible = false;
            txtstockpromo.Visible = false;

        }

        private async void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            if (txtddocumento.Text.Length == 8)
            {
                string apiUrl = $"https://api.apis.net.pe/v1/dni?numero={txtddocumento.Text}";
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.GetAsync(apiUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonResponse);

                            if (json != null)
                            {
                                txtcliente.Text = $"{json.nombres} {json.apellidoPaterno} {json.apellidoMaterno}";
                                string dniCliente = txtddocumento.Text;
                                var usuarioRegistrado = new NUsuarios().Listar().FirstOrDefault(u => u.documento == dniCliente);

                                if (usuarioRegistrado != null)
                                {
                                    txtdescuento.Text = "10";
                                }
                                else
                                {
                                    txtdescuento.Text = "0";
                                }
                            }
                            else
                            {
                                MessageBox.Show("La respuesta de la API no tiene el formato esperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"No se ha podido encontrar el dni buscado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener la información del DNI: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AplicarDescuento()
        {
            decimal descuento = 0.10m;
            string porcentajeDescuento = "10%";
            txtdescuento.Text = porcentajeDescuento;
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Productos_tienda oProductos = new NTienda().Listar().Where(p => p.codigo.ToUpper() == txtcodigo.Text.ToUpper()).FirstOrDefault();
            if (oProductos != null)
            {
                txtidproducto.Text = oProductos.idproductotienda.ToString();
                txtnombres.Text = oProductos.nombre;
                txtstock.Text = oProductos.stock.ToString();
                txtprecio.Text = oProductos.preciocompra.ToString();
                txttalla.Text = oProductos.oTallasropa.nombretalla.ToString();
                txtcolores.Text = oProductos.colores.ToString();
                txtdescuento.Text = oProductos.descuento.ToString();
                txtcantidadprod.Select();
            }
            else
            {
                txtidproducto.Text = "0";
                txtnombres.Text = "";
                txtstock.Text = "0";
                txtprecio.Text = "";
                txttalla.Text = "";
                txtcolores.Text = "";
                txtdescuento.PlaceholderText = "0";
                txtcantidadprod.Value = 1;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal cantidad;

            if (!decimal.TryParse(txtcantidadprod.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcantidadprod.Select();
                return;
            }

            int stock = Convert.ToInt32(txtstock.Text);
            if (cantidad > stock)
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock disponible", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bool productoExiste = false;
            foreach (DataGridViewRow fila in tablaventas.Rows)
            {
                if (fila.Cells["idproducto"].Value.ToString() == txtidproducto.Text)
                {
                    productoExiste = true;
                    break;
                }
            }

            if (!productoExiste)
            {
                bool respuesta = new NVentas().RestarStock(
                    Convert.ToInt32(txtidproducto.Text),
                    Convert.ToInt32(cantidad));

                if (respuesta)
                {
                    decimal precioProducto = Convert.ToDecimal(txtprecio.Text);
                    decimal descuento = Convert.ToDecimal(txtdescuento.Text);
                    decimal precioConDescuento = precioProducto - (precioProducto * (descuento / 100));

                    decimal precioRedondeado = RedondearPrecio(precioConDescuento);
                    decimal subtotal = precioRedondeado * cantidad;

                    tablaventas.Rows.Add(new object[]
                    {
                        txtidproducto.Text,
                        txtddocumento.Text,
                        txtcliente.Text,
                        txtnombres.Text,
                        txttalla.Text,
                        txtcolores.Text,
                        txtprecio.Text,
                        txtdescuento.Text,
                        cantidad.ToString(),
                        subtotal.ToString("0.00")
                    });
                    calcularTotal();
                    limpiarProducto();
                    RecalcularTotal();
                    txtcodigo.Select();
                }
                else
                {
                    MessageBox.Show("Error al restar el stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El producto ya existe en la tabla.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private decimal RedondearPrecio(decimal precio)
        {
            decimal parteDecimal = precio - Math.Floor(precio);

            if (parteDecimal >= 0.50m)
            {
                return Math.Ceiling(precio);
            }
            else
            {
                return Math.Floor(precio);
            }
        }

        private void calcularTotal()
        {
            decimal total = 0;
            if (tablaventas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablaventas.Rows)
                {
                    if (row.Cells["subtotal"].Value != null && !string.IsNullOrEmpty(row.Cells["subtotal"].Value.ToString()))
                    {
                        total += Convert.ToDecimal(row.Cells["subtotal"].Value);
                    }
                }
            }

            decimal redondeadoTotal = Math.Round(total + 0.5m, MidpointRounding.AwayFromZero);
            txttotalpagar.Text = redondeadoTotal.ToString("0.00");
        }

        private void RecalcularTotal()
        {
            decimal total = 0;
            if (tablaventas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablaventas.Rows)
                {
                    if (row.Cells["subtotal"].Value != null && !string.IsNullOrEmpty(row.Cells["subtotal"].Value.ToString()))
                    {
                        total += Convert.ToDecimal(row.Cells["subtotal"].Value);
                    }
                }
            }
            txttotalpagar.Text = total.ToString("0.00");
        }

        private void limpiarProducto()
        {
            txtidproducto.Text = "0";
            txtcodigo.Text = "";
            txtnombres.Text = "";
            txtprecio.Text = "";
            txtstock.Text = "0";
            txttalla.Text = "";
            txtcolores.Text = "";
            txtdescuento.PlaceholderText = "0";
            txtcodigopromo.Text = "";
            txtnombrepromo.Text = "";
            txttallaspromo.Text = "";
            txtcolopromo.Text = "";
            txtpreciopromo.Text = "0";
            txtstockpromo.Text = "";
            txtdescuentopromo.PlaceholderText = "0";

            txtcantidadprod.Value = 1;
            txtcantpromo.Value = 1;
            promo2x1.Checked = false;
        }

        private void tablaventas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaventas.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int index = e.RowIndex;
                if (index >= 0)
                {
                    bool respuesta = new NVentas().SumarStock(
                        Convert.ToInt32(tablaventas.Rows[index].Cells["idproducto"].Value.ToString()),
                        Convert.ToInt32(tablaventas.Rows[index].Cells["stock"].Value.ToString()));
                    tablaventas.Rows.RemoveAt(index);
                    RecalcularTotal();
                }
            }
        }

        private void tablaventas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 10)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                var w = Properties.Resources.eliminar2.Width;
                var h = Properties.Resources.eliminar2.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;
                e.Graphics.DrawImage(Properties.Resources.eliminar2, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void txtpagocon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtpagocon.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
            calcularcambio();
        }

        private void calcularcambio()
        {
            if (txttotalpagar.Text.Trim() == "")
            {
                //MessageBox.Show("No existen productos en la venta", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            decimal pagacon;
            decimal total = Convert.ToDecimal(txttotalpagar.Text);
            if (txtpagocon.Text.Trim() == "")
            {
                txtpagocon.Text = "";
            }
            if (decimal.TryParse(txtpagocon.Text.Trim(), out pagacon))
            {
                if (pagacon < total)
                {
                    txtcambio.Text = "0.00";
                }
                else
                {
                    decimal cambio = pagacon - total;
                    txtcambio.Text = cambio.ToString("0.00");
                }
            }
        }

        private void txtpagocon_TextChanged(object sender, EventArgs e)
        {
            calcularcambio();
        }

        private void txtpagocon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                calcularcambio();
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            limpiarProducto();
        }

        private void btncrearventa_Click(object sender, EventArgs e)
        {
            DataTable detalle_venta = new DataTable();
            detalle_venta.Columns.Add("idproducto", typeof(int));
            detalle_venta.Columns.Add("precio", typeof(decimal));
            detalle_venta.Columns.Add("stock", typeof(int));
            detalle_venta.Columns.Add("subtotal", typeof(decimal));
            foreach (DataGridViewRow row in tablaventas.Rows)
            {
                detalle_venta.Rows.Add(new object[]
                {
                    row.Cells["idproducto"].Value.ToString(),
                    row.Cells["precio"].Value.ToString(),
                    row.Cells["stock"].Value.ToString(),
                    row.Cells["subtotal"].Value.ToString(),
                });
            }
            int idcorrelativo = new NVentas().obtenercorrelativo();
            string numeroDocumento = string.Format("{0:00000}", idcorrelativo);
            calcularcambio();
            Ventas oVentas = new Ventas()
            {
                oUsuarios = new Usuarios() { idusuario = _usuarios.idusuario },
                tipodocumento = ((OpcionesComboBox)cbbolfac.SelectedItem).Texto,
                numerodocumento = numeroDocumento,
                documentocliente = txtddocumento.Text,
                nombrecliente = txtcliente.Text,
                montopago = Convert.ToDecimal(txtpagocon.Text),
                montocambio = Convert.ToDecimal(txtcambio.Text),
                montototal = Convert.ToDecimal(txttotalpagar.Text),
            };
            string mensaje = string.Empty;
            bool respuesta = new NVentas().registrar(oVentas, detalle_venta, out mensaje);
            if (respuesta)
            {
                var result = MessageBox.Show("Numero de venta generada correctamente: \n" + numeroDocumento + "\n\n ¿Desea Copiar al portapapeles?", "mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                    Clipboard.SetText(text: numeroDocumento);
                txtddocumento.Text = "";
                txtcliente.Text = "";
                tablaventas.Rows.Clear();
                calcularTotal();
                txtpagocon.Text = "";
                txtcambio.Text = "";
            }
            else
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private int enterPressCount = 0;
        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                enterPressCount++;
                e.Handled = true;

                if (enterPressCount == 1)
                {
                    // Obtiene una lista de productos que coinciden con el código (sin diferenciar mayúsculas y minúsculas)
                    List<Productos_tienda> productosEncontrados = new NTienda().Listar()
                        .Where(p => p.codigo.Equals(txtcodigo.Text, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if (productosEncontrados.Count > 0)
                    {
                        // Selecciona el primer producto encontrado
                        Productos_tienda oProductos = productosEncontrados.First();

                        txtidproducto.Text = oProductos.idproductotienda.ToString();
                        txtnombres.Text = oProductos.nombre;
                        txtstock.Text = oProductos.stock.ToString();
                        txtprecio.Text = oProductos.preciocompra.ToString();
                        txttalla.Text = oProductos.oTallasropa.nombretalla.ToString();
                        txtcolores.Text = oProductos.colores.ToString();
                        txtdescuento.Text = oProductos.descuento.ToString();
                        txtcantidadprod.Select();
                    }
                    else
                    {
                        // No se encontraron productos
                        txtidproducto.Text = "0";
                        txtnombres.Text = "";
                        txtstock.Text = "0";
                        txtprecio.Text = "";
                        txttalla.Text = "";
                        txtcolores.Text = "";
                        txtdescuento.Text = "0.00";
                        txtcantidadprod.Value = 1;
                    }
                }
                else if (enterPressCount == 2)
                {
                    btnAgregar_Click(sender, e);
                    enterPressCount = 0;
                }
            }
            else
            {
                enterPressCount = 0;
            }
        }

        private void txtcantidadprod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                enterPressCount++;
                e.Handled = true;
                if (enterPressCount == 1)
                {
                    Productos_tienda oProductos = new NTienda().Listar().Where(p => p.codigo.ToUpper() == txtcodigo.Text.ToUpper()).FirstOrDefault();
                    if (oProductos != null)
                    {
                        txtidproducto.Text = oProductos.idproductotienda.ToString();
                        txtnombres.Text = oProductos.nombre;
                        txtstock.Text = oProductos.stock.ToString();
                        txtprecio.Text = oProductos.preciocompra.ToString();
                        txttalla.Text = oProductos.oTallasropa.nombretalla.ToString();
                        txtcolores.Text = oProductos.colores.ToString();
                        txtdescuento.Text = oProductos.descuento.ToString();
                        txtcantidadprod.Select();
                    }
                    else
                    {
                        txtidproducto.Text = "0";
                        txtnombres.Text = "";
                        txtstock.Text = "0";
                        txtprecio.Text = "";
                        txttalla.Text = "";
                        txtcolores.Text = "";
                        txtdescuento.Text = "0.00";
                        txtcantidadprod.Value = 1;
                    }
                }
                else if (enterPressCount == 2)
                {
                    btnAgregar_Click(sender, e);
                    enterPressCount = 0;
                }
            }
            else
            {
                enterPressCount = 0;
            }
        }

        private void calcularTotal2x1()
        {
            decimal total = 0;
            if (tablaventas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablaventas.Rows)
                {
                    if (row.Cells["subtotal"].Value != null && !string.IsNullOrEmpty(row.Cells["subtotal"].Value.ToString()))
                    {
                        total += Convert.ToDecimal(row.Cells["subtotal"].Value);
                    }
                }
            }

            // Eliminar el "+ 0.5m" para evitar el aumento no deseado
            decimal redondeadoTotal = Math.Round(total, 2, MidpointRounding.AwayFromZero);
            txttotalpagar.Text = redondeadoTotal.ToString("0.00");
        }

        private void btn2x1_Click(object sender, EventArgs e)
        {
            decimal cantidad;

            // Validar la cantidad ingresada
            if (!decimal.TryParse(txtcantidadprod.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcantidadprod.Select();
                return;
            }

            if (!decimal.TryParse(txtcantpromo.Text, out cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtcantidadprod.Select();
                return;
            }

            // Verificar el stock disponible
            int stock = Convert.ToInt32(txtstock.Text);
            if (cantidad > stock)
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock disponible", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Verificar que un producto esté seleccionado
            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Verificar si el producto ya existe en la tabla de ventas
            bool productoExiste = false;
            foreach (DataGridViewRow fila in tablaventas.Rows)
            {
                if (fila.Cells["idproducto"].Value.ToString() == txtidproducto.Text)
                {
                    productoExiste = true;
                    break;
                }
            }

            if (!productoExiste)
            {
                // Restar stock
                bool respuesta = new NVentas().RestarStock(
                    Convert.ToInt32(txtidproducto.Text),
                    Convert.ToInt32(cantidad));

                if (respuesta)
                {
                    decimal precioProducto = Convert.ToDecimal(txtprecio.Text);
                    decimal subtotal;

                    // Si la promoción está activa, el subtotal será el precio de un producto
                    if (promo2x1.Checked)
                    {
                        subtotal = precioProducto;
                        cantidad = 1;
                    }
                    else
                    {
                        subtotal = precioProducto * cantidad;
                    }

                    // Agregar el producto a la tabla de ventas
                    tablaventas.Rows.Add(new object[]
                    {
                        txtidproducto.Text,
                        txtddocumento.Text,
                        txtcliente.Text,
                        txtnombres.Text,
                        txttalla.Text,
                        txtcolores.Text,
                        txtprecio.Text,
                        txtdescuento.Text,
                        cantidad.ToString(),
                        subtotal.ToString("0.00")
                    });

                    tablaventas.Rows.Add(new object[]
                    {
                        txtidproducto.Text,
                        txtddocumento.Text,
                        txtcliente.Text,
                        txtnombres.Text,
                        txttallaspromo.Text,
                        txtcolopromo.Text,
                        txtpreciopromo.Text,
                        txtdescuentopromo.Text,
                        "1",
                        "0.00"
                    });

                    calcularTotal2x1();
                    limpiarProducto();
                    txtcodigo.Select();
                }
                else
                {
                    MessageBox.Show("Error al restar el stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("El producto ya existe en la tabla.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void promo2x1_CheckedChanged(object sender, EventArgs e)
        {
            if (promo2x1.Checked)
            {
                txtcantidadprod.Text = "1";
                btnAgregar.Visible = false;
                btn2x1.Visible = true;
                txtdescuento.Text = "0";
                txtdescuentopromo.Text = "0";

                btnpromo.Visible = true;
                txtcodigopromo.Visible = true;
                txtnombrepromo.Visible = true;
                txttallaspromo.Visible = true;
                txtcolopromo.Visible = true;
                txtpreciopromo.Visible = true;
                txtdescuentopromo.Visible = true;
                txtcantpromo.Visible = true;
                txtstockpromo.Visible = true;
            }
            else
            {
                txtcantidadprod.Text = "1";
                txtdescuento.Text = "";
                btnAgregar.Visible = true;
                btn2x1.Visible = false;

                btnpromo.Visible = false;
                txtcodigopromo.Visible = false;
                txtnombrepromo.Visible = false;
                txttallaspromo.Visible = false;
                txtcolopromo.Visible = false;
                txtpreciopromo.Visible = false;
                txtdescuentopromo.Visible = false;
                txtcantpromo.Visible = false;
                txtstockpromo.Visible = false;
            }
        }

        private void btnpromo_Click(object sender, EventArgs e)
        {
            Productos_tienda oProductos = new NTienda().Listar().Where(p => p.codigo.ToUpper() == txtcodigopromo.Text.ToUpper()).FirstOrDefault();
            if (oProductos != null)
            {
                txtidproducto.Text = oProductos.idproductotienda.ToString();
                txtnombrepromo.Text = oProductos.nombre.ToString() + " (Prom 2x1).";
                txtstockpromo.Text = oProductos.stock.ToString();
                txtpreciopromo.Text = oProductos.preciocompra.ToString();
                txttallaspromo.Text = oProductos.oTallasropa.nombretalla.ToString();
                txtcolopromo.Text = oProductos.colores.ToString();
                txtdescuentopromo.Text = "0".ToString();
                txtcantidadprod.Select();
            }
            else
            {
                txtidproducto.Text = "0";
                txtnombrepromo.Text = "";
                txtpreciopromo.Text = "";
                txttallaspromo.Text = "";
                txtcolopromo.Text = "";
                txtdescuentopromo.PlaceholderText = "  0";
                txtcantidadprod.Value = 1;
            }
        }

    }
}
