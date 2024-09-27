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
    public class DTienda
    {
        public List<Productos_tienda> Listar()
        {
            List<Productos_tienda> lista = new List<Productos_tienda>();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select idproductotienda, codigo, nombre, descripcion, c.idcategoria, c.nombrecategoria, tr.idtallaropa, tr.nombretalla, m.idmarca, m.nombremarca, stock, colores, precioventa, preciocompra, temporada, promo2x1, descuento, total,  CONVERT(VARCHAR(10), p.fecharegistro, 120)AS fecharegistro_producto from productos_tienda p");
                    query.AppendLine("inner join categorias c on c.idcategoria = p.idcategoria");
                    query.AppendLine("inner join tallasropa tr on tr.idtallaropa = p.idtallaropa");
                    query.AppendLine("inner join marca m on m.idmarca = p.idmarca");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Productos_tienda()
                            {
                                idproductotienda = Convert.ToInt32(dr["idproductotienda"]),
                                codigo = dr["codigo"].ToString(),
                                nombre = dr["nombre"].ToString(),
                                descripcion = dr["descripcion"].ToString(),
                                oCategorias = new Categoria() { idcategoria = Convert.ToInt32(dr["idcategoria"]), nombrecategoria = dr["nombrecategoria"].ToString() },
                                oTallasropa = new Tallas() { idtallaropa = Convert.ToInt32(dr["idtallaropa"]), nombretalla = dr["nombretalla"].ToString() },
                                oMarcas = new Marcas() { idmarca = Convert.ToInt32(dr["idmarca"]), nombremarca = dr["nombremarca"].ToString() },
                                colores = dr["colores"].ToString(),
                                stock = Convert.ToInt32(dr["stock"]),
                                precioventa = Convert.ToDecimal(dr["precioventa"]),
                                preciocompra = Convert.ToDecimal(dr["preciocompra"]),
                                temporada = dr["temporada"].ToString(),
                                promo2x1 = Convert.ToBoolean(dr["promo2x1"]),
                                descuento = Convert.ToInt32(dr["descuento"]),
                                total = Convert.ToDecimal(dr["total"]),
                                fecharegistro = dr["fecharegistro_producto"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<Productos_tienda>();
                }
            }
            return lista;
        }

        public bool Editar(Productos_tienda obj, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("spu_editar_productotienda", oconexion);
                    cmd.Parameters.AddWithValue("idproductotienda", obj.idproductotienda);
                    cmd.Parameters.AddWithValue("descuento", obj.descuento);
                    cmd.Parameters.AddWithValue("promo2x1", obj.promo2x1);  // Asegúrate de que aquí se envíe un booleano

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }

    }
}
