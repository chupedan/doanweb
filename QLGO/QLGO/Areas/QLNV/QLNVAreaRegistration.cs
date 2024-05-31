using System.Web.Mvc;

namespace QLGO.Areas.QLNV
{
    public class QLNVAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QLNV";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QLNV_default",
                "QLNV/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}