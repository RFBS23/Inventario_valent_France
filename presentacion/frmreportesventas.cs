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
    public partial class frmreportesventas : Form
    {
        public frmreportesventas()
        {
            InitializeComponent();
        }

        private void frmreportesventas_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in tablareportes.Columns)
            {
                if (columna.Visible == true)
                {
                    listabuscar.Items.Add(new OpcionesComboBox() { Valor = columna.Name, Texto = columna.HeaderText });
                }
                listabuscar.DisplayMember = "Texto";
                listabuscar.ValueMember = "Valor";
                listabuscar.SelectedIndex = 0;
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (dtfechainicio.Value > dtfechafin.Value)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha de fin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<ReporteVentas> lista = new List<ReporteVentas>();
            try
            {
                // Asegúrate de que las fechas estén en el formato correcto
                lista = new NReportes().Ventas(dtfechainicio.Value.ToString("dd-MM-yyyy"), dtfechafin.Value.ToString("dd-MM-yyyy"));

                MessageBox.Show($"Se encontraron {lista.Count} registros."); // Debugging line

                tablareportes.Rows.Clear();
                foreach (ReporteVentas rv in lista)
                {
                    tablareportes.Rows.Add(new object[]
                    {
                        rv.FechaRegistro,
                        rv.tipodocumento,
                        rv.numerodocumento,
                        rv.UsuarioRegistro,
                        rv.documentocliente,
                        rv.nombrecliente,
                        rv.CodigoProducto,
                        rv.NombreProducto,
                        rv.Colores,
                        rv.Tallas,
                        rv.Categoria,
                        rv.precioventa,
                        rv.cantidad,
                        rv.Descuento,
                        rv.subtotal,
                        rv.montototal,
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnbuscarlista_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionesComboBox)listabuscar.SelectedItem).Valor.ToString();

            if (tablareportes.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in tablareportes.Rows)
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
            if (tablareportes.Rows.Count < 1)
            {
                MessageBox.Show("No hay registros para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in tablareportes.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }
                foreach (DataGridViewRow row in tablareportes.Rows)
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
                            row.Cells[14].Value.ToString(),
                            row.Cells[15].Value.ToString()
                        });
                }
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("ReporteVentas_{0}.xlsx", DateTime.Now.ToString("dd-MM-yyyy"));
                savefile.Filter = "Excel Files | *.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe venta");
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

        private void btnlimpiarbuscador_Click(object sender, EventArgs e)
        {

        }
    }
}
