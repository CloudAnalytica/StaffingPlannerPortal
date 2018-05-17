using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using StaffingPlanner.Models;

namespace StaffingPlanner.Controllers
{
    public class StatisticsController : Controller
    {
        private DEV_ClientOpportunitiesEntities db = new DEV_ClientOpportunitiesEntities();

        // GET: Statistics
        public ActionResult Index()
        {
            return View();
        }

		//public IEnumerable<LostOpportunityCount> LostOpportunities()
		//{
		//	var dataset = from r in db.LOST_REASON
		//				  select new LostOpportunityCount
		//				  {
		//					  Reason = r.REASON,
		//					  //count = db.LOST_REASON.Where(temp => temp.LOST_REASON_ID == r.LOST_REASON_ID).Select(temp => temp.OPPORTUNITY_CATALOG).Count()
		//					  Count = 5
		//				  };
		//	//ViewData["dataset"] = dataset;
		//	return dataset.AsEnumerable();
		//}

		[HttpGet]
		public ActionResult OpportunityStatusChartData()
		{
			List<object> chartData = new List<object>(3)
			{
				new object[] { "Status", "Count" },
				new object[] { "Sold", 9 },
				new object[] { "Lost Opportunity", 3 },
				new object[] {"On-Hold", 6 },
				new object[] {"Active", 4 }
			};
			return Json(chartData, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public ActionResult PortfolioChartData()
		{
			List<object> chartData = new List<object>(3)
			{
				new object[] { "Sub-business", "Amount" },
				new object[] { "Healthcare", 41 },
				new object[] { "Power", 16 },
				new object[] {"BHGE", 7 },
				new object[] {"Lighting", 6 },
				new object[] {"Life Sciences", 30 }
			};
			return Json(chartData, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public ActionResult ProfitChartData()
		{
			List<object> chartData = new List<object>(3)
			{
				new object[] { "Quarter", "Amount" },
				new object[] { "Q1", 1 },
				new object[] { "Q2", 2.8 },
				new object[] {"Q3", 4.1 },
				new object[] {"Q4", 5.2 }
			};
			return Json(chartData, JsonRequestBehavior.AllowGet);
		}

		[HttpGet]
		public ActionResult LostOpportunityChartData()
		{
			//System.Diagnostics.Debug.WriteLine("Inside LostOppChartData Function");
			//var res = from r in db.LOST_REASON
			//		  select r;
			//IList<LOST_REASON> result = res.ToList();
			//List<object> chartData = new List<object>();
			//chartData.Add(new object[] { "Reason", "Count" });
			//foreach (var i in result)
			//{
			//	System.Diagnostics.Debug.WriteLine(i.REASON);
			//	chartData.Add(new object[] { i.REASON, 5 });
			//}
			List<object> chartData = new List<object>(3)
			{
				new object[] { "Reason", "Count" },
				new object[] { "High Bill Rate", 10 },
				new object[] { "Deadline Miss", 3 },
				new object[] {"Recruitment Delay", 7 },
				new object[] {"No Candidate", 2 },
				new object[] {"No Help From Practice", 5 }
			};
			//string output = new JavaScriptSerializer().Serialize(chartData);
			//System.Diagnostics.Debug.WriteLine("Moved past the serialization");
			//List<LostReasonRow> data = new List<LostReasonRow>();
			//data.Add(new LostReasonRow("Test", 4));
			//data.Add(new LostReasonRow("Test Again", 5));
			//foreach (LostReasonRow lrr in data)
			//{
			//	System.Diagnostics.Debug.WriteLine(lrr.Reason + " " + lrr.Count);
			//}
			return Json(chartData, JsonRequestBehavior.AllowGet);
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

	public class LostReasonRow {
		public string Reason { get; set; }
		public int Count { get; set; }
		public LostReasonRow(string str, int count)
		{
			this.Reason = str;
			this.Count = count;
		}
	}
}
