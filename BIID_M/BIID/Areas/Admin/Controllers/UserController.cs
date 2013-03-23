using System.Data;
using System.Linq;
using System.Web.Mvc;
using BIID.Entities;

namespace BIID.Areas.Admin.Controllers
{ 
    public class UserController : Controller
    {
        private readonly BIIDFinalEntities _db = new BIIDFinalEntities();

        //
        // GET: /Admin/User/

        public ViewResult Index()
        {
            return View(_db.Users.ToList());
        }

        //
        // GET: /Admin/User/Details/5

        public ViewResult Details(int id)
        {
            User user = _db.Users.Find(id);
            return View(user);
        }

        //
        // GET: /Admin/User/Create

        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(_db.UserRoles, "Id", "RoleName");
            return View();
        } 

        //
        // POST: /Admin/User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.RoleId = new SelectList(_db.UserRoles, "Id", "RoleName");
            return View(user);
        }
        
        //
        // GET: /Admin/User/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewBag.RoleId = new SelectList(_db.UserRoles, "Id", "RoleName");
            return View();
        }

        //
        // POST: /Admin/User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(user).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /Admin/User/Delete/5
 
        public ActionResult Delete(int id)
        {
            ViewBag.RoleId = new SelectList(_db.UserRoles, "Id", "RoleName");
            return View();
        
        }

        //
        // POST: /Admin/User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            User user = _db.Users.Find(id);
            _db.Users.Remove(user);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}