using Entidad;
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
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        private async void btnbuscar_Click(object sender, EventArgs e)
        {
            if (txtruc.Text.Length == 11)
            {
                string apiUrl = $"https://api.apis.net.pe/v1/ruc?numero={txtruc.Text}";
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
                                txtnombre.Text = $"{json.nombre}";
                                txtdireccion.Text = $"{json.direccion}";
                            }
                            else
                            {
                                MessageBox.Show("La respuesta de la API no tiene el formato esperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"No se ha podido encontrar el ruc buscado..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener la información del RUC: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            lblfecha.Text = $"{fechaActual.Day}/{fechaActual.Month}/{fechaActual.Year}";

            List<Proveedor> listaUsuario = new NProveedores().Listar();
            foreach (Proveedor item in listaUsuario)
            {
                tablaproveedor.Rows.Add(new object[] { "", item.idproveedor, item.documento, item.nombreproveedor, item.direccion, item.telefono, item.correo, item.fecharegistro });
            }
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar == 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Ingresa Solo Numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";

            txtruc.Text = "";
            txtnombre.Text = "";
            txtdireccion.Text = "";
            txttelefono.Text = "";
            txtcorreo.Text = "";

            txtnombre.Select();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Proveedor objproveedor = new Proveedor()
            {
                idproveedor = Convert.ToInt32(txtid.Text),
                documento = txtruc.Text,
                nombreproveedor = txtnombre.Text,
                direccion = txtdireccion.Text,
                telefono = txttelefono.Text,
                correo = txtcorreo.Text,
                fecharegistro = lblfecha.Text
            };
            if (btnAgregar.Text == "    Agregar")
            {
                int idusuariogenerado = new NProveedores().Registrar(objproveedor, out mensaje);
                if (idusuariogenerado != 0)
                {
                    tablaproveedor.Rows.Add(new object[] {"", idusuariogenerado, txtruc.Text, txtnombre.Text, txtdireccion.Text, txttelefono.Text, txtcorreo.Text,
                        lblfecha.Text
                    });
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else if (btnAgregar.Text == "    Editar")
            {
                bool resultado = new NProveedores().Editar(objproveedor, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = tablaproveedor.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["idproveedor"].Value = Convert.ToInt32(txtid.Text);
                    row.Cells["documento"].Value = txtruc.Text;
                    row.Cells["nombre"].Value = txtnombre.Text;
                    row.Cells["direccion"].Value = txtdireccion.Text;
                    row.Cells["telefono"].Value = txttelefono.Text;
                    row.Cells["correo"].Value = txtcorreo.Text;

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
                btnAgregar.Text = "    Agregar";
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿ESTA SEGURO DE ELIMINAR A ESTE PROVEEDOR?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Proveedor objproveedor = new Proveedor()
                    {
                        idproveedor = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new NProveedores().Eliminar(objproveedor, out mensaje);
                    if (respuesta)
                    {
                        tablaproveedor.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                Limpiar();
            }
        }

        private void tablaproveedor_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void tablaproveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablaproveedor.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = tablaproveedor.Rows[indice].Cells["idproveedor"].Value.ToString();
                    txtruc.Text = tablaproveedor.Rows[indice].Cells["documento"].Value.ToString();
                    txtnombre.Text = tablaproveedor.Rows[indice].Cells["nombre"].Value.ToString();
                    txtdireccion.Text = tablaproveedor.Rows[indice].Cells["direccion"].Value.ToString();
                    txttelefono.Text = tablaproveedor.Rows[indice].Cells["telefono"].Value.ToString();
                    txtcorreo.Text = tablaproveedor.Rows[indice].Cells["correo"].Value.ToString();

                    btnAgregar.Text = "    Editar";
                }
            }
        }

        private void btnbuscarlista_Click(object sender, EventArgs e)
        {
            String columnaFiltro = ((OpcionesComboBox)listabuscar.SelectedItem).Valor.ToString();
            if (tablaproveedor.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablaproveedor.Rows)
                {
                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbuscar.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {
            txtbuscar.Text = "";
            foreach (DataGridViewRow row in tablaproveedor.Rows)
            {
                row.Visible = true;
            }
            txtbuscar.Select();
        }
    }
}
