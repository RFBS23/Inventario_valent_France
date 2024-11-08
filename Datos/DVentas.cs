using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DVentas
    {
        public int obtenercorrelativo()
        {
            int idcorrelativo = 0;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from ventas");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    idcorrelativo = 0;
                }
            }
            return idcorrelativo;
        }

        public bool RestarStock(int idproductotienda, int cantidad)
        {
            bool respuesta = true;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE productos_tienda SET stock = stock - @cantidad WHERE idproductotienda = @idproductotienda");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproductotienda", idproductotienda);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }


        public bool SumarStock(int idproductotienda, int cantidad)
        {
            bool respuesta = true;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE productos_tienda SET stock = stock + @cantidad WHERE idproductotienda = @idproductotienda");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@idproductotienda", idproductotienda);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();

                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public bool registrar(Ventas obj, DataTable detalleventa, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("spu_registrar_venta", oconexion);
                    cmd.Parameters.AddWithValue("idusuario", obj.oUsuarios.idusuario);
                    cmd.Parameters.AddWithValue("tipodocumento", obj.tipodocumento);
                    cmd.Parameters.AddWithValue("numerodocumento", obj.numerodocumento);
                    cmd.Parameters.AddWithValue("documentocliente", obj.documentocliente);
                    cmd.Parameters.AddWithValue("nombrecliente", obj.nombrecliente);
                    cmd.Parameters.AddWithValue("montopago", obj.montopago);
                    cmd.Parameters.AddWithValue("montocambio", obj.montocambio);
                    cmd.Parameters.AddWithValue("montototal", obj.montototal);
                    cmd.Parameters.AddWithValue("detalleventa", detalleventa);

                    cmd.Parameters.Add("resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();

                    Respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }
            return Respuesta;
        }

        public Ventas ObtenerVenta(string numero)
        {
            Ventas obj = new Ventas();

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    oconexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select v.idventa, u.nombreusuario, v.documentocliente, v.nombrecliente, v.tipodocumento,");
                    query.AppendLine("v.numerodocumento, v.montopago, v.montocambio, v.montototal, convert(char(10), v.fecharegistro, 103)[FechaRegistro] from ventas v");
                    query.AppendLine("inner join usuarios u on u.idusuario = v.idusuario");
                    query.AppendLine("where v.numerodocumento = @numero");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Ventas()
                            {
                                idventa = int.Parse(dr["idventa"].ToString()),
                                oUsuarios = new Usuarios() { nombreusuario = dr["nombreusuario"].ToString() },
                                documentocliente = dr["documentocliente"].ToString(),
                                nombrecliente = dr["nombrecliente"].ToString(),
                                tipodocumento = dr["tipodocumento"].ToString(),
                                numerodocumento = dr["numerodocumento"].ToString(),
                                montopago = Convert.ToDecimal(dr["montopago"].ToString()),
                                montocambio = Convert.ToDecimal(dr["montocambio"].ToString()),
                                montototal = Convert.ToDecimal(dr["montototal"].ToString()),
                                fecharegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
                catch
                {
                    obj = new Ventas();
                }
            }
            return obj;
        }

        public List<DetallesVentas> ObtenerDetallesVenta(int idventa)
        {
            List<DetallesVentas> oLista = new List<DetallesVentas>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    oconexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.nombre + ' ' + p.descripcion + ' ' + p.colores + ' ' + tr.nombretalla as productos, p.descuento, dv.precioventa, dv.cantidad, dv.subtotal from detalle_venta dv");
                    query.AppendLine("inner join productos_tienda p on p.idproductotienda = dv.idproductotienda");
                    query.AppendLine("inner join tallasropa tr on tr.idtallaropa = p.idtallaropa");
                    query.AppendLine("where dv.idventa = @idventa");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idventa", idventa);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new DetallesVentas()
                            {
                                oProductos = new Productos() { nombre = dr["productos"].ToString(), descuento = Convert.ToInt32(dr["descuento"].ToString()) },
                                precioventa = Convert.ToDecimal(dr["precioventa"].ToString()),
                                cantidad = Convert.ToInt32(dr["cantidad"].ToString()),
                                subtotal = Convert.ToDecimal(dr["subtotal"].ToString())
                            });
                        }
                    }
                }
                catch
                {
                    oLista = new List<DetallesVentas>();
                }
            }
            return oLista;
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
