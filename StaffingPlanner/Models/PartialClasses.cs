using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StaffingPlanner.Models
{
	[MetadataType(typeof(ClientDetailsMetadata))]
	public partial class CLIENT_DETAILS
	{
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