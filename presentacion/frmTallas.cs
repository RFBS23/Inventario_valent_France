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
            lblfecha.Text = $"{fechaActual.Day}/{fechaActual.Month}/{fechaActual.Year}";

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

            cbestado.Items.Add(new OpcionesComboBox() { Valor = 1, Texto = "Activo" });
            cbestado.Items.Add(new OpcionesComboBox() { Valor = 0, Texto = "Inactivo" });
            cbestado.DisplayMember = "Texto";
            cbestado.ValueMember = "Valor";
            cbestado.SelectedIndex = 0;

            List<Tallas> listaropa = new NTallas().Listar();
            foreach (Tallas item in listaropa)
            {
                tablatallas.Rows.Add(new object[] { "", item.idtallaropa, item.oCategorias.idcategoria, item.oCategorias.nombrecategoria, item.nombretalla, item.estado == true ? 1 : 0, item.estado == true ? "Activo" : "Inactivo", item.fecharegistro, item.fechamodificado });
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";

            txtnombretalla.Text = "";
            cbestado.SelectedIndex = 0;
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
                    foreach (OpcionesComboBox oc in cbestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(tablatallas.Rows[indice].Cells["valorestado"].Value))
                        {
                            int indice_combo = cbestado.Items.IndexOf(oc);
                            cbestado.SelectedIndex = indice_combo;
                            break;
                        }
                    }                    
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
    }
}
