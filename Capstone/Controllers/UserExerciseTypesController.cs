using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;
using Microsoft.AspNet.Identity;

namespace Capstone.Controllers
{
    [Authorize]
    public class UserExerciseTypesController : Controller
    {
        private CapstoneEntities db = new CapstoneEntities();

        // GET: UserExerciseTypes
        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                id = User.Identity.GetUserId();
            }

            var userExerciseTypes = db.GymUsers.Find(id).UserExerciseTypes;
            ViewBag.UserID = id;
            return PartialView(userExerciseTypes.ToList());
        }

        // GET: UserExerciseTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserExerciseType userExerciseType = db.UserExerciseTypes.Find(id);
            if (userExerciseType == null)
            {
                return HttpNotFound();
            }
            return View(userExerciseType);
        }

        // GET: UserExerciseTypes/Create
        public ActionResult Create()
        {
            ViewBag.ExerciseTypeID = new SelectList(db.ExerciseTypes, "ExerciseTypeID", "ExerciseName");
            ViewBag.GymID = new SelectList(db.GymOrPlaces, "GymID", "GymName");
            ViewBag.LevelID = new SelectList(db.LevelOfFitnesses, "LevelID", "LevelName");
            var userExerciseType = new UserExerciseType();
            userExerciseType.UserID = User.Identity.GetUserId();
            return View(userExerciseType);
        }

        // POST: UserExerciseTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserExerciseTypeID,UserID,ExerciseTypeID,GymID,LevelID")] UserExerciseType userExerciseType)
        {
            if (ModelState.IsValid)
            {
                db.UserExerciseTypes.Add(userExerciseType);
                db.SaveChanges();
                return RedirectToAction("Details","GymUsers", new {id =userExerciseType.UserID });
            }

            ViewBag.ExerciseTypeID = new SelectList(db.ExerciseTypes, "ExerciseTypeID", "ExerciseName", userExerciseType.ExerciseTypeID);
            ViewBag.GymID = new SelectList(db.GymOrPlaces, "GymID", "GymName", userExerciseType.GymID);
            ViewBag.UserID = new SelectList(db.GymUsers, "UserID", "Fname", userExerciseType.UserID);
            ViewBag.LevelID = new SelectList(db.LevelOfFitnesses, "LevelID", "LevelName", userExerciseType.LevelID);
            return View(userExerciseType);
        }

        // GET: UserExerciseTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserExerciseType userExerciseType = db.UserExerciseTypes.Find(id);
            if (userExerciseType == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseTypeID = new SelectList(db.ExerciseTypes, "ExerciseTypeID", "ExerciseName", userExerciseType.ExerciseTypeID);
            ViewBag.GymID = new SelectList(db.GymOrPlaces, "GymID", "GymName", userExerciseType.GymID);
            ViewBag.UserID = new SelectList(db.GymUsers, "UserID", "Fname", userExerciseType.UserID);
            ViewBag.LevelID = new SelectList(db.LevelOfFitnesses, "LevelID", "LevelName", userExerciseType.LevelID);
            return View(userExerciseType);
        }

        // POST: UserExerciseTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserExerciseTypeID,UserID,ExerciseTypeID,GymID,LevelID")] UserExerciseType userExerciseType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userExerciseType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "GymUsers", new { id = userExerciseType.UserID });
            }
            ViewBag.ExerciseTypeID = new SelectList(db.ExerciseTypes, "ExerciseTypeID", "ExerciseName", userExerciseType.ExerciseTypeID);
            ViewBag.GymID = new SelectList(db.GymOrPlaces, "GymID", "GymName", userExerciseType.GymID);
            ViewBag.UserID = new SelectList(db.GymUsers, "UserID", "Fname", userExerciseType.UserID);
            ViewBag.LevelID = new SelectList(db.LevelOfFitnesses, "LevelID", "LevelName", userExerciseType.LevelID);
            return View(userExerciseType);
        }

        // GET: UserExerciseTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserExerciseType userExerciseType = db.UserExerciseTypes.Find(id);
            if (userExerciseType == null)
            {
                return HttpNotFound();
            }
            return View(userExerciseType);
        }

        // POST: UserExerciseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserExerciseType userExerciseType = db.UserExerciseTypes.Find(id);
            db.UserExerciseTypes.Remove(userExerciseType);
            db.SaveChanges();
            return RedirectToAction("Details", "GymUsers", new { id = userExerciseType.UserID });
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
            if (string.IsNullOrEmpty(id))
            {
                id = User.Identity.GetUserId();
            }

            var userExerciseTypes = db.GymUsers.Find(id).UserExerciseTypes;
            ViewBag.UserID = id;
            return View(userExerciseTypes.ToList());
        }
    }
}
