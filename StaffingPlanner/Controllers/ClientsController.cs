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
            CLIENT_DETAILS client = db.CLIENT_DETAILS.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
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
        public ActionResult Create([Bind(Include = "CLIENT_ID,CLIENT_NAME,CLIENT_SUB_BUSINESS,CLIENT_STATUS,LAST_EDITED_BY,LAST_EDITED_DATE")] CLIENT_DETAILS client)
        {
            if (ModelState.IsValid)
            {
                db.CLIENT_DETAILS.Add(client);
				client.CLIENT_STATUS = true;
				client.LAST_EDITED_DATE = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENT_DETAILS client = db.CLIENT_DETAILS.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLIENT_ID,CLIENT_NAME,CLIENT_SUB_BUSINESS,CLIENT_STATUS,LAST_EDITED_BY,LAST_EDITED_DATE")] CLIENT_DETAILS client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
				client.CLIENT_STATUS = true;
				client.LAST_EDITED_DATE = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

		// GET: Clients/Delete/5
		public ActionResult MakeInactive(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			CLIENT_DETAILS client = db.CLIENT_DETAILS.Find(id);
			if (client == null)
			{
				return HttpNotFound();
			}
			return View(client);
		}

		// POST: Clients/Delete/5
		[HttpPost, ActionName("MakeInactive")]
		[ValidateAntiForgeryToken]
		public ActionResult MakeInactiveConfirmed(int id)
		{
			CLIENT_DETAILS client = db.CLIENT_DETAILS.Find(id);
			client.CLIENT_STATUS = false;
			db.Entry(client).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		// GET: Clients/Delete/5
		public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENT_DETAILS client = db.CLIENT_DETAILS.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENT_DETAILS client = db.CLIENT_DETAILS.Find(id);
            db.CLIENT_DETAILS.Remove(client);
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
