using System.Web;
using System.Web.Mvc;

namespace demosaba
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            filters.Add(new filtro.verificasesion());
        }
    }
}
