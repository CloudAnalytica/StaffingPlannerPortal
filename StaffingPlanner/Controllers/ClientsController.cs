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
    public class ClientsController : Controller
    {
        private DEV_ClientOpportunitiesEntities db = new DEV_ClientOpportunitiesEntities();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.CLIENT_DETAILS.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENT_DETAILS cLIENT_DETAILS = db.CLIENT_DETAILS.Find(id);
            if (cLIENT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(cLIENT_DETAILS);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLIENT_ID,CLIENT_NAME,CLIENT_SUB_BUSINESS,CLIENT_STATUS,LAST_EDITED_BY,LAST_EDITED_DATE")] CLIENT_DETAILS cLIENT_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.CLIENT_DETAILS.Add(cLIENT_DETAILS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cLIENT_DETAILS);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENT_DETAILS cLIENT_DETAILS = db.CLIENT_DETAILS.Find(id);
            if (cLIENT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(cLIENT_DETAILS);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLIENT_ID,CLIENT_NAME,CLIENT_SUB_BUSINESS,CLIENT_STATUS,LAST_EDITED_BY,LAST_EDITED_DATE")] CLIENT_DETAILS cLIENT_DETAILS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENT_DETAILS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cLIENT_DETAILS);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENT_DETAILS cLIENT_DETAILS = db.CLIENT_DETAILS.Find(id);
            if (cLIENT_DETAILS == null)
            {
                return HttpNotFound();
            }
            return View(cLIENT_DETAILS);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENT_DETAILS cLIENT_DETAILS = db.CLIENT_DETAILS.Find(id);
            db.CLIENT_DETAILS.Remove(cLIENT_DETAILS);
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
