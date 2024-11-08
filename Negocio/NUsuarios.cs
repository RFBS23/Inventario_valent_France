using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NUsuarios
    {
        private DUsuarios obj_usuario = new DUsuarios();
        public List<Usuarios> IniciarSesion()
        {
            return obj_usuario.IniciarSesion();
        }

        public List<Usuarios> Listar()
        {
            return obj_usuario.Listar();
        }

        public int Registrar(Usuarios obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.documento == "")
            {
                Mensaje += "Es necesario el numero de documento \n";
            }
            if (obj.nombres == "")
            {
                Mensaje += "Ingrese su nombre";
            }
            if (obj.apellidos == "")
            {
                Mensaje += "Ingrese su apellidos";
            }
            if (obj.nombreusuario == "")
            {
                Mensaje += "Es necesario el nombre completo del usuario \n";
            }
            if (obj.clave == "")
            {
                Mensaje += "Es necesario la clave del usuario \n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return obj_usuario.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Usuarios obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.documento == "")
            {
                Mensaje += "Es necesario el documento de identificacion del usuario\n";
            }
            if (obj.nombres == "")
            {
                Mensaje += "Ingrese su nombre";
            }
            if (obj.apellidos == "")
            {
                Mensaje += "Ingrese su apellidos";
            }
            if (obj.nombreusuario == "")
            {
                Mensaje += "Es necesario el nombre completo del usuario\n";
            }
            if (obj.clave == "")
            {
                Mensaje += "Es necesario la clave del usuario\n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return obj_usuario.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(Usuarios obj, out string Mensaje)
        {
            return obj_usuario.Eliminar(obj, out Mensaje);
        }

        public int CantidadUsuarios()
        {
            return obj_usuario.CantidadUsuarios();
        }

    }
}
