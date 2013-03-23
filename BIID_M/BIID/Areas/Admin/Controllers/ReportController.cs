using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BIID.Areas.Admin.Models;
using BIID.Controllers;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BIID.Areas.Admin.Controllers
{
    public class ReportController : BiidFinalBaseController
    {
        //
        // GET: /Admin/Report/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogReport()
        {
            return View();
        }

        public void GenerateUserLogReport(int userId)
        {
            var userLogs = AdminService.GetUserLogByUserId(userId);

            List<UserLogModelForReport> logModelForReport = userLogs.Select(userLog => new UserLogModelForReport()
                                                                                           {
                                                                                               Activity = userLog.Activity,
                                                                                               DateTime = userLog.DateTime,
                                                                                               Id = userLog.Id,
                                                                                               UserId = userLog.UserId,
                                                                                               UserName = userLog.User.UserName
                                                                                           }).ToList();


            string fileName = Server.MapPath("~/Areas/Admin/Reports/UserLogReport.rpt");
            ReportDocument userLogReport = new ReportDocument();
            userLogReport.Load(fileName);

            userLogReport.SetDataSource(logModelForReport as object);
            userLogReport.SetParameterValue("CreatedBy", HttpContext.Session["CurrentUserName"].ToString());

            userLogReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");
        }
    }
}
