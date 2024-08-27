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

            foreach (DataGridViewColumn columna in tablareportes.Columns)
            {
                listabuscar.Items.Add(new OpcionesComboBox() { Valor = columna.Name, Texto = columna.HeaderText });
            }
            listabuscar.DisplayMember = "Texto";
            listabuscar.ValueMember = "Valor";
            listabuscar.SelectedIndex = 0;

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            
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
                            row.Cells[12].Value.ToString()
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
    }
}
