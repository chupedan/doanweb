using System.Web.Mvc;

namespace QLGO.Areas.BCTK
{
    public class BCTKAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BCTK";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BCTK_default",
                "BCTK/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}