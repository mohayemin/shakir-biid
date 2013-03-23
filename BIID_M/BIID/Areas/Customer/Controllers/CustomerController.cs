using System.Data;
using System.Linq;
using System.Web.Mvc;
using BIID.Controllers;
using BIID.Entities;

namespace BIID.Areas.Customer.Controllers
{ 
    public class CustomerController :BiidFinalBaseController
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Customer/Customer/

        public ActionResult Index(string customerId)
        {
            if (CustomerExists(customerId))
            {
                var customer = this.ImplCustomerProfile.GetCustomerByCustomerId(customerId);
                return View(customer);
            }
            else return RedirectToAction("Create", "Customer", new {customerId = customerId});
        }

        //
        // GET: /Customer/Customer/Details/5

        public ViewResult Details(int id)
        {
            CustmerProfile custmerprofile = _db.CustmerProfiles.Find(id);
            return View(custmerprofile);
        }

        //
        // GET: /Customer/Customer/Create

        public ActionResult Create(string customerId)
        {
            var districts = this.ImplCustomerProfile.GetAllDistrcts();

            SelectList sl = new SelectList(districts);

            
            ViewData["districtsInCustomerSave"] = districts;

            ViewBag.customerId = customerId;

            return View();
        } 

        public ActionResult GetUpazillasByDistrictId(int districtId)
        {
            var model = this.ImplCustomerProfile.GetUpazillaByDistrictId(districtId);
            return Json(
model.Select(x => new { id = x.Id, name = x.Name }),
JsonRequestBehavior.AllowGet
);
        }

        //
        // POST: /Customer/Customer/Create

        [HttpPost]
        public ActionResult Create(CustmerProfile custmerprofile)
        {
            if (ModelState.IsValid)
            {
                this.ImplCustomerProfile.SaveCustomerData(custmerprofile);
                return RedirectToAction("Index");  
            }

            return View(custmerprofile);
        }
        
        //
        // GET: /Customer/Customer/Edit/5
 
        public ActionResult Edit(int id)
        {
            CustmerProfile custmerprofile = _db.CustmerProfiles.Find(id);
            return View(custmerprofile);
        }

        //
        // POST: /Customer/Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(CustmerProfile custmerprofile)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(custmerprofile).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(custmerprofile);
        }

        //
        // GET: /Customer/Customer/Delete/5
 
        public ActionResult Delete(int id)
        {
            CustmerProfile custmerprofile = _db.CustmerProfiles.Find(id);
            return View(custmerprofile);
        }

        //
        // POST: /Customer/Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            CustmerProfile custmerprofile = _db.CustmerProfiles.Find(id);
            _db.CustmerProfiles.Remove(custmerprofile);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        bool CustomerExists(string customerId)
        {
            if (this.ImplCustomerProfile.IsExistingCustomer(customerId)) return true;
            else return false;

        }
      
    }
}