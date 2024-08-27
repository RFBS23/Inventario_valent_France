using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCompras
    {
        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select count(*) + 1 from compra");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = System.Data.CommandType.Text;
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

        public bool Registrar(Compra obj, DataTable detallecompra, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;

            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spu_registrocompra", oconexion);
                    cmd.Parameters.AddWithValue("idusuario", obj.oUsuarios.idusuario);
                    cmd.Parameters.AddWithValue("idproveedor", obj.oProveedor.idproveedor);
                    cmd.Parameters.AddWithValue("tipodocumento", obj.tipodocumento);
                    cmd.Parameters.AddWithValue("numerodocumento", obj.numerodocumento);
                    cmd.Parameters.AddWithValue("montototal", obj.montototal);

                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("detallecompra", detallecompra);
                    tvpParam.SqlDbType = SqlDbType.Structured;

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    Respuesta = false;
                    Mensaje = ex.Message;
                }
            }
            return Respuesta;
        }

        public Compra ObtenerCompra(string numero)
        {
            Compra obj = new Compra();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT cp.idcompra, u.nombreusuario, p.documento, p.nombreproveedor, cp.tipodocumento, cp.numerodocumento, cp.montototal, CONVERT(CHAR(10), cp.fecharegistro, 103) AS [FechaRegistro] FROM compra cp");
                    query.AppendLine("INNER JOIN usuarios u ON u.idusuario = cp.idusuario");
                    query.AppendLine("INNER JOIN proveedores p ON p.idproveedor = cp.idproveedor");
                    query.AppendLine("WHERE cp.numerodocumento = @numero");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Compra()
                            {
                                idcompra = Convert.ToInt32(dr["idcompra"]),
                                oUsuarios = new Usuarios() { nombreusuario = dr["nombreusuario"].ToString() },
                                oProveedor = new Proveedor()
                                {
                                    documento = dr["documento"].ToString(),
                                    nombreproveedor = dr["nombreproveedor"].ToString()
                                },
                                tipodocumento = dr["tipodocumento"].ToString(),
                                numerodocumento = dr["numerodocumento"].ToString(),
                                montototal = Convert.ToDecimal(dr["montototal"].ToString()),
                                fecharegistro = dr["FechaRegistro"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    obj = new Compra();
                }
            }
            return obj;
        }

        public List<Detalle_compra> ObtenerDetallesCompra(int idcompra)
        {
            List<Detalle_compra> oLista = new List<Detalle_compra>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    oconexion.Open();
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select p.nombre + ' ' + p.descripcion + ' ' + p.colores + ' ' + tr.nombretalla as productos, dc.preciocompra, dc.cantidad, dc.montototal from detallecompra dc");
                    query.AppendLine("inner join productos p on p.idproducto = dc.idproducto");
                    query.AppendLine("inner join tallasropa tr on tr.idtallaropa = p.idtallaropa");
                    query.AppendLine("where dc.idcompra = @idcompra");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idcompra", idcompra);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Detalle_compra()
                            {
                                oProductos = new Productos() { nombre = dr["productos"].ToString() },
                                preciocompra = Convert.ToDecimal(dr["preciocompra"].ToString()),
                                cantidad = Convert.ToInt32(dr["cantidad"].ToString()),
                                montototal = Convert.ToDecimal(dr["montototal"].ToString())
                            });
                        }
                    }
                }
                catch
                {
                    oLista = new List<Detalle_compra>();
                }
            }
            return oLista;
        }

    }
}
