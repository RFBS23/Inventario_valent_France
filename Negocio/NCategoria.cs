using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NCategoria
    {
        private DCategoria objd_categoria = new DCategoria();

        public List<Categoria> Listar()
        {
            return objd_categoria.Listar();
        }

        public int Registrar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.nombrecategoria == "")
            {
                Mensaje += "Es necesario que ingrese un nombre a la categoria bro \n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objd_categoria.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Categoria obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.nombrecategoria == "")
            {
                Mensaje += "Es necesario que cambie la descripcion de la categoria \n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objd_categoria.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(Categoria obj, out string Mensaje)
        {
            return objd_categoria.Eliminar(obj, out Mensaje);
        }

    }
}
