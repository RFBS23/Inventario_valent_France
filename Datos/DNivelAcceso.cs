using Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DNivelAcceso
    {
        public List<NivelAcceso> Listar()
        {
            List<NivelAcceso> lista = new List<NivelAcceso>();
            using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select idnivelacceso, nombreacceso from nivelacceso");
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;
                    conexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new NivelAcceso()
                            {
                                idnivelacceso = Convert.ToInt32(dr["idnivelacceso"]),
                                nombreacceso = dr["nombreacceso"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<NivelAcceso>();
                }
            }
            return lista;
        }
    }
}
