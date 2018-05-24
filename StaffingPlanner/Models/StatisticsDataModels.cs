/*
 * Author: Zoe
 * Purpose: These Objects are used in the StatisticsController.cs to hold the information comming in from the 
 *			statistics chart stored procedures.
 */

namespace StaffingPlanner.Models
{
	/*
	 * Used with stored procedure: STATS_OPPORTUNITY_STATUS
	 */
	public class OpportunityStatusStats
	{
		public string Opportunity_Status_Name { get; set; }
		public int Status_Count { get; set; }
	}

	/*
	 * Used with stored procedure: STATS_LOST_OPPORTUNITY
	 */
	public class LostOpportunityStats
	{
		public string Reason { get; set; }
		public int Reason_Count { get; set; }
	}

	/*
	 * Used with stored procedure: STATS_PORTFOLIO
	 */
	public class PortfolioStats
	{
		public string Client { get; set; }
		public decimal Value { get; set; }
	}

	/*
	 * Used with stored procedure: STATS_PROJECTED_PROFIT
	 */
	public class ProjectedProfitStats
	{
		public int Quarter { get; set; }
		public decimal Value { get; set; }
	}
}