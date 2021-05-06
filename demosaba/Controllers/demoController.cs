using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using demosaba.Models;
using PagedList.Mvc;
using PagedList;
using System.Globalization;
using System.Threading;



namespace demosaba.Controllers
{
    public class demoController : Controller
    {
        // GET: demo
        public ActionResult Index(int? i, DateTime? start, DateTime? end, string sortOrder, DateTime? currentFilter, DateTime? currentFilter2,string CIAS , string currentCias, string errors, string errorw, string errorsoftland, string enviado, string estadof,string sinfiltros)
        {
            int numPagina = 25;
            //Se especifica formato fecha ya que el iis la cambia
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("uk");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("uk");
            ////verificar el cias 
            ///verificar filtros
          
            ///View bag para marcar el orden 
            ViewBag.CurrentSort = sortOrder;
            ///coneccion a base de datos
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery;
            if (start == null)
            {
                if (Estado.d_filtros_f == false)
                {
                    //consulta default
                    start = Estado.fecha_i;
                    end = Estado.fecha_f;
                    CIAS = Estado.d_cia_f;
                    enviado = Estado.d_enviado_f;
                    errors = Estado.error_f;
                    errorw = Estado.error_fw;
                    errorsoftland = Estado.error_fs;
                    estadof = Estado.d_aceptado_f;
                    sqlquery = "set dateformat dmy select  * from [erpadmin].[P_APP_HACIENDA_DE] where CIA = '" + CIAS + "'and FECHA between '" + start + "'and'" + end + "'and [CONTIENE ERRORES]='" + errors + "'and [ERROR EN WEB SERVICE]='" + errorw + "'and [ERROR DE SOFTLAND]='" + errorsoftland + "'and [ENVIADO AL CLIENTE]='" + enviado + "'and [ESTADO]='" + estadof + "'";

                    //  sqlquery = "set dateformat dmy select top 200  * from [erpadmin].[P_APP_HACIENDA_DE] where CIA = '" + CIAS + "'and FECHA between '" + start + "'and'" + end + "'";
                }
                else
                {
                    start = Estado.fecha_i;
                    end = Estado.fecha_f;
                    CIAS = Estado.d_cia_f;
                   
                    sqlquery = "set dateformat dmy select top 200  * from [erpadmin].[P_APP_HACIENDA_DE] where CIA = '" + CIAS + "'and FECHA between '" + start + "'and'" + end + "'";



                }


            }
            else
            {
                if (sinfiltros == null)
                {
                    ///se verifican los filtros
                    if (errors == null)
                    {
                        errors = "NO";
                    }
                    if (errorw == null)
                    {
                        errorw = "NO";
                    }
                    if (errorsoftland == null)
                    {
                        errorsoftland = "NO";
                    }
                    if (enviado == null)
                    {
                        enviado = "NO";
                    }
                    //consulta cuando se hace busqueda con fecha
                    sqlquery = "set dateformat dmy select  * from [erpadmin].[P_APP_HACIENDA_DE] where CIA = '" + CIAS + "'and FECHA between '" + start + "'and'" + end + "'and [CONTIENE ERRORES]='" + errors + "'and [ERROR EN WEB SERVICE]='" + errorw + "'and [ERROR DE SOFTLAND]='" + errorsoftland + "'and [ENVIADO AL CLIENTE]='" + enviado + "'and [ESTADO]='" + estadof + "'";
                    ViewBag.CurrentFilter = start;
                    ViewBag.CurrentFilter2 = end;
                    ViewBag.currentCias = CIAS;
                    Estado.fecha_i = Convert.ToDateTime(start);
                    Estado.fecha_f = Convert.ToDateTime(end);
                    Estado.d_cia_f = CIAS;
                    Estado.d_enviado_f = enviado;
                    Estado.error_f = errors;
                    Estado.error_fw = errorw;
                    Estado.error_fs = errorsoftland;
                    Estado.d_aceptado_f = estadof;
                    Estado.d_filtros_f = false;
                    numPagina = 30;
                }
                else
                {
                    sqlquery = "set dateformat dmy select top 200  * from [erpadmin].[P_APP_HACIENDA_DE] where CIA = '" + CIAS + "'and FECHA between '" + start + "'and'" + end + "'";
                    ViewBag.CurrentFilter = start;
                    ViewBag.CurrentFilter2 = end;
                    ViewBag.currentCias = CIAS;
                    Estado.fecha_i = Convert.ToDateTime(start);
                    Estado.fecha_f = Convert.ToDateTime(end);
                    Estado.d_cia_f = CIAS;
                    Estado.d_filtros_f = true;
                }
            }


            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<MVClass> lc = new List<MVClass>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
               var con_err = Convert.ToString(dr["CONTIENE ERRORES"]);
                var con_errws = Convert.ToString(dr["ERROR EN WEB SERVICE"]);
                var con_soft = Convert.ToString(dr["ERROR DE SOFTLAND"]);
                var acept = Convert.ToString(dr["ESTADO"]);
                var envia = Convert.ToString(dr["ENVIADO AL CLIENTE"]);
                var error = true;
                var error2 = true;
                var error3 = true;
                var var_env = false;
                var var_acep = false;
                //se verifica cuando los campos son null para enviarlos al check box
                if (con_err == "NO")
                {
                    error = false;
                }
                if (con_errws == "NO")
                {
                    error2 = false;
                }
                if (con_soft == "NO")
                {
                    error3 = false;
                }
                if (envia == "SI")
                {
                    var_env = true;
                }
                /*if (acept == "ACEPTADO")
                {
                    var_acep = true;
                }*/
                lc.Add(new MVClass
                {
                    ///Se guarda cada campo en el modelo y este se envia al index
                    DOCUMENTO = Convert.ToString(dr["DOCUMENTO"]),
                    CLIENTE = Convert.ToString(dr["CLIENTE"]),
                    FECHA = Convert.ToDateTime(dr["FECHA"]),
                    NOMBRE = Convert.ToString(dr["NOMBRE"]),
                    NIT_RECEPTOR = Convert.ToString(dr["NIT_RECEPTOR"]),
                    CODIGO_MONEDA = Convert.ToString(dr["CODIGO_MONEDA"]),
                    CLAVE = Convert.ToString(dr["CLAVE"]),
                    TOTALGRAVADO = Convert.ToString(dr["TOTAL GRAVADO"]),
                    TOTALEXENTO = Convert.ToString(dr["TOTAL EXENTO"]),
                    TOTALDESCUENTOS = Convert.ToString(dr["TOTAL DESCUENTOS"]),
                    TOTALIMPUESTO = Convert.ToString(dr["TOTAL IMPUESTOS"]),
                    TOTALCOMPROBANTE = Convert.ToString(dr["TOTAL COMPROBANTE"]),
                   CONTIENE_ERRORES = error,
                    ERROR_WS = error2,
                    ERROR_SOFTLAND = error3,
                    ENVIADO = var_env,
                    ACEPTADO = Convert.ToString(dr["ESTADO"]),
                    RESPUESTA_XML = Convert.ToString(dr["RESPUESTA_XML"]).Remove(0,19),
                    PDF = Convert.ToString(dr["PDF"]).Remove(0,19),
                    XML = Convert.ToString(dr["XML"]).Remove(0, 19),
                    CIA = Convert.ToString(dr["CIA"])


                });
                
            }
            //Aqui se envia todo al index y la paginacion 
            int pagesize = numPagina;
            int pagenumber = (i ?? 1);
            sqlconn.Close();
            ModelState.Clear();
            return View(lc.ToPagedList(pagenumber, pagesize));
        }

      


    }
}