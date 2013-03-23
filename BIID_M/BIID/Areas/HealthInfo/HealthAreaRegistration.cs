﻿using System.Web.Mvc;

namespace BIID.Areas.HealthInfo
{
    public class HealthAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Health";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Health_default",
                "Health/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
