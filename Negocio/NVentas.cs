using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NVentas
    {
        private DVentas objcd_venta = new DVentas();

        public int obtenercorrelativo()
        {
            return objcd_venta.obtenercorrelativo();
        }

        public bool RestarStock(int idproducto, int cantidad)
        {
            return objcd_venta.RestarStock(idproducto, cantidad);
        }

        public bool SumarStock(int idproducto, int cantidad)
        {
            return objcd_venta.SumarStock(idproducto, cantidad);
        }

        public bool registrar(Ventas obj, DataTable detalleventa, out string Mensaje)
        {
            return objcd_venta.registrar(obj, detalleventa, out Mensaje);
        }

        public Ventas ObtenerVentas(string numero)
        {
            Ventas oVenta = objcd_venta.ObtenerVenta(numero);
            if (oVenta.idventa != 0)
            {
                List<DetallesVentas> oDetalleVentas = objcd_venta.ObtenerDetallesVenta(oVenta.idventa);
                oVenta.oDetalle_Venta = oDetalleVentas;
            }
            return oVenta;
        }

        public int CantidadVentas()
        {
            int cantidadVentas = 0;
            using (SqlConnection connection = new SqlConnection(Conexion.cadena))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from ventas", connection);
                cantidadVentas = (int)cmd.ExecuteScalar();
            }
            return cantidadVentas;
        }
    }
}
