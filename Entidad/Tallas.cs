using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Tallas
    {
        public int idtallaropa { get; set; }
        public string nombretalla { get; set; }
        public Categoria oCategorias { get; set; }
        public bool estado { get; set; }
        public string fecharegistro { get; set; }
        public string fechamodificado { get; set; }
    }
}
