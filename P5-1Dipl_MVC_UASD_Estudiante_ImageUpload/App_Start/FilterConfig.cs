using System.Web;
using System.Web.Mvc;

namespace P5_1Dipl_MVC_UASD_Estudiante_ImageUpload
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
