using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class LevelOfFitnessesController : Controller
    {
        private CapstoneEntities db = new CapstoneEntities();

        // GET: LevelOfFitnesses
        public ActionResult Index()
        {
            return View(db.LevelOfFitnesses.ToList());
        }

        // GET: LevelOfFitnesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelOfFitness levelOfFitness = db.LevelOfFitnesses.Find(id);
            if (levelOfFitness == null)
            {
                return HttpNotFound();
            }
            return View(levelOfFitness);
        }

        // GET: LevelOfFitnesses/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: LevelOfFitnesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LevelID,LevelName")] LevelOfFitness levelOfFitness)
        {
            if (ModelState.IsValid)
            {
                db.LevelOfFitnesses.Add(levelOfFitness);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(levelOfFitness);
        }

        // GET: LevelOfFitnesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelOfFitness levelOfFitness = db.LevelOfFitnesses.Find(id);
            if (levelOfFitness == null)
            {
                return HttpNotFound();
            }
            return View(levelOfFitness);
        }

        // POST: LevelOfFitnesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LevelID,LevelName")] LevelOfFitness levelOfFitness)
        {
            if (ModelState.IsValid)
            {
                db.Entry(levelOfFitness).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(levelOfFitness);
        }

        // GET: LevelOfFitnesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LevelOfFitness levelOfFitness = db.LevelOfFitnesses.Find(id);
            if (levelOfFitness == null)
            {
                return HttpNotFound();
            }
            return View(levelOfFitness);
        }

        // POST: LevelOfFitnesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LevelOfFitness levelOfFitness = db.LevelOfFitnesses.Find(id);
            db.LevelOfFitnesses.Remove(levelOfFitness);
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
