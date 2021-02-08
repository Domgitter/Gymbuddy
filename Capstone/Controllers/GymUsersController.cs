using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Capstone.Models;
using Capstone.Models.LocationAPI;
using Microsoft.AspNet.Identity;

namespace Capstone.Controllers
{
    public class GymUsersController : Controller
    {
        private CapstoneEntities db = new CapstoneEntities();

        // GET: GymUsers
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var gymUser = db.GymUsers.Find(userId);
            if(!db.NearByZips.Any(z=>z.SearchedZip== gymUser.Zip))
            {
                var locationApi = new ZipCodeApi();
                var nearbyZip = locationApi.findNearZip(gymUser.Zip.ToString("D5"), 30);
                var dbzips = new List<NearByZip>();
                foreach(var zip in nearbyZip.zip_codes)
                {
                    var dbzip = new NearByZip { ZipCode = zip.zip_code, City = zip.city, Distance = zip.distance,
                        State = zip.state, SearchedZip = gymUser.Zip };
                    db.NearByZips.Add(dbzip);
                }
                db.SaveChanges();
            }
            var users = db.FindNearbyUsers(gymUser.Zip).OrderBy(x=> x.Distance);

            
            return View(users.ToList());
        }

        // GET: GymUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymUser gymUser = db.GymUsers.Find(id);
            if (gymUser == null)
            {
                return HttpNotFound();
            }
            return View(gymUser);
        }

        // GET: GymUsers/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GymUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GymUser gymUser)
        {
            if (ModelState.IsValid)
            {
                db.GymUsers.Add(gymUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gymUser);
        }

        // GET: GymUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymUser gymUser = db.GymUsers.Find(id);
            if (gymUser == null)
            {
                return HttpNotFound();
            }
            return View(gymUser);
        }

        // POST: GymUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GymUser gymUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gymUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gymUser);
        }

        // GET: GymUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymUser gymUser = db.GymUsers.Find(id);
            if (gymUser == null)
            {
                return HttpNotFound();
            }
            return View(gymUser);
        }

        // POST: GymUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            GymUser gymUser = db.GymUsers.Find(id);
            db.GymUsers.Remove(gymUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult UserProfile(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymUser gymUser = db.GymUsers.Find(id);
            if (gymUser == null)
            {
                return HttpNotFound();
            }
            return View(gymUser);
        }
    }
}
