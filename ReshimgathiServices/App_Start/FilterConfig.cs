using System.Web;
using System.Web.Mvc;

namespace ReshimgathiServices
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SnatchException());
            //filters.Add(new CatchException());
        }
    }
}
