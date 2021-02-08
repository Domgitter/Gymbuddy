using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class GymOrPlacesController : Controller
    {
        private CapstoneEntities db = new CapstoneEntities();
        private readonly string mapKey = ConfigurationManager.AppSettings["mapKey"];

        // GET: GymOrPlaces
        public ActionResult Index()
        {
            return View(db.GymOrPlaces.ToList());
        }

        // GET: GymOrPlaces/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.mapKey = mapKey;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymOrPlace gymOrPlace = db.GymOrPlaces.Find(id);
            if (gymOrPlace == null)
            {
                return HttpNotFound();
            }
            return View(gymOrPlace);
        }

        // GET: GymOrPlaces/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: GymOrPlaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GymOrPlace gymOrPlace)
        {
            if (ModelState.IsValid)
            {
                db.GymOrPlaces.Add(gymOrPlace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gymOrPlace);
        }

        // GET: GymOrPlaces/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymOrPlace gymOrPlace = db.GymOrPlaces.Find(id);
            if (gymOrPlace == null)
            {
                return HttpNotFound();
            }
            return View(gymOrPlace);
        }

        // POST: GymOrPlaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GymOrPlace gymOrPlace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gymOrPlace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gymOrPlace);
        }

        // GET: GymOrPlaces/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymOrPlace gymOrPlace = db.GymOrPlaces.Find(id);
            if (gymOrPlace == null)
            {
                return HttpNotFound();
            }
            return View(gymOrPlace);
        }

        // POST: GymOrPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GymOrPlace gymOrPlace = db.GymOrPlaces.Find(id);
            db.GymOrPlaces.Remove(gymOrPlace);
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
        
    }
}
