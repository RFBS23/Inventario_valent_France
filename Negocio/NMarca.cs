﻿using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NMarca
    {
        private DMarca objdatos = new DMarca();
        public List<Marcas> Listar()
        {
            return objdatos.Listar();
        }

        public int Registrar(Marcas obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.nombremarca) || string.IsNullOrWhiteSpace(obj.nombremarca))
            {
                Mensaje = "Debes colocar una categoria";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objdatos.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }

        public bool Editar(Marcas obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (string.IsNullOrEmpty(obj.nombremarca) || string.IsNullOrWhiteSpace(obj.nombremarca))
            {
                Mensaje = "Debes colocar una categoria";
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objdatos.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objdatos.Eliminar(id, out Mensaje);
        }

        public List<Marcas> FiltrosMarcas()
        {
            return objdatos.FiltrosMarca();
        }
    }
}
