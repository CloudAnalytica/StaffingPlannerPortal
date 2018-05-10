using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffingPlanner.Models
{
	[MetadataType(typeof(ClientDetailsMetadata))]
	public partial class CLIENT_DETAILS
	{
		[NotMapped]
		public string CLIENT_FULL_NAME { get { return this.CLIENT_NAME + " " + this.CLIENT_SUB_BUSINESS; } }
	}

	[MetadataType(typeof(ConsultantMetadata))]
	public partial class CONSULTANT
	{
	}

	[MetadataType(typeof(LostReasonMetadata))]
	public partial class LOST_REASON
	{
	}

	[MetadataType(typeof(OpportunityCatalogMetadata))]
	public partial class OPPORTUNITY_CATALOG
	{
		[NotMapped]
		public string PROJECT_NAME_IDENTIFIER { get { return getClientName(this.CLIENT_ID) + " - " + this.OPPORTUNITY_NAME; } }

		private string getClientName(int id)
		{
			DEV_ClientOpportunitiesEntities db = new DEV_ClientOpportunitiesEntities();
			var client = from c in db.CLIENT_DETAILS
								where c.CLIENT_ID == id
								select c.CLIENT_NAME;
			return client.SingleOrDefault();
		}
	}

	[MetadataType(typeof(OpportunityGroupMetadata))]
	public partial class OPPORTUNITY_GROUP
	{
	}

	[MetadataType(typeof(OpportunityStatusMetadata))]
	public partial class OPPORTUNITY_STATUS
	{
	}

	[MetadataType(typeof(SignupInfoMetadata))]
	public partial class SIGNUP_INFO
	{
	}

	[MetadataType(typeof(UserPrivilegeMetadata))]
	public partial class USER_PRIVILEGE
	{
	}
}