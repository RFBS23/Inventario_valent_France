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
    }
}
