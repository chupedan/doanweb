using System.Web.Mvc;

namespace QLGO.Areas.QLHD
{
    public class QLHDAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QLHD";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QLHD_default",
                "QLHD/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}