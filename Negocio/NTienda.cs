using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NTienda
    {
        private DTienda objd_productotienda = new DTienda();

        public List<Productos_tienda> Listar()
        {
            return objd_productotienda.Listar();
        }        
    }
}
