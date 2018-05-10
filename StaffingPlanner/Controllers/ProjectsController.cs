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
    public class ProjectsController : Controller
    {
        private DEV_ClientOpportunitiesEntities db = new DEV_ClientOpportunitiesEntities();

        // GET: Projects
        public ActionResult Index()
        {
			var projectCatalog = db.OPPORTUNITY_CATALOG.Include(o => o.CLIENT_DETAILS).Include(o => o.OPPORTUNITY_STATUS1);
            return View(projectCatalog.ToList());
        }

        // GET: Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPPORTUNITY_CATALOG projectCatalog = db.OPPORTUNITY_CATALOG.Find(id);
            if (projectCatalog == null)
            {
                return HttpNotFound();
            }
            return View(projectCatalog);
        }

        // GET: Projects/Create
        public ActionResult Create()
        {
			var activeClients = from client in db.CLIENT_DETAILS
								where client.CLIENT_STATUS == true
								select client;
			ViewBag.CLIENT_ID = new SelectList(activeClients, "CLIENT_ID", "CLIENT_FULL_NAME");
            ViewBag.OPPORTUNITY_STATUS_ID = new SelectList(db.OPPORTUNITY_STATUS, "OPPORTUNITY_STATUS_ID", "OPPORTUNITY_STATUS_NAME");
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OPPORTUNITY_ID,CLIENT_ID,OPPORTUNITY_STATUS_ID,LOCATION,SPONSOR,OPPORTUNITY_NAME,OPPORTUNITY_PRACTICE,OPPORTUNITY_VALUE,OPPORTUNITY_STATUS,OPPORTUNITY_COMMENT,OPPORTUNITY_PRIORITY,OPPORTUNITY_TYPE,NUMBER_OF_REQUIRED_ROLES,LAST_EDITED_BY,LAST_EDITED_DATE")] OPPORTUNITY_CATALOG projectCatalog)
        {
            if (ModelState.IsValid)
            {
				projectCatalog.OPPORTUNITY_STATUS = true;
				projectCatalog.LAST_EDITED_DATE = DateTime.Now;
                db.OPPORTUNITY_CATALOG.Add(projectCatalog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLIENT_ID = new SelectList(db.CLIENT_DETAILS, "CLIENT_ID", "CLIENT_NAME", projectCatalog.CLIENT_ID);
            ViewBag.OPPORTUNITY_STATUS_ID = new SelectList(db.OPPORTUNITY_STATUS, "OPPORTUNITY_STATUS_ID", "OPPORTUNITY_STATUS_NAME", projectCatalog.OPPORTUNITY_STATUS_ID);
            return View(projectCatalog);
        }

        // GET: Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPPORTUNITY_CATALOG projectCatalog = db.OPPORTUNITY_CATALOG.Find(id);
            if (projectCatalog == null)
            {
                return HttpNotFound();
            }
			var activeClients = from client in db.CLIENT_DETAILS
								where client.CLIENT_STATUS == true
								select client;
			ViewBag.CLIENT_ID = new SelectList(activeClients, "CLIENT_ID", "CLIENT_FULL_NAME", projectCatalog.CLIENT_ID);
            ViewBag.OPPORTUNITY_STATUS_ID = new SelectList(db.OPPORTUNITY_STATUS, "OPPORTUNITY_STATUS_ID", "OPPORTUNITY_STATUS_NAME", projectCatalog.OPPORTUNITY_STATUS_ID);
            return View(projectCatalog);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OPPORTUNITY_ID,CLIENT_ID,OPPORTUNITY_STATUS_ID,LOCATION,SPONSOR,OPPORTUNITY_NAME,OPPORTUNITY_PRACTICE,OPPORTUNITY_VALUE,OPPORTUNITY_STATUS,OPPORTUNITY_COMMENT,OPPORTUNITY_PRIORITY,OPPORTUNITY_TYPE,NUMBER_OF_REQUIRED_ROLES,LAST_EDITED_BY,LAST_EDITED_DATE")] OPPORTUNITY_CATALOG projectCatalog)
        {
            if (ModelState.IsValid)
            {
				projectCatalog.LAST_EDITED_DATE = DateTime.Now;
				projectCatalog.OPPORTUNITY_STATUS = true;
                db.Entry(projectCatalog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLIENT_ID = new SelectList(db.CLIENT_DETAILS, "CLIENT_ID", "CLIENT_FULL_NAME", projectCatalog.CLIENT_ID);
            ViewBag.OPPORTUNITY_STATUS_ID = new SelectList(db.OPPORTUNITY_STATUS, "OPPORTUNITY_STATUS_ID", "OPPORTUNITY_STATUS_NAME", projectCatalog.OPPORTUNITY_STATUS_ID);
            return View(projectCatalog);
        }

		// GET: Projects/MakeInactive/5
		public ActionResult MakeInactive(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			OPPORTUNITY_CATALOG projectCatalog = db.OPPORTUNITY_CATALOG.Find(id);
			if (projectCatalog == null)
			{
				return HttpNotFound();
			}
			return View(projectCatalog);
		}

		// POST: Projects/MakeInactive/5
		[HttpPost, ActionName("MakeInactive")]
		[ValidateAntiForgeryToken]
		public ActionResult MakeInactiveConfirmed(int id)
		{
			OPPORTUNITY_CATALOG projectCatalog = db.OPPORTUNITY_CATALOG.Find(id);
			projectCatalog.OPPORTUNITY_STATUS = false;
			db.Entry(projectCatalog).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		//// GET: Projects/Delete/5
		//public ActionResult Delete(int? id)
  //      {
  //          if (id == null)
  //          {
  //              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
  //          }
  //          OPPORTUNITY_CATALOG projectCatalog = db.OPPORTUNITY_CATALOG.Find(id);
  //          if (projectCatalog == null)
  //          {
  //              return HttpNotFound();
  //          }
  //          return View(projectCatalog);
  //      }

  //      // POST: Projects/Delete/5
  //      [HttpPost, ActionName("Delete")]
  //      [ValidateAntiForgeryToken]
  //      public ActionResult DeleteConfirmed(int id)
  //      {
  //          OPPORTUNITY_CATALOG projectCatalog = db.OPPORTUNITY_CATALOG.Find(id);
  //          db.OPPORTUNITY_CATALOG.Remove(projectCatalog);
  //          db.SaveChanges();
  //          return RedirectToAction("Index");
  //      }

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
