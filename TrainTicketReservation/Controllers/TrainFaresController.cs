using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrainTicketReservation.Models;

namespace TrainTicketReservation.Controllers
{
    public class TrainFaresController : Controller
    {
        private TrainReservation db = new TrainReservation();

        // GET: TrainFares
        public ActionResult Index()
        {
            var trainFares = db.TrainFares.Include(t => t.Train);
            return View(trainFares.ToList());
        }

        // GET: TrainFares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainFare trainFare = db.TrainFares.Find(id);
            if (trainFare == null)
            {
                return HttpNotFound();
            }
            return View(trainFare);
        }

        // GET: TrainFares/Create
        public ActionResult Create()
        {
            ViewBag.TrainNo = new SelectList(db.Trains, "TrainNo", "TrainNo");
            return View();
        }

        // POST: TrainFares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainNo,ACTier3_Fares,ACTier2_Fares,ACTier1_Fares,SLFare,SSFare")] TrainFare trainFare)
        {
            if (ModelState.IsValid)
            {
                db.TrainFares.Add(trainFare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrainNo = new SelectList(db.Trains, "TrainNo", "TrainNo", trainFare.TrainNo);
            return View(trainFare);
        }

        // GET: TrainFares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainFare trainFare = db.TrainFares.Find(id);
            if (trainFare == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrainNo = new SelectList(db.Trains, "TrainNo", "Source", trainFare.TrainNo);
            return View(trainFare);
        }

        // POST: TrainFares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainNo,ACTier3_Fares,ACTier2_Fares,ACTier1_Fares,SLFare,SSFare")] TrainFare trainFare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainFare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrainNo = new SelectList(db.Trains, "TrainNo", "Source", trainFare.TrainNo);
            return View(trainFare);
        }

        // GET: TrainFares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainFare trainFare = db.TrainFares.Find(id);
            if (trainFare == null)
            {
                return HttpNotFound();
            }
            return View(trainFare);
        }

        // POST: TrainFares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainFare trainFare = db.TrainFares.Find(id);
            db.TrainFares.Remove(trainFare);
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
