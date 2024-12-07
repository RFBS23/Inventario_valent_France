using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NNivelAcceso
    {
        private DNivelAcceso obj_nivelacceso = new DNivelAcceso();
        public List<NivelAcceso> listar()
        {
            return obj_nivelacceso.Listar();
        }

        public int Registrar(NivelAcceso obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.nombreacceso) || string.IsNullOrWhiteSpace(obj.nombreacceso))
            {
                Mensaje = "Debes colocar un nivel de acceso";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return obj_nivelacceso.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(NivelAcceso obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.nombreacceso) || string.IsNullOrWhiteSpace(obj.nombreacceso))
            {
                Mensaje = "Debes colocar un nivel de acceso";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return obj_nivelacceso.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(NivelAcceso obj, out string Mensaje)
        {
            return obj_nivelacceso.Eliminar(obj, out Mensaje);
        }

    }
}
