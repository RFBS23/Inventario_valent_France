﻿using Datos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NProveedores
    {
        private DProveedores objd_proveedor = new DProveedores();

        public List<Proveedor> Listar()
        {
            return objd_proveedor.Listar();
        }

        public int Registrar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.nombreproveedor == "")
            {
                Mensaje += "Es necesario que ingrese el nombre del proveedor \n";
            }
            if (obj.documento == "")
            {
                Mensaje += "Es necesario que ingrese el documento del proveedor \n";
            }
            if (obj.direccion == "")
            {
                Mensaje += "• Ingrese el la razon social \n";
            }
            if (obj.correo == "")
            {
                Mensaje += "• Ingrese un correo \n";
            }
            if (obj.telefono == "")
            {
                Mensaje += "• Ingrese un telefono \n";
            }
            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objd_proveedor.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            if (obj.nombreproveedor == "")
            {
                Mensaje += "Es necesario que ingrese el nombre del proveedor \n";
            }
            if (obj.documento == "")
            {
                Mensaje += "Es necesario que ingrese el documento del proveedor \n";
            }
            if (obj.direccion == "")
            {
                Mensaje += "• Ingrese el la razon social \n";
            }
            if (obj.correo == "")
            {
                Mensaje += "• Ingrese un correo \n";
            }
            if (obj.telefono == "")
            {
                Mensaje += "• Ingrese un telefono \n";
            }
            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objd_proveedor.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(Proveedor obj, out string Mensaje)
        {
            return objd_proveedor.Eliminar(obj, out Mensaje);
        }
    }
}
