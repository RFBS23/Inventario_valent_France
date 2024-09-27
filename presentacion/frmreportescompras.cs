using ClosedXML.Excel;
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
    public partial class frmreportescompras : Form
    {
        public frmreportescompras()
        {
            InitializeComponent();
        }

        private void frmreportescompras_Load(object sender, EventArgs e)
        {
            List<Proveedor> lista = new NProveedores().Listar();

            cbproveedores.Items.Add(new OpcionesComboBox() { Valor = 0, Texto = "Todos" });
            foreach (Proveedor item in lista)
            {
                cbproveedores.Items.Add(new OpcionesComboBox() { Valor = item.idproveedor, Texto = item.nombreproveedor });
            }
            cbproveedores.DisplayMember = "Texto";
            cbproveedores.ValueMember = "Valor";
            cbproveedores.SelectedIndex = 0;

            foreach (DataGridViewColumn columna in tablareportescompra.Columns)
            {
                listabuscar.Items.Add(new OpcionesComboBox() { Valor = columna.Name, Texto = columna.HeaderText });
            }
            listabuscar.DisplayMember = "Texto";
            listabuscar.ValueMember = "Valor";
            listabuscar.SelectedIndex = 0;

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (dtfechainicio.Value > dtfechafin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idproveedor = Convert.ToInt32(((OpcionesComboBox)cbproveedores.SelectedItem).Valor.ToString());

            List<ReporteCompra> lista = new List<ReporteCompra>();
            lista = new NReportes().Compra(dtfechainicio.Value.ToString("dd-MM-yyyy"), dtfechafin.Value.ToString("dd-MM-yyyy"), idproveedor);

            tablareportescompra.Rows.Clear();

            foreach (ReporteCompra rc in lista)
            {
                tablareportescompra.Rows.Add(new object[]
                {
                    rc.FechaRegistro,
                    rc.tipodocumento,
                    rc.numerodocumento,
                    rc.UsuarioRegistro,
                    rc.documento,
                    rc.nombreproveedor,
                    rc.CodigoProducto,
                    rc.NombreProducto,
                    rc.Tallas,
                    rc.Categoria,
                    rc.preciocompra,
                    rc.cantidad,
                    rc.subtotal,
                    rc.montototal,
                });
            }

            MessageBox.Show($"Se encontraron {lista.Count} registros.");
        }

        private void btnbuscarlista_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionesComboBox)listabuscar.SelectedItem).Valor.ToString();

            if (tablareportescompra.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablareportescompra.Rows)
                {

                    if (row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbuscar.Text.Trim().ToUpper()))
                        row.Visible = true;
                    else
                        row.Visible = false;
                }
            }
        }

        private void btnexportarexcel_Click(object sender, EventArgs e)
        {
            if (tablareportescompra.Rows.Count < 1)
            {
                MessageBox.Show("No hay registros para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in tablareportescompra.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }
                foreach (DataGridViewRow row in tablareportescompra.Rows)
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[] {
                            row.Cells[0].Value.ToString(),
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[10].Value.ToString(),
                            row.Cells[11].Value.ToString(),
                            row.Cells[12].Value.ToString(),
                            row.Cells[13].Value.ToString(),
                        });
                }
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteCompras_{0}.xlsx", DateTime.Now.ToString("dd-MM-yyyy"));
                savefile.Filter = "Excel Files | *.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe compra");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                System.Diagnostics.Process.Start(savefile.FileName);
            }
        }
    }
}
