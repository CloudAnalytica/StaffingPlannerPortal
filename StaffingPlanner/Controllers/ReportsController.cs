using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using StaffingPlanner.Models;
using ClosedXML.Excel;

namespace StaffingPlanner.Controllers
{
    public class ReportsController : Controller
    {
        private DEV_ClientOpportunitiesEntities db = new DEV_ClientOpportunitiesEntities();

        // GET: Reports
        public ActionResult Index()
        {
            var opportunity = db.OPPORTUNITY_GROUP.Include(o => o.OPPORTUNITY_CATALOG);
            return View(opportunity.ToList());
        }

        public ActionResult Index2()
        {
            var opportunity = db.OPPORTUNITY_GROUP.Include(o => o.OPPORTUNITY_CATALOG);
            return View(opportunity.ToList());
        }



        public class temp
        {
            public List<ReportExportModel> data { get; set; }
        }
        /*
*Builds a reports JSON object
*and makes it available to be received by an AJAX call.
*/
        [HttpGet]
        public ActionResult ReportsData()
        {

            var opportunity = db.OPPORTUNITY_GROUP.Include(o => o.OPPORTUNITY_CATALOG);
            var reportsData = new List<ReportExportModel> { };
            
            foreach (OPPORTUNITY_GROUP opp in opportunity)
            {

                reportsData.Add(new ReportExportModel
                {
                    Account = opp.OPPORTUNITY_CATALOG.CLIENT_DETAILS.CLIENT_NAME,
                    Subbusiness = opp.OPPORTUNITY_CATALOG.CLIENT_DETAILS.CLIENT_SUB_BUSINESS,
                    ProjectName = opp.OPPORTUNITY_CATALOG.OPPORTUNITY_NAME,
                    Sponsor = opp.OPPORTUNITY_CATALOG.SPONSOR,
                    ProjectValue = opp.OPPORTUNITY_CATALOG.OPPORTUNITY_VALUE,
                    Skillset = opp.SKILLSET,
                    ProjectType = opp.OPPORTUNITY_CATALOG.OPPORTUNITY_TYPE,
                    ProjectStatus = opp.OPPORTUNITY_CATALOG.OPPORTUNITY_STATUS1.OPPORTUNITY_STATUS_NAME,
                    RateCardHr = (int) opp.RATE_CARD_PER_HR,
                    Practice = opp.OPPORTUNITY_CATALOG.OPPORTUNITY_PRACTICE,
                    MaxTargetGrade = opp.MAX_TARGET_GRADE,
                    TargetConsultant = opp.TARGETED_CONSULTANTS,
                    WorkLocation = opp.OPPORTUNITY_CATALOG.LOCATION,
                    StartDate = opp.ACTUAL_START_DATE.ToString(),
                    Duration = opp.DURATION,
                    Priority = opp.OPPORTUNITY_CATALOG.OPPORTUNITY_PRIORITY,
                    NumberOfRoles = opp.GROUP_POSITIONS_AVAILABLE,
                    AccountExecutive = opp.LAST_EDITED_BY,
                    LastEdited = opp.OPPORTUNITY_CATALOG.LAST_EDITED_DATE.ToString()

                });
            }

            var data = new temp
            {
                data = reportsData
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Reports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPPORTUNITY_GROUP opportunity = db.OPPORTUNITY_GROUP.Find(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            return View(opportunity);
        }

        // GET: Reports/Create
        public ActionResult Create()
        {
            ViewBag.OPPORTUNITY_ID = new SelectList(db.OPPORTUNITY_CATALOG, "OPPORTUNITY_ID", "LOCATION");
            return View();
        }

        // POST: Reports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GROUP_ID,OPPORTUNITY_ID,SKILLSET,OPPORTUNITY_GROUP_STATUS,GROUP_POSITIONS_AVAILABLE,MAX_TARGET_GRADE,TARGET_NEW_HIRE_GRADE,SITE,DURATION,TARGETED_CONSULTANTS,CANDIDATE_CONFIRMED,RATE_CARD_PER_HR,EXPECTED_START_DATE,ACTUAL_START_DATE,ACTUAL_END_DATE,LAST_EDITED_BY,LAST_EDITED_DATE")] OPPORTUNITY_GROUP opportunity)
        {
            if (ModelState.IsValid)
            {
                db.OPPORTUNITY_GROUP.Add(opportunity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OPPORTUNITY_ID = new SelectList(db.OPPORTUNITY_CATALOG, "OPPORTUNITY_ID", "LOCATION", opportunity.OPPORTUNITY_ID);
            return View(opportunity);
        }

        // GET: Reports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OPPORTUNITY_GROUP opportunity = db.OPPORTUNITY_GROUP.Find(id);
            if (opportunity == null)
            {
                return HttpNotFound();
            }
            ViewBag.OPPORTUNITY_ID = new SelectList(db.OPPORTUNITY_CATALOG, "OPPORTUNITY_ID", "LOCATION", opportunity.OPPORTUNITY_ID);
            return View(opportunity);
        }

        // POST: Reports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GROUP_ID,OPPORTUNITY_ID,SKILLSET,OPPORTUNITY_GROUP_STATUS,GROUP_POSITIONS_AVAILABLE,MAX_TARGET_GRADE,TARGET_NEW_HIRE_GRADE,SITE,DURATION,TARGETED_CONSULTANTS,CANDIDATE_CONFIRMED,RATE_CARD_PER_HR,EXPECTED_START_DATE,ACTUAL_START_DATE,ACTUAL_END_DATE,LAST_EDITED_BY,LAST_EDITED_DATE")] OPPORTUNITY_GROUP opportunity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opportunity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OPPORTUNITY_ID = new SelectList(db.OPPORTUNITY_CATALOG, "OPPORTUNITY_ID", "LOCATION", opportunity.OPPORTUNITY_ID);
            return View(opportunity);
        }

		//Uses collects the information from reports to add to the db. 
		public IList<ReportExportModel> GetReportList()
		{
			DEV_ClientOpportunitiesEntities db = new DEV_ClientOpportunitiesEntities();
        
			var reportList = (from opp in db.OPPORTUNITY_GROUP
							  join proj in db.OPPORTUNITY_CATALOG on opp.OPPORTUNITY_ID equals proj.OPPORTUNITY_ID
							  join status in db.OPPORTUNITY_STATUS on proj.OPPORTUNITY_STATUS_ID equals status.OPPORTUNITY_STATUS_ID
							  join client in db.CLIENT_DETAILS on proj.CLIENT_ID equals client.CLIENT_ID
							  where proj.OPPORTUNITY_STATUS == true
							  select new ReportExportModel
							  {
								  Account = client.CLIENT_NAME,
								  Subbusiness = client.CLIENT_SUB_BUSINESS,
								  ProjectName = proj.OPPORTUNITY_NAME,
								  Sponsor = proj.SPONSOR,
								  ProjectValue = (decimal)proj.OPPORTUNITY_VALUE,
								  Skillset = opp.SKILLSET,
								  ProjectType = proj.OPPORTUNITY_TYPE,
								  ProjectStatus = status.OPPORTUNITY_STATUS_NAME,
								  RateCardHr = (int)opp.RATE_CARD_PER_HR,
								  Practice = proj.OPPORTUNITY_PRACTICE,
								  MaxTargetGrade = opp.MAX_TARGET_GRADE,
								  TargetConsultant = opp.TARGET_NEW_HIRE_GRADE,
								  WorkLocation = proj.LOCATION,
								  StartDate = opp.EXPECTED_START_DATE.ToString(),
								  Duration = opp.DURATION,
								  Priority = proj.OPPORTUNITY_PRIORITY,
								  NumberOfRoles = (int)proj.NUMBER_OF_REQUIRED_ROLES,
								  AccountExecutive = opp.LAST_EDITED_BY,
								  LastEdited = opp.LAST_EDITED_DATE.ToString()
							  }).ToList();
			return reportList;
		}

		//Exports an excel file version of the reports page to be downloaded by the user.
		[HttpPost]
		public FileResult ExportToExcel()
		{
			DataTable dt = new DataTable("Grid");
			dt.Columns.AddRange(new DataColumn[18] {
						new DataColumn("Account"),
						new DataColumn("Sub-Business"),
						new DataColumn("Project Name"),
						new DataColumn("Sponsor"),
						new DataColumn("Project Value"),
						new DataColumn("Skillset"),
						new DataColumn("Project Type"),
						new DataColumn("Project Status"),
						new DataColumn("Rate Card/Hr"),
						new DataColumn("Practice"),
						new DataColumn("Max Target Grade"),
						new DataColumn("Target Consultant"),
						new DataColumn("Work Location"),
						new DataColumn("Start Date"),
						new DataColumn("Duration"),
						new DataColumn("Priority"),
						new DataColumn("# of Roles"),
						new DataColumn("AE") });
			var reportList = GetReportList();

			foreach (var report in reportList)
			{
				dt.Rows.Add(report.Account, report.Subbusiness, report.ProjectName, report.Sponsor, report.ProjectValue, report.Skillset,
					report.ProjectType, report.ProjectStatus, report.RateCardHr, report.Practice, report.MaxTargetGrade, report.TargetConsultant,
					report.WorkLocation, report.StartDate, report.Duration, report.Priority, report.NumberOfRoles, report.AccountExecutive);
			}

			using (XLWorkbook wb = new XLWorkbook())
			{
				wb.Worksheets.Add(dt);
				using (MemoryStream stream = new MemoryStream())
				{
					wb.SaveAs(stream);
					return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "OpportunityReport.xlsx");
				}
			}
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
