using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demosaba.Models
{
    public class MVClass
    {
        public string DOCUMENTO { get; set; }
        public string CLIENTE { get; set; }
        public DateTime FECHA { get; set; }
        public string NOMBRE { get; set; }

        public string NIT_RECEPTOR { get; set; }

        public string CLAVE { get; set; }

        public string CODIGO_MONEDA { get; set; }

        public string TOTALGRAVADO { get; set; }

        public string TOTALEXENTO { get; set; }

        public string TOTALDESCUENTOS { get; set; }

        public string TOTALIMPUESTO { get; set; }

        public string TOTALCOMPROBANTE { get; set; }

        public bool CONTIENE_ERRORES { get; set; }

        public bool ERROR_WS { get; set; }

        public bool ERROR_SOFTLAND { get; set; }

        public bool ENVIADO { get; set; }

        public string ACEPTADO { get; set; }

        public string RESPUESTA_XML { get; set; }
        public string PDF { get; set; }

        public string XML { get; set; }

        public string var { get; set; }

        public string CIA { get; set; }

    }
}