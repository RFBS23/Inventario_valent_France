using Entidad;
using Negocio;
using presentacion.Utilidades;
using presentacion.Utilidades.modales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomAlertBoxDemo;

namespace presentacion
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();

            txtprecioventa.TextChanged += txtprecioventa_TextChanged;
            txtstock.TextChanged += txtstock_TextChanged;
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            LlenarComboBox();
            DateTime fechaActual = DateTime.Now;
            lblfecha.Text = $"{fechaActual.Year}-{fechaActual.Month}-{fechaActual.Day}";

            txtstock.Text = "0";
            txtdescuento.Text = "0";
            txttotaldinero.Text = "0.00";
            txtprecioventa.Text = "0.00";

            List<Categoria> listacat = new NCategoria().ListarCategorias();
            cbcategoria.Items.Add(new OpcionesComboBox() { Valor = 0, Texto = "Elija una categoria" });
            foreach (Categoria item in listacat)
            {
                cbcategoria.Items.Add(new OpcionesComboBox() { Valor = item.idcategoria, Texto = item.nombrecategoria });
            }
            cbcategoria.DisplayMember = "Texto";
            cbcategoria.ValueMember = "Valor";
            cbcategoria.SelectedIndex = 0;

            List<Marcas> listamarca = new NMarca().FiltrosMarcas();
            cbmarca.Items.Add(new OpcionesComboBox() { Valor = 0, Texto = "Elija una marca" });
            foreach (Marcas item in listamarca)
            {
                cbmarca.Items.Add(new OpcionesComboBox() { Valor = item.idmarca, Texto = item.nombremarca });
            }
            cbmarca.DisplayMember = "Texto";
            cbmarca.ValueMember = "Valor";
            cbmarca.SelectedIndex = 0;

            List<Tallas> listatalla = new NTallas().FiltrosTallas();
            cbtallas.Items.Add(new OpcionesComboBox() { Valor = 0, Texto = "Seleccione la talla" });
            foreach (Tallas item in listatalla)
            {
                cbtallas.Items.Add(new OpcionesComboBox() { Valor = item.idtallaropa, Texto = item.nombretalla });
            }
            cbtallas.DisplayMember = "Texto";
            cbtallas.ValueMember = "Valor";
            cbtallas.SelectedIndex = 0;

            List<Productos> listaProductos = new NProducto().Listar();
            foreach (Productos item in listaProductos)
            {
                tablaproductos.Rows.Add(new object[] { "", item.idproducto, item.codigo, item.nombre, item.descripcion, item.oCategorias.idcategoria, item.oCategorias.nombrecategoria, item.oTallasropa.idtallaropa, item.oTallasropa.nombretalla, item.oMarcas.idmarca, item.oMarcas.nombremarca, item.stock, item.colores, item.numcaja, item.temporada, item.precioventa, item.descuento, item.total, item.ubicacion, item.fecharegistro });
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precioventa = 0;
            string mensaje = string.Empty;

            Productos objproductos = new Productos()
            {
                idproducto = Convert.ToInt32(txtid.Text),
                codigo = txtcodigo.Text,
                nombre = txtnombreproducto.Text,
                descripcion = txtdescripcion.Text,
                oCategorias = new Categoria() { idcategoria = Convert.ToInt32(((OpcionesComboBox)cbcategoria.SelectedItem).Valor) },
                oTallasropa = new Tallas() { idtallaropa = Convert.ToInt32(((OpcionesComboBox)cbtallas.SelectedItem).Valor) },
                oMarcas = new Marcas() { idmarca = Convert.ToInt32(((OpcionesComboBox)cbmarca.SelectedItem).Valor) },
                stock = Convert.ToInt32(txtstock.Text),
                colores = txtcolores.Text,
                numcaja = txtcajas.Text,
                temporada = cbtemporada.Text,
                precioventa = Convert.ToDecimal(txtprecioventa.Text),
                descuento = Convert.ToInt32(txtdescuento.Text),
                total = Convert.ToDecimal(txttotaldinero.Text),
                ubicacion = cbubicacion.Text,
                fecharegistro = lblfecha.Text
            };
            if (btnAgregar.Text == "    Agregar")
            {
                // Lógica para agregar productos
                int idproductogenerado = new NProducto().Registrar(objproductos, out mensaje);

                if (idproductogenerado != 0)
                {
                    tablaproductos.Rows.Add(new object[] {"", idproductogenerado, txtcodigo.Text, txtnombreproducto.Text, txtdescripcion.Text,
                        ((OpcionesComboBox)cbcategoria.SelectedItem).Valor.ToString(),
                        ((OpcionesComboBox)cbcategoria.SelectedItem).Texto.ToString(),
                        ((OpcionesComboBox)cbtallas.SelectedItem).Valor.ToString(),
                        ((OpcionesComboBox)cbtallas.SelectedItem).Texto.ToString(),
                        ((OpcionesComboBox)cbmarca.SelectedItem).Valor.ToString(),
                        ((OpcionesComboBox)cbmarca.SelectedItem).Texto.ToString(),
                        txtcolores.Text,
                        txtstock.Text,
                        txtcajas.Text,
                        cbtemporada.Text,
                        txtdescuento.Text,
                        Convert.ToDecimal(txtprecioventa.Text).ToString("0.00"),
                        txttotaldinero.Text,
                        cbubicacion.Text,
                        lblfecha.Text,
                    });
                    Limpiar();
                    this.Alert("Producto Registrado", Form_Alert.enmType.Success);
                }
                else
                {
                    MessageBox.Show(mensaje);
                    this.Alert("No se pudo registrar", Form_Alert.enmType.Error);
                }
            }
            else if (btnAgregar.Text == "    Editar")
            {
                // Lógica para editar productos
                bool resultado = new NProducto().Editar(objproductos, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = tablaproductos.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["idproducto"].Value = txtid.Text;
                    row.Cells["codigo"].Value = txtcodigo.Text;
                    row.Cells["nombre"].Value = txtnombreproducto.Text;
                    row.Cells["descripcion"].Value = txtdescripcion.Text;
                    row.Cells["idcategoria"].Value = ((OpcionesComboBox)cbcategoria.SelectedItem).Valor.ToString();
                    row.Cells["nombrecategoria"].Value = ((OpcionesComboBox)cbcategoria.SelectedItem).Texto.ToString();
                    row.Cells["idtallaropa"].Value = ((OpcionesComboBox)cbtallas.SelectedItem).Valor.ToString();
                    row.Cells["nombretalla"].Value = ((OpcionesComboBox)cbtallas.SelectedItem).Texto.ToString();
                    row.Cells["idmarca"].Value = ((OpcionesComboBox)cbmarca.SelectedItem).Valor.ToString();
                    row.Cells["nombremarca"].Value = ((OpcionesComboBox)cbmarca.SelectedItem).Texto.ToString();
                    row.Cells["colores"].Value = txtcolores.Text;
                    row.Cells["stock"].Value = txtstock.Text;
                    row.Cells["numcaja"].Value = txtcajas.Text;
                    row.Cells["temporada"].Value = cbtemporada.Text;
                    row.Cells["descuento"].Value = txtdescuento.Text;
                    row.Cells["precioventa"].Value = Convert.ToDecimal(txtprecioventa.Text).ToString("0.00");
                    row.Cells["total"].Value = txttotaldinero.Text;
                    row.Cells["ubicacion"].Value = cbubicacion.Text;
                    Limpiar();
                    this.Alert("Producto Editado", Form_Alert.enmType.Success);
                }
                else
                {
                    MessageBox.Show(mensaje);
                    this.Alert("No se pudo editar", Form_Alert.enmType.Error);
                }
                btnAgregar.Text = "    Agregar";
            }

        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";
            txtcodigo.Text = "";
            txtnombreproducto.Text = "";
            txtdescripcion.Text = "";
            cbcategoria.SelectedIndex = 0;
            cbtallas.SelectedIndex = 0;
            cbmarca.SelectedIndex = 0;
            txtcolores.Text = "";
            txtstock.Text = "";
            txtcajas.Text = "";
            cbtemporada.SelectedIndex = 0;
            cbubicacion.SelectedIndex = 0;
            txtdescuento.PlaceholderText = "";
            txttotaldinero.PlaceholderText = "";
            txtprecioventa.Text = "";

            txtcodigo.Select();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿ESTA SEGURO DE ELIMINAR A ESTE PRODUCTO?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Productos objproductos = new Productos()
                    {
                        idproducto = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new NProducto().Eliminar(objproductos, out mensaje);
                    if (respuesta)
                    {
                        // Supongamos que tienes una instancia del formulario `frmProductos`
                        frmProductos formProductos = (frmProductos)Application.OpenForms["frmProductos"];
                        if (formProductos != null)
                        {
                            formProductos.tablaproductos.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                        }
                        else
                        {
                            MessageBox.Show("No se pudo acceder a la tabla de productos.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                Limpiar();
            }
        }

        private void LlenarComboBox()
        {
            // Crear una lista de estaciones del año con nombre y año
            List<string> estaciones = new List<string>
            {
                ObtenerEstacionDelAño("Primavera", DateTime.Now.Year - 1),
                ObtenerEstacionDelAño("Verano", DateTime.Now.Year - 1),
                ObtenerEstacionDelAño("Otoño", DateTime.Now.Year - 1),
                ObtenerEstacionDelAño("Invierno", DateTime.Now.Year - 1) 
                // -1 o +1 es para retroceder o adelantar el año en el que estamos
            };
            // Asignar la lista al ComboBox
            cbtemporada.DataSource = estaciones;
        }

        private string ObtenerEstacionDelAño(string nombreEstacion, int año)
        {
            // Construir la cadena con el nombre y el año
            return $"{nombreEstacion} - {año}";
        }

        private void txtprecioventa_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void txtstock_TextChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            if (decimal.TryParse(txtprecioventa.Text, out decimal precioVenta) && int.TryParse(txtstock.Text, out int stock))
            {
                decimal nuevoTotal = precioVenta * stock;

                txttotaldinero.Text = nuevoTotal.ToString("0.00");
            }
        }

        private void txtcajas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar == 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Ingresa Solo Numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar == 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Ingresa Solo Numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtprecioventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar == 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Ingresa Solo Numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void tablaproductos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {

                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.check1.Width;
                var h = Properties.Resources.check1.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check1, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void tablaproductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaproductos.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = tablaproductos.Rows[indice].Cells["idproducto"].Value.ToString();
                    txtcodigo.Text = tablaproductos.Rows[indice].Cells["codigo"].Value.ToString();
                    txtnombreproducto.Text = tablaproductos.Rows[indice].Cells["nombre"].Value.ToString();
                    txtdescripcion.Text = tablaproductos.Rows[indice].Cells["descripcion"].Value.ToString();

                    foreach (OpcionesComboBox ocb in cbcategoria.Items)
                    {
                        if (Convert.ToInt32(ocb.Valor) == Convert.ToInt32(tablaproductos.Rows[indice].Cells["idcategoria"].Value))
                        {
                            int indice_combo = cbcategoria.Items.IndexOf(ocb);
                            cbcategoria.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionesComboBox otb in cbtallas.Items)
                    {
                        if (Convert.ToInt32(otb.Valor) == Convert.ToInt32(tablaproductos.Rows[indice].Cells["idtallaropa"].Value))
                        {
                            int indice_combo = cbtallas.Items.IndexOf(otb);
                            cbtallas.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionesComboBox otb in cbmarca.Items)
                    {
                        if (Convert.ToInt32(otb.Valor) == Convert.ToInt32(tablaproductos.Rows[indice].Cells["idmarca"].Value))
                        {
                            int indice_combo = cbmarca.Items.IndexOf(otb);
                            cbmarca.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    txtcolores.Text = tablaproductos.Rows[indice].Cells["colores"].Value.ToString();
                    txtstock.Text = tablaproductos.Rows[indice].Cells["stock"].Value.ToString();
                    txtcajas.Text = tablaproductos.Rows[indice].Cells["numcaja"].Value.ToString();
                    cbtemporada.Text = tablaproductos.Rows[indice].Cells["temporada"].Value.ToString();
                    txtdescuento.Text = tablaproductos.Rows[indice].Cells["descuento"].Value.ToString();
                    txtprecioventa.Text = tablaproductos.Rows[indice].Cells["precioventa"].Value.ToString();
                    txttotaldinero.Text = tablaproductos.Rows[indice].Cells["total"].Value.ToString();
                    cbubicacion.Text = tablaproductos.Rows[indice].Cells["ubicacion"].Value.ToString();
                }
            }
        }

        private void btnbuscarlista_Click(object sender, EventArgs e)
        {
            string filtro = txtcodigo.Text.Trim().ToUpper();

            if (tablaproductos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablaproductos.Rows)
                {
                    if (row.Cells["codigo"].Value != null && row.Cells["codigo"].Value.ToString().Trim().ToUpper().Contains(filtro))
                    {
                        // Llenar los controles con los datos del producto encontrado
                        txtindice.Text = row.Index.ToString();
                        txtid.Text = row.Cells["idproducto"].Value.ToString();
                        txtcodigo.Text = row.Cells["codigo"].Value.ToString();
                        txtnombreproducto.Text = row.Cells["nombre"].Value.ToString();
                        txtdescripcion.Text = row.Cells["descripcion"].Value.ToString();

                        foreach (OpcionesComboBox ocb in cbcategoria.Items)
                        {
                            if (Convert.ToInt32(ocb.Valor) == Convert.ToInt32(row.Cells["idcategoria"].Value))
                            {
                                cbcategoria.SelectedIndex = cbcategoria.Items.IndexOf(ocb);
                                break;
                            }
                        }

                        foreach (OpcionesComboBox otb in cbtallas.Items)
                        {
                            if (Convert.ToInt32(otb.Valor) == Convert.ToInt32(row.Cells["idtallaropa"].Value))
                            {
                                cbtallas.SelectedIndex = cbtallas.Items.IndexOf(otb);
                                break;
                            }
                        }

                        foreach (OpcionesComboBox omb in cbmarca.Items)
                        {
                            if (Convert.ToInt32(omb.Valor) == Convert.ToInt32(row.Cells["idmarca"].Value))
                            {
                                cbmarca.SelectedIndex = cbmarca.Items.IndexOf(omb);
                                break;
                            }
                        }

                        txtcolores.Text = row.Cells["colores"].Value.ToString();
                        txtstock.Text = row.Cells["stock"].Value.ToString();
                        txtcajas.Text = row.Cells["numcaja"].Value.ToString();
                        cbtemporada.Text = row.Cells["temporada"].Value.ToString();
                        txtdescuento.Text = row.Cells["descuento"].Value.ToString();
                        txtprecioventa.Text = row.Cells["precioventa"].Value.ToString();
                        txttotaldinero.Text = row.Cells["total"].Value.ToString();
                        cbubicacion.Text = row.Cells["ubicacion"].Value.ToString();

                        btnAgregar.Text = "    Editar";
                        break;
                    }
                }
            }
        }
    }
}
