using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Ncompras
    {
        private DCompras objcd_compras = new DCompras();

        public int obtenercorrelativo()
        {
            return objcd_compras.ObtenerCorrelativo();
        }

        public bool registrar(Compra obj, DataTable detallecompra, out string Mensaje)
        {
            return objcd_compras.Registrar(obj, detallecompra, out Mensaje);
        }

        public Compra ObtenerCompra(string numero)
        {
            Compra oCompra = objcd_compras.ObtenerCompra(numero);
            if (oCompra.idcompra != 0)
            {
                List<Detalle_compra> oDetalleCompra = objcd_compras.ObtenerDetallesCompra(oCompra.idcompra);
                oCompra.oDetallescompra = oDetalleCompra;
            }
            return oCompra;
        }

    }
}
