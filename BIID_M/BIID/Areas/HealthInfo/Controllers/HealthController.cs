﻿using System.Web.Mvc;
using BIID.Controllers;

namespace BIID.Areas.HealthInfo.Controllers
{
    public class HealthController:BiidFinalBaseController
    {
        public ActionResult Index()
        {
            var districts = this.ImplCustomerProfile.GetAllDistrcts();

            ViewData["districtsInCustomerSave"] = districts;
          
            return View();
        }
        
    }
} 