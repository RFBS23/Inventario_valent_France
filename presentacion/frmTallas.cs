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
    public partial class frmTallas : Form
    {
        public frmTallas()
        {
            InitializeComponent();
        }

        private void frmTallas_Load(object sender, EventArgs e)
        {
            cbcategoria.Items.Clear();

            DateTime fechaActual = DateTime.Now;
            lblfecha.Text = $"{fechaActual.Year}-{fechaActual.Month}-{fechaActual.Day}";
            lblfechamodificada.Text = $"{fechaActual.Year}-{fechaActual.Month}-{fechaActual.Day}";

            List<Categoria> listacat = new NCategoria().ListarCategorias();
            cbcategoria.Items.Add(new OpcionesComboBox() { Valor = 0, Texto = "Elija una categoria" });
            foreach (Categoria item in listacat)
            {
                cbcategoria.Items.Add(new OpcionesComboBox() { Valor = item.idcategoria, Texto = item.nombrecategoria });
            }
            cbcategoria.DisplayMember = "Texto";
            cbcategoria.ValueMember = "Valor";
            cbcategoria.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in tablatallas.Columns)
            {
                if (columna.Visible == true)
                {
                    listabuscar.Items.Add(new OpcionesComboBox() { Valor = columna.Name, Texto = columna.HeaderText });
                }
                listabuscar.DisplayMember = "Texto";
                listabuscar.ValueMember = "Valor";
                listabuscar.SelectedIndex = 0;
            }

            List<Tallas> listaropa = new NTallas().Listar();
            foreach (Tallas item in listaropa)
            {
                tablatallas.Rows.Add(new object[] { "", item.idtallaropa, item.oCategorias.idcategoria, item.oCategorias.nombrecategoria, item.nombretalla, item.fecharegistro, item.fechamodificado });
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Tallas objropa = new Tallas()
            {
                idtallaropa = Convert.ToInt32(txtid.Text),
                nombretalla = txtnombretalla.Text,
                oCategorias = new Categoria() { idcategoria = Convert.ToInt32(((OpcionesComboBox)cbcategoria.SelectedItem).Valor) },

            };
            if (objropa.idtallaropa == 0 | btnAgregar.Text == "    Agregar")
            {
                int idtallaropagenerado = new NTallas().Registrar(objropa, out mensaje);

                if (idtallaropagenerado != 0)
                {
                    tablatallas.Rows.Add(new object[] { "", idtallaropagenerado,
                        ((OpcionesComboBox)cbcategoria.SelectedItem).Valor.ToString(),
                        ((OpcionesComboBox)cbcategoria.SelectedItem).Texto.ToString(),
                        txtnombretalla.Text,
                        lblfecha.Text,
                        lblfechamodificada.Text });
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
            else if (btnAgregar.Text == "    Editar")
            {
                bool resultado = new NTallas().Editar(objropa, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = tablatallas.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["idtallaropa"].Value = txtid.Text;
                    row.Cells["idcategoria"].Value = ((OpcionesComboBox)cbcategoria.SelectedItem).Valor.ToString();
                    row.Cells["nombrecategoria"].Value = ((OpcionesComboBox)cbcategoria.SelectedItem).Texto.ToString();
                    row.Cells["nombretalla"].Value = txtnombretalla.Text;
                    row.Cells["fechamodificacion"].Value = lblfechamodificada.Text;
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
                if (MessageBox.Show("¿Desea eliminar la talla?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string mensaje = string.Empty;
                    Tallas objtallas = new Tallas()
                    {
                        idtallaropa = Convert.ToInt32(txtid.Text)
                    };

                    bool respuesta = new NTallas().Eliminar(objtallas, out mensaje);

                    if (respuesta)
                    {
                        tablatallas.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
            Limpiar();
        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";

            txtnombretalla.Text = "";
            cbcategoria.SelectedIndex = 0;
            cbcategoria.Select();
        }


        private void tablatallas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablatallas.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = tablatallas.Rows[indice].Cells["idtallaropa"].Value.ToString();
                    foreach (OpcionesComboBox ocb in cbcategoria.Items)
                    {
                        if (Convert.ToInt32(ocb.Valor) == Convert.ToInt32(tablatallas.Rows[indice].Cells["idcategoria"].Value))
                        {
                            int indice_combo = cbcategoria.Items.IndexOf(ocb);
                            cbcategoria.SelectedIndex = indice_combo;
                            break;
                        }
                    }

                    txtnombretalla.Text = tablatallas.Rows[indice].Cells["nombretalla"].Value.ToString();   
                    btnAgregar.Text = "    Editar";
                }
            }
        }

        private void tablatallas_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void txtnombretalla_TextChanged(object sender, EventArgs e)
        {
            int selectionStart = txtnombretalla.SelectionStart;
            int selectionLength = txtnombretalla.SelectionLength;
            txtnombretalla.Text = txtnombretalla.Text.ToUpper();
            txtnombretalla.SelectionStart = selectionStart;
            txtnombretalla.SelectionLength = selectionLength;
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            int selectionStart = txtbuscar.SelectionStart;
            int selectionLength = txtbuscar.SelectionLength;
            txtbuscar.Text = txtbuscar.Text.ToUpper();
            txtbuscar.SelectionStart = selectionStart;
            txtbuscar.SelectionLength = selectionLength;
        }

        private void btnbuscarlista_Click(object sender, EventArgs e)
        {
            String columnaFiltro = ((OpcionesComboBox)listabuscar.SelectedItem).Valor.ToString();
            if (tablatallas.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablatallas.Rows)
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
            foreach (DataGridViewRow row in tablatallas.Rows)
            {
                row.Visible = true;
            }
            txtbuscar.Select();
        }
    }
}
