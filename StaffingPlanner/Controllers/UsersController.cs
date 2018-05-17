using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StaffingPlanner.Models;

namespace StaffingPlanner.Views
{
    public class UsersController : Controller
    {
        private DEV_ClientOpportunitiesEntities db = new DEV_ClientOpportunitiesEntities();

        // GET: Users
        public ActionResult Index()
        {
            var sIGNUP_INFO = db.SIGNUP_INFO.Include(s => s.USER_PRIVILEGE);
            return View(sIGNUP_INFO.ToList());
        }





        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIGNUP_INFO sIGNUP_INFO = db.SIGNUP_INFO.Find(id);
            if (sIGNUP_INFO == null)
            {
                return HttpNotFound();
            }
            return View(sIGNUP_INFO);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.USER_PRIVILEGE_ID = new SelectList(db.USER_PRIVILEGE, "USER_PRIVILEGE_ID", "USER_PRIVILEGE_NAME");
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "USER_ID,USER_PRIVILEGE_ID,USERNAME,USER_PASSWORD,EMAIL,FIRSTNAME,LASTNAME,USER_STATUS,LAST_LOGON")] SIGNUP_INFO sIGNUP_INFO)
        {
            if (ModelState.IsValid)
            {
                db.SIGNUP_INFO.Add(sIGNUP_INFO);
                sIGNUP_INFO.USER_PRIVILEGE_ID = 6;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USER_PRIVILEGE_ID = new SelectList(db.USER_PRIVILEGE, "USER_PRIVILEGE_ID", "USER_PRIVILEGE_NAME", sIGNUP_INFO.USER_PRIVILEGE_ID);
            return View(sIGNUP_INFO);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIGNUP_INFO sIGNUP_INFO = db.SIGNUP_INFO.Find(id);
            if (sIGNUP_INFO == null)
            {
                return HttpNotFound();
            }
            ViewBag.USER_PRIVILEGE_ID = new SelectList(db.USER_PRIVILEGE, "USER_PRIVILEGE_ID", "USER_PRIVILEGE_NAME", sIGNUP_INFO.USER_PRIVILEGE_ID);
            return View(sIGNUP_INFO);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "USER_ID,USER_PRIVILEGE_ID,USERNAME,USER_PASSWORD,EMAIL,FIRSTNAME,LASTNAME,USER_STATUS,LAST_LOGON")] SIGNUP_INFO sIGNUP_INFO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sIGNUP_INFO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USER_PRIVILEGE_ID = new SelectList(db.USER_PRIVILEGE, "USER_PRIVILEGE_ID", "USER_PRIVILEGE_NAME", sIGNUP_INFO.USER_PRIVILEGE_ID);
            return View(sIGNUP_INFO);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SIGNUP_INFO sIGNUP_INFO = db.SIGNUP_INFO.Find(id);
            if (sIGNUP_INFO == null)
            {
                return HttpNotFound();
            }
            return View(sIGNUP_INFO);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SIGNUP_INFO sIGNUP_INFO = db.SIGNUP_INFO.Find(id);
            db.SIGNUP_INFO.Remove(sIGNUP_INFO);
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
