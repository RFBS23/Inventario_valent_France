using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DReportes
    {
        public List<ReporteVentas> Ventas(string fechainicio, string fechafin)
        {
            List<ReporteVentas> lista = new List<ReporteVentas>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    SqlCommand cmd = new SqlCommand("spu_reporte_venta", oconexion);
                    cmd.Parameters.AddWithValue("fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("fechafin", fechafin);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteVentas()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                tipodocumento = dr["tipodocumento"].ToString(),
                                numerodocumento = dr["numerodocumento"].ToString(),
                                montototal = dr["montototal"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                documentocliente = dr["documentocliente"].ToString(),
                                nombrecliente = dr["nombrecliente"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Descuento = dr["Descuento"].ToString(),
                                Tallas = dr["Tallas"].ToString(),  // Corregido aquí
                                Categoria = dr["Categoria"].ToString(),
                                precioventa = dr["precioventa"].ToString(),
                                cantidad = dr["cantidad"].ToString(),
                                subtotal = dr["subtotal"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<ReporteVentas>();
                }
            }
            return lista;
        }

        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int idproveedor)
        {
            List<ReporteCompra> lista = new List<ReporteCompra>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spu_reporte_compras", oconexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Añadir parámetros
                    cmd.Parameters.Add(new SqlParameter("@fechainicio", SqlDbType.VarChar) { Value = fechainicio });
                    cmd.Parameters.Add(new SqlParameter("@fechafin", SqlDbType.VarChar) { Value = fechafin });
                    cmd.Parameters.Add(new SqlParameter("@idproveedor", SqlDbType.Int) { Value = idproveedor });

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new ReporteCompra()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                tipodocumento = dr["tipodocumento"].ToString(),
                                numerodocumento = dr["numerodocumento"].ToString(),
                                montototal = dr["montototal"].ToString(),
                                UsuarioRegistro = dr["UsuarioRegistro"].ToString(),
                                documento = dr["docproveedor"].ToString(),
                                nombreproveedor = dr["razonsocial"].ToString(),
                                CodigoProducto = dr["CodigoProducto"].ToString(),
                                NombreProducto = dr["NombreProducto"].ToString(),
                                Tallas = dr["Tallas"].ToString(), 
                                Categoria = dr["Categoria"].ToString(),
                                preciocompra = dr["preciocompra"].ToString(),
                                precioventa = dr["precioventa"].ToString(),
                                cantidad = dr["cantidad"].ToString(),
                                subtotal = dr["subtotal"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Log or handle the exception
                    Console.WriteLine($"Error: {ex.Message}");
                    lista = new List<ReporteCompra>(); // Reset the list on error
                }
            }
            return lista;
        }
    }
}
