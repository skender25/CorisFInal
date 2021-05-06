using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demosaba
{
    public class Estado
    {

        private static bool d_estado_session = false;
        private static DateTime d_fecha_i = DateTime.Parse("01-01-2021");
        private static DateTime d_fecha_f = DateTime.Parse("04-04-2021");
        private static string d_cia = "CVET";
        private static string d_error ;
        private static string d_error_w;
        private static string d_error_s;
        private static string d_enviado;
        private static string d_aceptado;
        private static bool d_filtros = true;
        public static bool estado_session
        {
            get { return d_estado_session; }
            set { d_estado_session = value; }
        }
        public static bool d_filtros_f
        {
            get { return d_filtros; }
            set { d_filtros = value; }
        }
        public static DateTime fecha_i
        {
            get { return d_fecha_i; }
            set { d_fecha_i = value; }
        }
        public static DateTime fecha_f
        {
            get { return d_fecha_f; }
            set { d_fecha_f = value; }
        }
        public static string d_cia_f
        {
            get { return d_cia; }
            set { d_cia = value; }
        }
        public static string error_f
        {
            get { return d_error; }
            set { d_error = value; }
        }
        public static string error_fw
        {
            get { return d_error_w; }
            set { d_error_w = value; }
        }
        public static string error_fs
        {
            get { return d_error_s; }
            set { d_error_s = value; }
        }
        public static string d_enviado_f
        {
            get { return d_enviado; }
            set { d_enviado = value; }
        }
        public static string d_aceptado_f
        {
            get { return d_aceptado; }
            set { d_aceptado = value; }
        }
    }
}