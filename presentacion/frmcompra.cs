using Entidad;
using Negocio;
using presentacion.Modales;
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
    public partial class frmcompra : Form
    {
        private Usuarios _usuarios;
        public frmcompra(Usuarios oUsuarios = null)
        {
            _usuarios = oUsuarios;
            InitializeComponent();
        }

        private void frmcompra_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            lblfecha.Text = $"{fechaActual.Day}/{fechaActual.Month}/{fechaActual.Year}";

            cbbolfac.Items.Add(new OpcionesComboBox() { Valor = "Boleta", Texto = "Boleta" });
            cbbolfac.Items.Add(new OpcionesComboBox() { Valor = "Factura", Texto = "Factura" });
            cbbolfac.DisplayMember = "Texto";
            cbbolfac.ValueMember = "Valor";
            cbbolfac.SelectedIndex = 0;

            txtstock.Text = "0";
            txtprecioventa.Text = "0.00";
            txtpreciocompra.Text = "0.00";
            txtidproducto.Text = "0";
            txttotalpagar.Text = "0.00";
        }

        private void btnbuscarproveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new frmmodProveedores())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtidproveedor.Text = modal._Proveedor.idproveedor.ToString();
                    txtddocumento.Text = modal._Proveedor.documento;
                    txtproveedor.Text = modal._Proveedor.nombreproveedor;
                }
                else
                {
                    txtddocumento.Select();
                }
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Productos oProductos = new NProducto().Listar().Where(p => p.codigo == txtcodigo.Text).FirstOrDefault();
            if (oProductos != null)
            {
                txtidproducto.Text = oProductos.idproducto.ToString();
                txtnombres.Text = oProductos.nombre;
                txtstock.Text = oProductos.stock.ToString();
                txtprecioventa.Text = oProductos.precioventa.ToString();
                txttalla.Text = oProductos.oTallasropa.nombretalla.ToString();
                txtcolores.Text = oProductos.colores.ToString();
                txtcantidadprod.Select();
            }
            else
            {
                txtidproducto.Text = "0";
                txtnombres.Text = "";
                txtstock.Text = "0";
                txtprecioventa.Text = "";
                txttalla.Text = "";
                txtcolores.Text = "";
                txtcantidadprod.Value = 1;
            }
        }

        private void limpiarProducto()
        {
            txtidproducto.Text = "0";
            txtcodigo.Text = "";
            txtnombres.Text = "";
            txtprecioventa.Text = "";
            txtpreciocompra.Text = "";
            txtstock.Text = "";
            txttalla.Text = "";
            txtcolores.Text = "";

            txtcantidadprod.Value = 1;
        }

        private void calcularTotal()
        {
            decimal total = 0;
            if (tablacompras.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablacompras.Rows)
                    total += Convert.ToDecimal(row.Cells["subtotal"].Value.ToString());
            }
            txttotalpagar.Text = total.ToString("0.00");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal preciocompra = 0;
            decimal precioventa = 0;
            bool producto_existe = false;

            if (int.Parse(txtidproducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtpreciocompra.Text, out preciocompra))
            {
                MessageBox.Show("Precio de compra - Formato incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtpreciocompra.Select();
                return;
            }

            if (!decimal.TryParse(txtprecioventa.Text, out precioventa))
            {
                MessageBox.Show("Precio de venta - Formato incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtprecioventa.Select();
                return;
            }

            foreach (DataGridViewRow fila in tablacompras.Rows)
            {
                if (fila.Cells["idproducto"].Value.ToString() == txtidproducto.Text)
                {
                    producto_existe = true;
                    break;
                }
            }

            if (!producto_existe)
            {                
                tablacompras.Rows.Add(new object[]
                {
                    txtidproducto.Text,
                    txtddocumento.Text,
                    txtproveedor.Text,
                    txtnombres.Text,
                    txttalla.Text,
                    txtcolores.Text,
                    precioventa.ToString("0.00"),
                    preciocompra.ToString("0.00"),                        
                    txtcantidadprod.Value.ToString(),
                    (txtcantidadprod.Value * preciocompra).ToString("0.00")
                });
                calcularTotal();
                limpiarProducto();
                txtcodigo.Select();
            }
        }

        private void tablacompras_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void tablacompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablacompras.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int indice = e.RowIndex;
                if(indice >= 0)
                {
                    tablacompras.Rows.RemoveAt(indice);
                    calcularTotal();
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            limpiarProducto();
        }

        private void txtpreciocompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtpreciocompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if(Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void txtprecioventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtprecioventa.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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
        }

        private void btncrearcompra_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtidproveedor.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un proveedor", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if(tablacompras.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar productos en la compra", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataTable detalle_compra = new DataTable();
            detalle_compra.Columns.Add("idproducto", typeof(int));            
            detalle_compra.Columns.Add("preciocompra", typeof(decimal));
            detalle_compra.Columns.Add("precio", typeof(decimal));
            detalle_compra.Columns.Add("stock", typeof(int));
            detalle_compra.Columns.Add("subtotal", typeof(decimal));

            foreach (DataGridViewRow row in tablacompras.Rows)
            {
                detalle_compra.Rows.Add(new object[]
                {
                    row.Cells["idproducto"].Value.ToString(),
                    row.Cells["preciocompra"].Value.ToString(),
                    row.Cells["precio"].Value.ToString(),                    
                    row.Cells["stock"].Value.ToString(),
                    row.Cells["subtotal"].Value.ToString(),
                });
            }

            int idcorrelativo = new Ncompras().obtenercorrelativo();
            string numeroDocumento = string.Format("{0:00000}", idcorrelativo);

            Compra oCompra = new Compra()
            {
                oUsuarios = new Usuarios() { idusuario = _usuarios.idusuario },
                oProveedor = new Proveedor() { idproveedor = Convert.ToInt32(txtidproveedor.Text)},
                tipodocumento = ((OpcionesComboBox)cbbolfac.SelectedItem).Texto,
                numerodocumento = numeroDocumento,
                montototal = Convert.ToDecimal(txttotalpagar.Text),
            };

            string mensaje = string.Empty;
            bool respuesta = new Ncompras().registrar(oCompra, detalle_compra, out mensaje);
            if (respuesta)
            {
                var result = MessageBox.Show("Numero de compra generada correctamente: \n" + numeroDocumento + "\n\n ¿Desea Copiar al portapapeles?", "mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                    Clipboard.SetText(text: numeroDocumento);

                txtidproveedor.Text = "0";
                txtddocumento.Text = "";
                txtproveedor.Text = "";
                tablacompras.Rows.Clear();
                calcularTotal();
            }
            else
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
