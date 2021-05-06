using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using demosaba.Controllers;
using demosaba.Models;


namespace demosaba.filtro
{
    public class verificasesion : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                bool usuario_p = false;

                usuario_p = Estado.estado_session;
                if (usuario_p == false)
                {

                    if (filterContext.Controller is loginController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/login/Index");
                    }



                }

            }
            catch (Exception)
            {
                filterContext.Result = new RedirectResult("/demo/Index");
            }




        }

    }
}