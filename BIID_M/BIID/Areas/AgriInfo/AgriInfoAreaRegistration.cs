using System.Web.Mvc;

namespace BIID.Areas.AgriInfo
{
    public class AgriInfoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "AgriInfo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AgriInfo_default",
                "AgriInfo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
