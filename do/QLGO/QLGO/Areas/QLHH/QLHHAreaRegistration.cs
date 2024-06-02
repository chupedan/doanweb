using System.Web.Mvc;

namespace QLGO.Areas.QLHH
{
    public class QLHHAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QLHH";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QLHH_default",
                "QLHH/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}