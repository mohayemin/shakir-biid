using System.Web.Mvc;

namespace BIID.Areas.DirectoryInfo
{
    public class DirectoryInfoAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DirectoryInfo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DirectoryInfo_default",
                "DirectoryInfo/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
