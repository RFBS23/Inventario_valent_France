using DocumentFormat.OpenXml.Wordprocessing;
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

namespace presentacion.Modales
{
    public partial class frmmodProveedores : Form
    {
        public Proveedor _Proveedor { get; set; }
        public frmmodProveedores()
        {
            InitializeComponent();
        }

        private void frmmodProveedores_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in tablaproveedor.Columns)
            {
                if (columna.Visible == true)
                {
                    listabuscar.Items.Add(new OpcionesComboBox() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            listabuscar.DisplayMember = "Texto";
            listabuscar.ValueMember = "Valor";
            listabuscar.SelectedIndex = 0;

            List<Proveedor> listaProveedor = new NProveedores().Listar();
            foreach (Proveedor item in listaProveedor)
            {
                tablaproveedor.Rows.Add(new object[] { item.idproveedor, item.documento, item.nombreproveedor, item.fecharegistro });
            }
        }

        private void tablaproveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum > 0)
            {
                _Proveedor = new Proveedor()
                {
                    idproveedor = Convert.ToInt32(tablaproveedor.Rows[iRow].Cells["idproveedor"].Value.ToString()),
                    documento = tablaproveedor.Rows[iRow].Cells["documento"].Value.ToString(),
                    nombreproveedor = tablaproveedor.Rows[iRow].Cells["nombre"].Value.ToString()
                };
                this.DialogResult = DialogResult.OK;
                this.Close();
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
        }

    }
}
