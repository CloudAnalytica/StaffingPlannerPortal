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
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

        public ActionResult Report()
        {
            var oPPORTUNITY_GROUP = db.OPPORTUNITY_GROUP.Include(o => o.OPPORTUNITY_CATALOG);
            return View(oPPORTUNITY_GROUP.ToList());
        }
	}
}