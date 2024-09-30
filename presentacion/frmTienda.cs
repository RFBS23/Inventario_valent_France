using CustomAlertBoxDemo;
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
    public partial class frmTienda : Form
    {
        public frmTienda()
        {
            InitializeComponent();
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void frmTienda_Load(object sender, EventArgs e)
        {
            LlenarComboBox();

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

            promo.Checked = false;
            /*
            promo.Items.Add(new OpcionesComboBox() { Valor = 1, Texto = "Promoción 2x1" });
            promo.Items.Add(new OpcionesComboBox() { Valor = 0, Texto = "Sin promoción" });
            promo2x1.DisplayMember = "Texto";
            promo2x1.ValueMember = "Valor";
            promo2x1.SelectedIndex = 0;*/

            List<Productos_tienda> listaProductos = new NTienda().Listar();
            foreach (Productos_tienda item in listaProductos)
            {
                tablaproductos.Rows.Add(new object[] { "", item.idproductotienda, item.codigo, item.nombre, item.descripcion, item.oCategorias.idcategoria, item.oCategorias.nombrecategoria, item.oTallasropa.idtallaropa, item.oTallasropa.nombretalla, item.oMarcas.idmarca, item.oMarcas.nombremarca, item.colores, item.stock, item.temporada, item.descuento, item.promo2x1 == true ? 1 : 0, item.promo2x1 == true ? "Promoción 2x1" : "Sin promocion", item.preciocompra, item.total });
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precioventa = 0;
            string mensaje = string.Empty;

            Productos_tienda objproductos = new Productos_tienda()
            {
                idproductotienda = Convert.ToInt32(txtid.Text),
                codigo = txtcodigo.Text,
                nombre = txtnombreproducto.Text,
                descripcion = txtdescripcion.Text,
                oCategorias = new Categoria() { idcategoria = Convert.ToInt32(((OpcionesComboBox)cbcategoria.SelectedItem).Valor) },
                oTallasropa = new Tallas() { idtallaropa = Convert.ToInt32(((OpcionesComboBox)cbtallas.SelectedItem).Valor) },
                oMarcas = new Marcas() { idmarca = Convert.ToInt32(((OpcionesComboBox)cbmarca.SelectedItem).Valor) },
                stock = Convert.ToInt32(txtstock.Text),
                colores = txtcolores.Text,
                temporada = cbtemporada.Text,
                precioventa = Convert.ToDecimal(txtprecioventa.Text),
                descuento = Convert.ToInt32(txtdescuento.Text),
                total = Convert.ToDecimal(txttotaldinero.Text),
                //promo2x1 = Convert.ToInt32(((OpcionesComboBox)promo2x1.SelectedItem).Valor) == 1
                promo2x1 = promo.Checked
            };
            if (btnAgregar.Text == "    Editar")
            {
                // Lógica para editar productos
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
            cbtemporada.SelectedIndex = 0;
            txtdescuento.PlaceholderText = "";
            txttotaldinero.PlaceholderText = "";
            txtprecioventa.Text = "";
            promo.Checked = false;

            txtcodigo.Select();
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
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
                        cbtemporada.Text = row.Cells["temporada"].Value.ToString();
                        txtdescuento.Text = row.Cells["descuento"].Value.ToString();
                        promo.Checked = Convert.ToBoolean(row.Cells["valorpromo"].Value);
                        txtprecioventa.Text = row.Cells["precioventa"].Value.ToString();
                        txttotaldinero.Text = row.Cells["total"].Value.ToString();

                        btnAgregar.Text = "    Editar";
                        break;
                    }
                }
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
                    cbtemporada.Text = tablaproductos.Rows[indice].Cells["temporada"].Value.ToString();
                    txtdescuento.Text = tablaproductos.Rows[indice].Cells["descuento"].Value.ToString();
                    promo.Checked = Convert.ToBoolean(tablaproductos.Rows[indice].Cells["valorpromo"].Value); // Actualiza el CheckBox
                    txtprecioventa.Text = tablaproductos.Rows[indice].Cells["precioventa"].Value.ToString();
                    txttotaldinero.Text = tablaproductos.Rows[indice].Cells["total"].Value.ToString();
                }
            }
        }
    }
}
