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
            return View(LostOpportunityChartData());
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

		[System.Web.Mvc.HttpGet]
		public ActionResult LostOpportunityChartData()
		{
			System.Diagnostics.Debug.WriteLine("Inside LostOppChartData Function");
			//var res = from r in db.LOST_REASON
			//			 select r;
			//IList<LOST_REASON> result = res.ToList();
			//var chartData = new object[result.Count + 1];
			//chartData[0] = new object[]{
			//	"Reason",
			//	"Count"
			//};
			//int j = 0;
			//foreach (var i in result)
			//{
			//	j++;
			//	chartData[j] = new object[] { i.REASON, 5 };
			//}
			List<object> chartData = new List<object>(3)
			{
				new object[] { "Reason", "Count" },
				new object[] { "One", 5 },
				new object[] { "Two", 4 }
			};
			string output = new JavaScriptSerializer().Serialize(chartData);
			System.Diagnostics.Debug.WriteLine("Moved past the serialization");
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
