using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using StaffingPlanner.Models;

namespace StaffingPlanner.Controllers
{
	public class HomeController : Controller
	{
        private DEV_ClientOpportunitiesEntities db = new DEV_ClientOpportunitiesEntities();


        public ActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine("Get Index");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SIGNUP_INFO objUser)
		{
            System.Diagnostics.Debug.WriteLine("Post Index");
            if (!ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Model is valid");
                using (db)
                {
                    System.Diagnostics.Debug.WriteLine("Using DB");
                    var obj = db.SIGNUP_INFO.Where(a => a.EMAIL.Equals(objUser.EMAIL) && a.USER_PASSWORD.Equals(objUser.USER_PASSWORD)).FirstOrDefault();
                    if (obj != null)
                    {
                        System.Diagnostics.Debug.WriteLine("User exists!");
                        Session["UserID"] = obj.USER_ID.ToString();
                        Session["FirstName"] = obj.FIRSTNAME.ToString();
                        Session["LastName"] = obj.LASTNAME.ToString();
                        Session["Privilege"] = obj.USER_PRIVILEGE_ID.ToString();
                        return RedirectToAction("/");
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("User does not exist!");
            return View(objUser);
		}

        public ActionResult Logout()
        {
            System.Diagnostics.Debug.WriteLine("Logging out! Abandoning cookies");
            Session.Abandon();
            return RedirectToAction("/");
        }

        public ActionResult Report()
        {
            var oPPORTUNITY_GROUP = db.OPPORTUNITY_GROUP.Include(o => o.OPPORTUNITY_CATALOG);
            return View(oPPORTUNITY_GROUP.ToList());
        }
	}
}