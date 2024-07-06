using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NNegocio
    {
        private DNegocio objd_negocios = new DNegocio();
        public Negocios ObtenerDatos()
        {
            return objd_negocios.ObtnerDatos();
        }

        public bool GuardarDatos(Negocios obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.nombre == "")
            {
                Mensaje += "Es necesario el nombre de la empresa \n";
            }
            if (obj.ruc == "")
            {
                Mensaje += "Es necesario el numero de RUC \n";
            }
            if (obj.direccion == "")
            {
                Mensaje += "Es necesario la direccion de la empresa \n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objd_negocios.GuardarDatos(obj, out Mensaje);
            }
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            return objd_negocios.obtenerLogo(out obtenido);
        }

        public bool ActualizarLogo(byte[] imagen, out string mensaje)
        {
            return objd_negocios.ActualizarLogo(imagen, out mensaje);
        }
    }
}
