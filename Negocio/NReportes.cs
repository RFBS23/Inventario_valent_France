using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NReportes
    {
        private DReportes objd_reporte = new DReportes();

        public List<ReporteVentas> Ventas(string fechainicio, string fechafin)
        {
            return objd_reporte.Ventas(fechainicio, fechafin);
        }
    }
}
