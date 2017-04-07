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
    public class DoodleBreedsController : Controller
    {
        private DoodleTypesContext db = new DoodleTypesContext();

        // GET: DoodleBreeds
        public ActionResult Index()
        {
            return View(db.DoodleBreeds.ToList());
        }

        // GET: DoodleBreeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoodleBreed doodleBreed = db.DoodleBreeds.Find(id);
            if (doodleBreed == null)
            {
                return HttpNotFound();
            }
            return View(doodleBreed);
        }

        // GET: DoodleBreeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoodleBreeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoodleBreedID,Description")] DoodleBreed doodleBreed)
        {
            if (ModelState.IsValid)
            {
                db.DoodleBreeds.Add(doodleBreed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doodleBreed);
        }

        // GET: DoodleBreeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoodleBreed doodleBreed = db.DoodleBreeds.Find(id);
            if (doodleBreed == null)
            {
                return HttpNotFound();
            }
            return View(doodleBreed);
        }

        // POST: DoodleBreeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoodleBreedID,Description")] DoodleBreed doodleBreed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doodleBreed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doodleBreed);
        }

        // GET: DoodleBreeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoodleBreed doodleBreed = db.DoodleBreeds.Find(id);
            if (doodleBreed == null)
            {
                return HttpNotFound();
            }
            return View(doodleBreed);
        }

        // POST: DoodleBreeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoodleBreed doodleBreed = db.DoodleBreeds.Find(id);
            db.DoodleBreeds.Remove(doodleBreed);
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
