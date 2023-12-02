using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce
{
    public static class Seguridad
    {
        public static bool EsAdmin(object obj)
        {
            bool response = false;

            if (VerificarSesion(obj))
            {
                Usuario art = obj as Usuario;
                if (art.IsAdmin)
                    response = true;
                else
                    response = false;
            }

            return response;
        }
        public static bool VerificarSesion(object obj)
        {
            if (obj == null)
                return false;
            else
                return true;
        }

        public static string ManejarExcepcion(Exception ex)
        {
            return ex.Message;
        }
    }
}