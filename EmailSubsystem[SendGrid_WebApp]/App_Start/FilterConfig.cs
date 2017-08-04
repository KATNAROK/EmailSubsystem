using System.Web;
using System.Web.Mvc;

namespace EmailSubsystem_SendGrid_WebApp_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
