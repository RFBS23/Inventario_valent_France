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
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            lblfecha.Text = $"{fechaActual.Day}/{fechaActual.Month}/{fechaActual.Year}";

            foreach (DataGridViewColumn columna in tablacategorias.Columns)
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

            List<Categoria> listaUsuario = new NCategoria().Listar();
            foreach (Categoria item in listaUsuario)
            {
                tablacategorias.Rows.Add(new object[] { "", item.idcategoria, item.nombrecategoria, item.estado == true ? 1 : 0, item.estado == true ? "Activo" : "Inactivo", item.fecharegistro });
            }
        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";

            txtnombrecategoria.Text = "";
            cbestado.SelectedIndex = 0;

            txtnombrecategoria.Select();
        }

        private void tablacategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablacategorias.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = tablacategorias.Rows[indice].Cells["idcategoria"].Value.ToString();
                    txtnombrecategoria.Text = tablacategorias.Rows[indice].Cells["nombrecategoria"].Value.ToString();

                    foreach (OpcionesComboBox oc in cbestado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(tablacategorias.Rows[indice].Cells["valorestado"].Value))
                        {
                            int indice_combo = cbestado.Items.IndexOf(oc);
                            cbestado.SelectedIndex = indice_combo;
                            break;
                        }
                    }
                    lblfecha.Text = tablacategorias.Rows[indice].Cells["fecharegistro"].Value.ToString();
                    btnAgregar.Text = "    Editar";
                }
            }
        }

        private void tablacategorias_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
            Categoria objcategorias = new Categoria()
            {
                idcategoria = Convert.ToInt32(txtid.Text),
                nombrecategoria = txtnombrecategoria.Text,
                estado = Convert.ToInt32(((OpcionesComboBox)cbestado.SelectedItem).Valor) == 1 ? true : false,
                fecharegistro = lblfecha.Text
            };
            if (btnAgregar.Text == "    Agregar")
            {
                int idusuariogenerado = new NCategoria().Registrar(objcategorias, out mensaje);
                if (idusuariogenerado != 0)
                {
                    tablacategorias.Rows.Add(new object[] {"", idusuariogenerado, txtnombrecategoria.Text,
                        ((OpcionesComboBox)cbestado.SelectedItem).Valor.ToString(),
                        ((OpcionesComboBox)cbestado.SelectedItem).Texto.ToString(),
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
                bool resultado = new NCategoria().Editar(objcategorias, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = tablacategorias.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["idcategoria"].Value = Convert.ToInt32(txtid.Text);
                    row.Cells["nombrecategoria"].Value = txtnombrecategoria.Text;
                    row.Cells["valorestado"].Value = ((OpcionesComboBox)cbestado.SelectedItem).Valor.ToString();
                    row.Cells["estado"].Value = ((OpcionesComboBox)cbestado.SelectedItem).Texto.ToString();
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
                if (MessageBox.Show("¿ESTA SEGURO DE ELIMINAR A ESTA CATEGORIA?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    Categoria objcategoria = new Categoria()
                    {
                        idcategoria = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new NCategoria().Eliminar(objcategoria, out mensaje);
                    if (respuesta)
                    {
                        tablacategorias.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                Limpiar();
            }
        }

        private void btnbuscarlista_Click(object sender, EventArgs e)
        {
            String columnaFiltro = ((OpcionesComboBox)listabuscar.SelectedItem).Valor.ToString();
            if (tablacategorias.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablacategorias.Rows)
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
            foreach (DataGridViewRow row in tablacategorias.Rows)
            {
                row.Visible = true;
            }
            txtbuscar.Select();
        }



    }
}
