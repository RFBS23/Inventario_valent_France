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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Now;
            lblfecha.Text = $"{fechaActual.Day}/{fechaActual.Month}/{fechaActual.Year}";

            foreach (DataGridViewColumn columna in tablausuarios.Columns)
            {
                if (columna.Visible == true)
                {
                    listabuscar.Items.Add(new OpcionesComboBox() { Valor = columna.Name, Texto = columna.HeaderText });
                }
                listabuscar.DisplayMember = "Texto";
                listabuscar.ValueMember = "Valor";
                listabuscar.SelectedIndex = 0;
            }

            /*listar estado y nivel de acceso*/
            cbestado.Items.Add(new OpcionesComboBox() { Valor = 1, Texto = "Activo" });
            cbestado.Items.Add(new OpcionesComboBox() { Valor = 0, Texto = "Inactivo" });
            cbestado.DisplayMember = "Texto";
            cbestado.ValueMember = "Valor";
            cbestado.SelectedIndex = 0;

            List<NivelAcceso> listanivelesaccesos = new NNivelAcceso().listar();
            cbnivelacceso.Items.Add(new OpcionesComboBox() { Valor = 0, Texto = "Elija el nivel de acceso" });
            foreach (NivelAcceso item in listanivelesaccesos)
            {
                cbnivelacceso.Items.Add(new OpcionesComboBox() { Valor = item.idnivelacceso, Texto = item.nombreacceso });
            }
            cbnivelacceso.DisplayMember = "Texto";
            cbnivelacceso.ValueMember = "Valor";
            cbnivelacceso.SelectedIndex = 0;

            List<Usuarios> listaUsuario = new NUsuarios().Listar();
            foreach (Usuarios item in listaUsuario)
            {
                tablausuarios.Rows.Add(new object[] { "", item.idusuario, item.documento, item.nombres, item.apellidos, item.nombreusuario, item.correo, item.clave, item.oNivelAcceso.idnivelacceso, item.oNivelAcceso.nombreacceso, item.estado == true ? 1 : 0, item.estado == true ? "Activo" : "Inactivo",});
            }
        }

        private async void btnbuscar_Click(object sender, EventArgs e)
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
                                txtnombres.Text = $"{json.nombres}";
                                txtapellidos.Text = $"{json.apellidoPaterno} {json.apellidoMaterno}";
                            }
                            else
                            {
                                MessageBox.Show("La respuesta de la API no tiene el formato esperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show($"No se ha podido encontrar el dni buscado..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener la información del DNI: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tablausuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablausuarios.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = tablausuarios.Rows[indice].Cells["idusuario"].Value.ToString();
                    txtddocumento.Text = tablausuarios.Rows[indice].Cells["documento"].Value.ToString();
                    txtnombres.Text = tablausuarios.Rows[indice].Cells["nombres"].Value.ToString();
                    txtapellidos.Text = tablausuarios.Rows[indice].Cells["apellidos"].Value.ToString();
                    txtusuario.Text = tablausuarios.Rows[indice].Cells["nombreusuario"].Value.ToString();
                    txtcorreo.Text = tablausuarios.Rows[indice].Cells["correo"].Value.ToString();
                    txtclave.Text = tablausuarios.Rows[indice].Cells["clave"].Value.ToString();

                    foreach (OpcionesComboBox ocb in cbnivelacceso.Items)
                    {
                        if (Convert.ToInt32(ocb.Valor) == Convert.ToInt32(tablausuarios.Rows[indice].Cells["idnivelacceso"].Value))
                        {
                            int indice_combo = cbnivelacceso.Items.IndexOf(ocb);
                            cbnivelacceso.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    foreach (OpcionesComboBox oc in cbestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(tablausuarios.Rows[indice].Cells["valorestado"].Value))
                        {
                            int indice_combo = cbestado.Items.IndexOf(oc);
                            cbestado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                    txtddocumento.Enabled = false;
                    btnAgregar.Text = "    Editar";
                }
            }
        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";

            txtddocumento.Text = "";
            txtnombres.Text = "";
            txtapellidos.Text = "";
            txtusuario.Text = "";
            txtcorreo.Text = "";
            txtclave.Text = "";
            cbestado.SelectedIndex = 0;
            cbnivelacceso.SelectedIndex = 0;

            txtddocumento.Enabled = true;

            txtddocumento.Select();
        }

        private void tablausuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;
            Usuarios objusuarios = new Usuarios()
            {
                idusuario = Convert.ToInt32(txtid.Text),
                documento = txtddocumento.Text,
                nombres = txtnombres.Text,
                apellidos = txtapellidos.Text,
                nombreusuario = txtusuario.Text,
                correo = txtcorreo.Text,
                clave = txtclave.Text,
                oNivelAcceso = new NivelAcceso() { idnivelacceso = Convert.ToInt32(((OpcionesComboBox)cbnivelacceso.SelectedItem).Valor) },
                estado = Convert.ToInt32(((OpcionesComboBox)cbestado.SelectedItem).Valor) == 1 ? true : false,
            };
            if(btnAgregar.Text == "    Agregar")
            {
                int idusuariogenerado = new NUsuarios().Registrar(objusuarios, out mensaje);
                if(idusuariogenerado != 0)
                {
                    tablausuarios.Rows.Add(new object[] {"", idusuariogenerado, txtddocumento.Text, txtnombres.Text, txtapellidos.Text, txtusuario.Text, txtcorreo.Text, txtclave.Text,
                        ((OpcionesComboBox)cbnivelacceso.SelectedItem).Valor.ToString(),
                        ((OpcionesComboBox)cbnivelacceso.SelectedItem).Texto.ToString(),
                        ((OpcionesComboBox)cbestado.SelectedItem).Valor.ToString(),
                        ((OpcionesComboBox)cbestado.SelectedItem).Texto.ToString()
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
                bool resultado = new NUsuarios().Editar(objusuarios, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = tablausuarios.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["idusuario"].Value = Convert.ToInt32(txtid.Text);
                    row.Cells["documento"].Value = txtddocumento.Text;
                    row.Cells["nombres"].Value = txtnombres.Text;
                    row.Cells["apellidos"].Value = txtapellidos.Text;
                    row.Cells["nombreusuario"].Value = txtusuario.Text;
                    row.Cells["correo"].Value = txtcorreo.Text;
                    row.Cells["clave"].Value = txtclave.Text;
                    row.Cells["idnivelacceso"].Value = ((OpcionesComboBox)cbnivelacceso.SelectedItem).Valor.ToString();
                    row.Cells["nombreacceso"].Value = ((OpcionesComboBox)cbnivelacceso.SelectedItem).Texto.ToString();
                    row.Cells["valorestado"].Value = ((OpcionesComboBox)cbestado.SelectedItem).Valor.ToString();
                    row.Cells["estado"].Value = ((OpcionesComboBox)cbestado.SelectedItem).Texto.ToString();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
                btnAgregar.Text = "    Agregar";
                txtddocumento.Enabled = true;
            }
        }

        private void btnbuscarlista_Click(object sender, EventArgs e)
        {
            String columnaFiltro = ((OpcionesComboBox)listabuscar.SelectedItem).Valor.ToString();
            if (tablausuarios.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablausuarios.Rows)
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
            foreach (DataGridViewRow row in tablausuarios.Rows)
            {
                row.Visible = true;
            }
            txtbuscar.Select();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtid.Text) != 0)
            {
                if(MessageBox.Show("¿Esta seguro de eliminar al usuario?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Usuarios objusuarios = new Usuarios()
                    {
                        idusuario = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new NUsuarios().Eliminar(objusuarios, out mensaje);
                    if (respuesta)
                    {
                        tablausuarios.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                    } else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

    }
}
