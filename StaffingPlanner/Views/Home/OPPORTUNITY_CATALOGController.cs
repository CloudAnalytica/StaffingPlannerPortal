using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StaffingPlanner.Models;

namespace StaffingPlanner.Views.Home
{
    public class OPPORTUNITY_CATALOGController : Controller
    {
        private DEV_ClientOpportunitiesEntities db = new DEV_ClientOpportunitiesEntities();

        // GET: OPPORTUNITY_CATALOG
        public ActionResult Index()
        {
            var oPPORTUNITY_CATALOG = db.OPPORTUNITY_CATALOG.Include(o => o.CLIENT_DETAILS).Include(o => o.OPPORTUNITY_STATUS1);
            return View(oPPORTUNITY_CATALOG.ToList());
        }

        // GET: OPPORTUNITY_CATALOG/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPPORTUNITY_CATALOG oPPORTUNITY_CATALOG = db.OPPORTUNITY_CATALOG.Find(id);
            if (oPPORTUNITY_CATALOG == null)
            {
                return HttpNotFound();
            }
            return View(oPPORTUNITY_CATALOG);
        }

        // GET: OPPORTUNITY_CATALOG/Create
        public ActionResult Create()
        {
            ViewBag.CLIENT_ID = new SelectList(db.CLIENT_DETAILS, "CLIENT_ID", "CLIENT_NAME");
            ViewBag.OPPORTUNITY_STATUS_ID = new SelectList(db.OPPORTUNITY_STATUS, "OPPORTUNITY_STATUS_ID", "OPPORTUNITY_STATUS_NAME");
            return View();
        }

        // POST: OPPORTUNITY_CATALOG/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OPPORTUNITY_ID,CLIENT_ID,OPPORTUNITY_STATUS_ID,LOCATION,SPONSOR,OPPORTUNITY_NAME,OPPORTUNITY_PRACTICE,OPPORTUNITY_VALUE,OPPORTUNITY_STATUS,OPPORTUNITY_COMMENT,OPPORTUNITY_PRIORITY,OPPORTUNITY_TYPE,NUMBER_OF_REQUIRED_ROLES,LAST_EDITED_BY,LAST_EDITED_DATE")] OPPORTUNITY_CATALOG oPPORTUNITY_CATALOG)
        {
            if (ModelState.IsValid)
            {
                db.OPPORTUNITY_CATALOG.Add(oPPORTUNITY_CATALOG);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLIENT_ID = new SelectList(db.CLIENT_DETAILS, "CLIENT_ID", "CLIENT_NAME", oPPORTUNITY_CATALOG.CLIENT_ID);
            ViewBag.OPPORTUNITY_STATUS_ID = new SelectList(db.OPPORTUNITY_STATUS, "OPPORTUNITY_STATUS_ID", "OPPORTUNITY_STATUS_NAME", oPPORTUNITY_CATALOG.OPPORTUNITY_STATUS_ID);
            return View(oPPORTUNITY_CATALOG);
        }

        // GET: OPPORTUNITY_CATALOG/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPPORTUNITY_CATALOG oPPORTUNITY_CATALOG = db.OPPORTUNITY_CATALOG.Find(id);
            if (oPPORTUNITY_CATALOG == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLIENT_ID = new SelectList(db.CLIENT_DETAILS, "CLIENT_ID", "CLIENT_NAME", oPPORTUNITY_CATALOG.CLIENT_ID);
            ViewBag.OPPORTUNITY_STATUS_ID = new SelectList(db.OPPORTUNITY_STATUS, "OPPORTUNITY_STATUS_ID", "OPPORTUNITY_STATUS_NAME", oPPORTUNITY_CATALOG.OPPORTUNITY_STATUS_ID);
            return View(oPPORTUNITY_CATALOG);
        }

        // POST: OPPORTUNITY_CATALOG/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OPPORTUNITY_ID,CLIENT_ID,OPPORTUNITY_STATUS_ID,LOCATION,SPONSOR,OPPORTUNITY_NAME,OPPORTUNITY_PRACTICE,OPPORTUNITY_VALUE,OPPORTUNITY_STATUS,OPPORTUNITY_COMMENT,OPPORTUNITY_PRIORITY,OPPORTUNITY_TYPE,NUMBER_OF_REQUIRED_ROLES,LAST_EDITED_BY,LAST_EDITED_DATE")] OPPORTUNITY_CATALOG oPPORTUNITY_CATALOG)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oPPORTUNITY_CATALOG).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLIENT_ID = new SelectList(db.CLIENT_DETAILS, "CLIENT_ID", "CLIENT_NAME", oPPORTUNITY_CATALOG.CLIENT_ID);
            ViewBag.OPPORTUNITY_STATUS_ID = new SelectList(db.OPPORTUNITY_STATUS, "OPPORTUNITY_STATUS_ID", "OPPORTUNITY_STATUS_NAME", oPPORTUNITY_CATALOG.OPPORTUNITY_STATUS_ID);
            return View(oPPORTUNITY_CATALOG);
        }

        // GET: OPPORTUNITY_CATALOG/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPPORTUNITY_CATALOG oPPORTUNITY_CATALOG = db.OPPORTUNITY_CATALOG.Find(id);
            if (oPPORTUNITY_CATALOG == null)
            {
                return HttpNotFound();
            }
            return View(oPPORTUNITY_CATALOG);
        }

        // POST: OPPORTUNITY_CATALOG/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OPPORTUNITY_CATALOG oPPORTUNITY_CATALOG = db.OPPORTUNITY_CATALOG.Find(id);
            db.OPPORTUNITY_CATALOG.Remove(oPPORTUNITY_CATALOG);
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
