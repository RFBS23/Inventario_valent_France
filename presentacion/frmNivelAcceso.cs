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
    public partial class frmNivelAcceso : Form
    {
        public frmNivelAcceso()
        {
            InitializeComponent();
        }

        private void btnbuscarlista_Click(object sender, EventArgs e)
        {
            String columnaFiltro = ((OpcionesComboBox)listabuscar.SelectedItem).Valor.ToString();
            if (tablanvacceso.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablanvacceso.Rows)
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
            foreach (DataGridViewRow row in tablanvacceso.Rows)
            {
                row.Visible = true;
            }
            txtbuscar.Select();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            NivelAcceso objropa = new NivelAcceso()
            {
                idnivelacceso = Convert.ToInt32(txtid.Text),
                nombreacceso = txtnombreacceso.Text
            };
            if (objropa.idnivelacceso == 0 | btnAgregar.Text == "    Agregar")
            {
                int idtallaropagenerado = new NNivelAcceso().Registrar(objropa, out mensaje);

                if (idtallaropagenerado != 0)
                {
                    tablanvacceso.Rows.Add(new object[] { "", idtallaropagenerado,
                        txtnombreacceso.Text,
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
                bool resultado = new NNivelAcceso().Editar(objropa, out mensaje);
                if (resultado)
                {
                    DataGridViewRow row = tablanvacceso.Rows[Convert.ToInt32(txtindice.Text)];
                    row.Cells["idnivelacceso"].Value = txtid.Text;
                    row.Cells["nombreacceso"].Value = txtnombreacceso.Text;
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
                btnAgregar.Text = "    Agregar";
            }
        }

        private void frmNivelAcceso_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            lblfecha.Text = $"{fechaActual.Year}-{fechaActual.Month}-{fechaActual.Day}";

            foreach (DataGridViewColumn columna in tablanvacceso.Columns)
            {
                if (columna.Visible == true)
                {
                    listabuscar.Items.Add(new OpcionesComboBox() { Valor = columna.Name, Texto = columna.HeaderText });
                }
                listabuscar.DisplayMember = "Texto";
                listabuscar.ValueMember = "Valor";
                listabuscar.SelectedIndex = 0;
            }

            List<NivelAcceso> listaropa = new NNivelAcceso().listar();
            foreach (NivelAcceso item in listaropa)
            {
                tablanvacceso.Rows.Add(new object[] { "", item.idnivelacceso, item.nombreacceso, item.fecharegistro });
            }
        }

        private void Limpiar()
        {
            txtindice.Text = "-1";
            txtid.Text = "0";

            txtnombreacceso.Text = "";
            txtnombreacceso.Select();
        }

        private void tablanvacceso_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void tablanvacceso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tablanvacceso.Columns[e.ColumnIndex].Name == "btnseleccionar")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtindice.Text = indice.ToString();
                    txtid.Text = tablanvacceso.Rows[indice].Cells["idnivelacceso"].Value.ToString();
                    txtnombreacceso.Text = tablanvacceso.Rows[indice].Cells["nombreacceso"].Value.ToString();
                    btnAgregar.Text = "    Editar";
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtid.Text) != 0)
            {
                if (MessageBox.Show("¿ESTA SEGURO DE ELIMINAR A ESTE ACCESO?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;
                    NivelAcceso objcategoria = new NivelAcceso()
                    {
                        idnivelacceso = Convert.ToInt32(txtid.Text)
                    };
                    bool respuesta = new NNivelAcceso().Eliminar(objcategoria, out mensaje);
                    if (respuesta)
                    {
                        tablanvacceso.Rows.RemoveAt(Convert.ToInt32(txtindice.Text));
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                Limpiar();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
