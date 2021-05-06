using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using demosaba.Models;

namespace demosaba.Controllers
{
    public class loginController : Controller
    {

        // GET: login
        public ActionResult Index()
        {



            return View();
        }
        [HttpPost]
        public ActionResult Verificar(string name, string password)
        {
            ////aqui hacemos la coneccion 
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            SqlCommand com = new SqlCommand();
            SqlDataReader dr;
            sqlconn.Open();
            com.Connection = sqlconn;
            ///hacemos una consulta que compara el password 
            com.CommandText = "Select * from sys.sql_logins where name ='"+name+"' and pwdcompare('"+password+"', password_hash) = 1 ";
          //  com.CommandText = "Select * from sys.sql_logins where name ='" + name + "'";
            dr = com.ExecuteReader();

            ////si logra obtener lectura signicfica que el password es correcto por ende levanta la session
            if (dr.Read())
            {
                Estado.estado_session = true;

                sqlconn.Close();
                return RedirectToAction("Index", "demo");
            }
            else
            {

                ViewBag.Error = "Usuario o contraseña invalida";
                sqlconn.Close();
                return View("Index");

            }


        }
    }
}