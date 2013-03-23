using System.Web.Mvc;
using BIID.Implementations;

namespace BIID.Controllers
{
    public class BiidFinalBaseController : Controller
    {
        public ImplCustomerProfile ImplCustomerProfile;
        public ImplAgriculturalService AgriculturalService;
        public ImplDirectoryService DirectoryService;
        public ImplAdminService AdminService;
        public BiidFinalBaseController()
        {
            ImplCustomerProfile = new ImplCustomerProfile();
            AgriculturalService = new ImplAgriculturalService();
            DirectoryService = new ImplDirectoryService();
            AdminService = new ImplAdminService();
        }


    }
}
