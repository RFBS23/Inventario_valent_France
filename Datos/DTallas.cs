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
    public class DTallas
    {
        public List<Tallas> ListarTallas()
        {
            List<Tallas> lista = new List<Tallas>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select idtallaropa, c.idcategoria, c.nombrecategoria, nombretalla, tr.estado, CONVERT(VARCHAR(10), tr.fecharegistro, 120)AS fecharegistro_tallas, CONVERT(VARCHAR(10), tr.fechamodificado, 120)AS fechamodificada_tallas from tallasropa tr");
                    query.AppendLine("inner join categorias c on c.idcategoria = tr.idcategoria");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Tallas()
                            {
                                idtallaropa = Convert.ToInt32(dr["idtallaropa"]),
                                nombretalla = dr["nombretalla"].ToString(),
                                estado = Convert.ToBoolean(dr["estado"]),
                                oCategorias = new Categoria() { idcategoria = Convert.ToInt32(dr["idcategoria"]), nombrecategoria = dr["nombrecategoria"].ToString() },
                                fecharegistro = dr["fecharegistro_tallas"].ToString(),
                                fechamodificado = dr["fechamodificada_tallas"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Tallas>();
                }
            }
            return lista;
        }

        public int Registrar(Tallas obj, out string Mensaje)
        {
            int idtallaropagenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("spu_registrar_tallasropa", oconexion);
                    cmd.Parameters.AddWithValue("nombretalla", obj.nombretalla);
                    cmd.Parameters.AddWithValue("idcategoria", obj.oCategorias.idcategoria);
                    cmd.Parameters.Add("resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idtallaropagenerado = Convert.ToInt32(cmd.Parameters["resultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idtallaropagenerado = 0;
                Mensaje = ex.Message;
            }
            return idtallaropagenerado;
        }

        public bool Editar(Tallas obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("spu_editar_tallasropa", oconexion);
                    cmd.Parameters.AddWithValue("idcategoria", obj.oCategorias.idcategoria);
                    cmd.Parameters.AddWithValue("idtallaropa", obj.idtallaropa);
                    cmd.Parameters.AddWithValue("nombretalla", obj.nombretalla);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }

        public bool Eliminar(Tallas obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("spu_eliminar_tallasropa", oconexion);
                    cmd.Parameters.AddWithValue("idtallaropa", obj.idtallaropa);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["resultado"].Value);
                    Mensaje = cmd.Parameters["mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }

        public List<Tallas> FiltrosTallas()
        {
            List<Tallas> lista = new List<Tallas>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("WITH TallasUnicas AS (SELECT idtallaropa, c.idcategoria, c.nombrecategoria, nombretalla, tr.estado, CONVERT(VARCHAR(10), tr.fecharegistro, 120) AS fecharegistro_tallas, CONVERT(VARCHAR(10), tr.fechamodificado, 120) AS fechamodificada_tallas, ROW_NUMBER() OVER (PARTITION BY nombretalla ORDER BY tr.idtallaropa) AS rn FROM tallasropa tr INNER JOIN categorias c ON c.idcategoria = tr.idcategoria WHERE tr.estado = 1 )");
                    query.AppendLine("SELECT idtallaropa, idcategoria, nombrecategoria, nombretalla, estado, fecharegistro_tallas, fechamodificada_tallas FROM TallasUnicas WHERE rn = 1;");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;
                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Tallas()
                            {
                                idtallaropa = Convert.ToInt32(dr["idtallaropa"]),
                                nombretalla = dr["nombretalla"].ToString(),
                                estado = Convert.ToBoolean(dr["estado"]),
                                oCategorias = new Categoria() { idcategoria = Convert.ToInt32(dr["idcategoria"]), nombrecategoria = dr["nombrecategoria"].ToString() },
                                fecharegistro = dr["fecharegistro_tallas"].ToString(),
                                fechamodificado = dr["fechamodificada_tallas"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Tallas>();
                }
            }
            return lista;
        }
    }
}
