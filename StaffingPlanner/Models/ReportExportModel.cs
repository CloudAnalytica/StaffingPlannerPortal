using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaffingPlanner.Models
{
	public class ReportExportModel
	{
		public string Account { get; set; }
		public string Subbusiness { get; set; }
		public string ProjectName { get; set; }
		public string Sponsor { get; set; }
		public decimal ProjectValue { get; set; }
		public string Skillset { get; set; }
		public string ProjectType { get; set; }
		public string ProjectStatus { get; set; }
		public int RateCardHr { get; set; }
		public string Practice { get; set; }
		public string MaxTargetGrade { get; set; }
		public string TargetConsultant { get; set; }
		public string WorkLocation { get; set; }
		public string StartDate { get; set; }
		public string Duration { get; set; }
		public string Priority { get; set; }
		public int NumberOfRoles { get; set; }
		public string AccountExecutive { get; set; }
		public string LastEdited { get; set; }
	}
}