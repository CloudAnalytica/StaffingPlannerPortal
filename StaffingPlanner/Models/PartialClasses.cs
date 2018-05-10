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