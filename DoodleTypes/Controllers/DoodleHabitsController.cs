using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoodleTypes.Models;

namespace DoodleTypes.Controllers
{
    public class DoodleHabitsController : Controller
    {
        private DoodleTypesContext db = new DoodleTypesContext();

        // GET: DoodleHabits
        public ActionResult Index()
        {
            var doodleHabits = db.DoodleHabits.Include(d => d.Doodling);
            return View(doodleHabits.ToList());
        }

        // GET: DoodleHabits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoodleHabit doodleHabit = db.DoodleHabits.Find(id);
            if (doodleHabit == null)
            {
                return HttpNotFound();
            }
            return View(doodleHabit);
        }

        // GET: DoodleHabits/Create
        public ActionResult Create()
        {
            ViewBag.DoodleBreedID = new SelectList(db.DoodleBreeds, "DoodleBreedID", "Description");
            return View();
        }

        // POST: DoodleHabits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoodleHabitID,Description,DoodleBreedID")] DoodleHabit doodleHabit)
        {
            if (ModelState.IsValid)
            {
                db.DoodleHabits.Add(doodleHabit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoodleBreedID = new SelectList(db.DoodleBreeds, "DoodleBreedID", "Description", doodleHabit.DoodleBreedID);
            return View(doodleHabit);
        }

        // GET: DoodleHabits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoodleHabit doodleHabit = db.DoodleHabits.Find(id);
            if (doodleHabit == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoodleBreedID = new SelectList(db.DoodleBreeds, "DoodleBreedID", "Description", doodleHabit.DoodleBreedID);
            return View(doodleHabit);
        }

        // POST: DoodleHabits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoodleHabitID,Description,DoodleBreedID")] DoodleHabit doodleHabit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doodleHabit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoodleBreedID = new SelectList(db.DoodleBreeds, "DoodleBreedID", "Description", doodleHabit.DoodleBreedID);
            return View(doodleHabit);
        }

        // GET: DoodleHabits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoodleHabit doodleHabit = db.DoodleHabits.Find(id);
            if (doodleHabit == null)
            {
                return HttpNotFound();
            }
            return View(doodleHabit);
        }

        // POST: DoodleHabits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoodleHabit doodleHabit = db.DoodleHabits.Find(id);
            db.DoodleHabits.Remove(doodleHabit);
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
