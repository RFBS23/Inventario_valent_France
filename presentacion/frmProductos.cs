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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            lblfecha.Text = $"{fechaActual.Year}-{fechaActual.Month}-{fechaActual.Day}";

            List<Categoria> listacat = new NCategoria().ListarCategorias();
            cbcategoria.Items.Add(new OpcionesComboBox() { Valor = 0, Texto = "Elija una categoria" });
            foreach (Categoria item in listacat)
            {
                cbcategoria.Items.Add(new OpcionesComboBox() { Valor = item.idcategoria, Texto = item.nombrecategoria });
            }
            cbcategoria.DisplayMember = "Texto";
            cbcategoria.ValueMember = "Valor";
            cbcategoria.SelectedIndex = 0;

            List<Marcas> listamarca = new NMarca().FiltrosMarcas();
            cbmarca.Items.Add(new OpcionesComboBox() { Valor = 0, Texto = "Elija una marca" });
            foreach (Marcas item in listamarca)
            {
                cbmarca.Items.Add(new OpcionesComboBox() { Valor = item.idmarca, Texto = item.nombremarca });
            }
            cbmarca.DisplayMember = "Texto";
            cbmarca.ValueMember = "Valor";
            cbmarca.SelectedIndex = 0;

            List<Tallas> listatalla = new NTallas().FiltrosTallas();
            cbtallas.Items.Add(new OpcionesComboBox() { Valor = 0, Texto = "Seleccione la talla" });
            foreach (Tallas item in listatalla)
            {
                cbtallas.Items.Add(new OpcionesComboBox() { Valor = item.idtallaropa, Texto = item.nombretalla });
            }
            cbtallas.DisplayMember = "Texto";
            cbtallas.ValueMember = "Valor";
            cbtallas.SelectedIndex = 0;

        }
    }
}
