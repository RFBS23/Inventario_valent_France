using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NTallas
    {
        private DTallas objd_tallaropa = new DTallas();

        public List<Tallas> Listar()
        {
            return objd_tallaropa.ListarTallas();
        }

        public int Registrar(Tallas obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.nombretalla == "")
            {
                Mensaje += "Es necesario que ingrese una talla que no se repita \n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objd_tallaropa.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Tallas obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.nombretalla == "")
            {
                Mensaje += "Es necesario que cambie el nombre de la talla \n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objd_tallaropa.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(Tallas obj, out string Mensaje)
        {
            return objd_tallaropa.Eliminar(obj, out Mensaje);
        }

        public List<Tallas> FiltrosTallas()
        {
            return objd_tallaropa.FiltrosTallas();
        }
    }
}
