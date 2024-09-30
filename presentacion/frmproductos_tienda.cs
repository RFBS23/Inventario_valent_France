using ClosedXML.Excel;
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
    public partial class frmproductos_tienda : Form
    {
        public frmproductos_tienda()
        {
            InitializeComponent();
        }

        public void Alert(string msg, Form_Alert.enmType type)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg, type);
        }
        private void frmproductos_tienda_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in tablaproductostienda.Columns)
            {
                if (columna.Visible == true)
                {
                    listabuscar.Items.Add(new OpcionesComboBox() { Valor = columna.Name, Texto = columna.HeaderText });
                }

                listabuscar.DisplayMember = "Texto";
                listabuscar.ValueMember = "Valor";
                listabuscar.SelectedIndex = 0;
            }

            List<Productos_tienda> listaProductos = new NTienda().Listar();
            foreach (Productos_tienda item in listaProductos)
            {
                tablaproductostienda.Rows.Add(new object[] { "", item.idproductotienda, item.codigo, item.nombre, item.descripcion, item.oCategorias.idcategoria, item.oCategorias.nombrecategoria, item.oTallasropa.idtallaropa, item.oTallasropa.nombretalla, item.oMarcas.idmarca, item.oMarcas.nombremarca, item.stock, item.colores, item.temporada, item.preciocompra, item.descuento, item.total, item.fecharegistro });
            }
        }

        private void tablaproductostienda_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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

        private void btnbuscarlista_Click(object sender, EventArgs e)
        {
            String columnaFiltro = ((OpcionesComboBox)listabuscar.SelectedItem).Valor.ToString();
            if (tablaproductostienda.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablaproductostienda.Rows)
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
            foreach (DataGridViewRow row in tablaproductostienda.Rows)
            {
                row.Visible = true;
            }
            txtbuscar.Select();
        }

        private void tablaproductostienda_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.tablaproductostienda.Columns[e.ColumnIndex].Name == "stock")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    int stockValue = Convert.ToInt32(e.Value);

                    // Stock mayor a 20
                    if (stockValue >= 20)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(129, 250, 123);
                        e.CellStyle.ForeColor = Color.Black;
                    }
                    // Stock menor o igual a 19
                    else if (stockValue <= 19)
                    {
                        e.CellStyle.BackColor = Color.Salmon;
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void btnexportarexcel_Click(object sender, EventArgs e)
        {
            if (tablaproductostienda.Rows.Count < 1)
            {
                MessageBox.Show("NO HE PODIDO ENCONTRAR DATOS PARA PODER EXPORTARLOS", "VALENT FRANCE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dtt = new DataTable();
                foreach (DataGridViewColumn columna in tablaproductostienda.Columns)
                {
                    if (columna.HeaderText != "" && columna.Visible)
                        dtt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in tablaproductostienda.Rows)
                {
                    if (row.Visible)
                        dtt.Rows.Add(new object[] {
                            row.Cells[0].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[10].Value.ToString(),
                            row.Cells[11].Value.ToString(),
                            row.Cells[12].Value.ToString(),
                            row.Cells[13].Value.ToString(),
                            row.Cells[14].Value.ToString(),
                            row.Cells[15].Value.ToString(),
                            row.Cells[16].Value.ToString(),
                            row.Cells[17].Value.ToString(),
                        });
                }
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteProducto_{0}.xlsx", DateTime.Now.ToString("dd-MM-yyyy"));
                savefile.Filter = "Excel Files | *.xlsx";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dtt, "Informe de productos en stock");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("REPORTE GENERADO EXITOSAMENTE", "VALENT FRANCE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Alert("Reporte Guardado", Form_Alert.enmType.Success);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Alert("Error al generar reporte", Form_Alert.enmType.Error);
                    }
                }
            }
        }
    }
}
