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
    public class ExerciseTypesController : Controller
    {
        private CapstoneEntities db = new CapstoneEntities();

        // GET: ExerciseTypes
        public ActionResult Index()
        {
            var exerciseTypes = db.ExerciseTypes;
            return View(exerciseTypes.ToList());
        }

        // GET: ExerciseTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseType exerciseType = db.ExerciseTypes.Find(id);
            if (exerciseType == null)
            {
                return HttpNotFound();
            }
            return View(exerciseType);
        }

        // GET: ExerciseTypes/Create
        public ActionResult Create()
        {
            ViewBag.ExericiseID = new SelectList(db.Exercises, "ExerciseID", "Participant");
            return View();
        }

        // POST: ExerciseTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public ActionResult Create([Bind(Include = "ExerciseTypeID,ExericiseID,ExerciseName,ExerciseDescrip")] ExerciseType exerciseType)
        {
            if (ModelState.IsValid)
            {
                db.ExerciseTypes.Add(exerciseType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(exerciseType);
        }

        // GET: ExerciseTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseType exerciseType = db.ExerciseTypes.Find(id);
            if (exerciseType == null)
            {
                return HttpNotFound();
            }
            
            return View(exerciseType);
        }

        // POST: ExerciseTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExerciseTypeID,ExericiseID,ExerciseName,ExerciseDescrip")] ExerciseType exerciseType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exerciseType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(exerciseType);
        }

        // GET: ExerciseTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseType exerciseType = db.ExerciseTypes.Find(id);
            if (exerciseType == null)
            {
                return HttpNotFound();
            }
            return View(exerciseType);
        }

        // POST: ExerciseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExerciseType exerciseType = db.ExerciseTypes.Find(id);
            db.ExerciseTypes.Remove(exerciseType);
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
