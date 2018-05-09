using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StaffingPlanner.Models;

namespace StaffingPlanner.Controllers
{
    public class OpportunityGroupsController : Controller
    {
        private DEV_ClientOpportunitiesEntities db = new DEV_ClientOpportunitiesEntities();

        // GET: OpportunityGroups
        public ActionResult Index()
        {
            var oPPORTUNITY_GROUP = db.OPPORTUNITY_GROUP.Include(o => o.OPPORTUNITY_CATALOG);
            return View(oPPORTUNITY_GROUP.ToList());
        }

        // GET: OpportunityGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPPORTUNITY_GROUP oPPORTUNITY_GROUP = db.OPPORTUNITY_GROUP.Find(id);
            if (oPPORTUNITY_GROUP == null)
            {
                return HttpNotFound();
            }
            return View(oPPORTUNITY_GROUP);
        }

        // GET: OpportunityGroups/Create
        public ActionResult Create()
        {
            ViewBag.OPPORTUNITY_ID = new SelectList(db.OPPORTUNITY_CATALOG, "OPPORTUNITY_ID", "LOCATION");
            return View();
        }

        // POST: OpportunityGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GROUP_ID,OPPORTUNITY_ID,SKILLSET,OPPORTUNITY_GROUP_STATUS,GROUP_POSITIONS_AVAILABLE,MAX_TARGET_GRADE,TARGET_NEW_HIRE_GRADE,SITE,DURATION,TARGETED_CONSULTANTS,CANDIDATE_CONFIRMED,RATE_CARD_PER_HR,EXPECTED_START_DATE,ACTUAL_START_DATE,ACTUAL_END_DATE,LAST_EDITED_BY,LAST_EDITED_DATE")] OPPORTUNITY_GROUP oPPORTUNITY_GROUP)
        {
            if (ModelState.IsValid)
            {
                db.OPPORTUNITY_GROUP.Add(oPPORTUNITY_GROUP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OPPORTUNITY_ID = new SelectList(db.OPPORTUNITY_CATALOG, "OPPORTUNITY_ID", "LOCATION", oPPORTUNITY_GROUP.OPPORTUNITY_ID);
            return View(oPPORTUNITY_GROUP);
        }

        // GET: OpportunityGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPPORTUNITY_GROUP oPPORTUNITY_GROUP = db.OPPORTUNITY_GROUP.Find(id);
            if (oPPORTUNITY_GROUP == null)
            {
                return HttpNotFound();
            }
            ViewBag.OPPORTUNITY_ID = new SelectList(db.OPPORTUNITY_CATALOG, "OPPORTUNITY_ID", "LOCATION", oPPORTUNITY_GROUP.OPPORTUNITY_ID);
            return View(oPPORTUNITY_GROUP);
        }

        // POST: OpportunityGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GROUP_ID,OPPORTUNITY_ID,SKILLSET,OPPORTUNITY_GROUP_STATUS,GROUP_POSITIONS_AVAILABLE,MAX_TARGET_GRADE,TARGET_NEW_HIRE_GRADE,SITE,DURATION,TARGETED_CONSULTANTS,CANDIDATE_CONFIRMED,RATE_CARD_PER_HR,EXPECTED_START_DATE,ACTUAL_START_DATE,ACTUAL_END_DATE,LAST_EDITED_BY,LAST_EDITED_DATE")] OPPORTUNITY_GROUP oPPORTUNITY_GROUP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oPPORTUNITY_GROUP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OPPORTUNITY_ID = new SelectList(db.OPPORTUNITY_CATALOG, "OPPORTUNITY_ID", "LOCATION", oPPORTUNITY_GROUP.OPPORTUNITY_ID);
            return View(oPPORTUNITY_GROUP);
        }

        // GET: OpportunityGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPPORTUNITY_GROUP oPPORTUNITY_GROUP = db.OPPORTUNITY_GROUP.Find(id);
            if (oPPORTUNITY_GROUP == null)
            {
                return HttpNotFound();
            }
            return View(oPPORTUNITY_GROUP);
        }

        // POST: OpportunityGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OPPORTUNITY_GROUP oPPORTUNITY_GROUP = db.OPPORTUNITY_GROUP.Find(id);
            db.OPPORTUNITY_GROUP.Remove(oPPORTUNITY_GROUP);
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
