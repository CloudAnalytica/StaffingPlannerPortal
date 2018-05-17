using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StaffingPlanner.Models
{
	public class ClientDetailsMetadata
	{
		[Key]
		[Required]
		[Display(Name = "Account ID")]
		public int CLIENT_ID;

		[Required]
		[Display(Name = "Account Name")]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Must be between 2 - 50 characters.")]
		public string CLIENT_NAME;

		[Display(Name = "Sub-Business")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Cannot be more than 50 characters.")]
		public string CLIENT_SUB_BUSINESS;

		[Required]
		[Display(Name = "Status")]
		public bool CLIENT_STATUS;

		
		[Display(Name = "AE")]
		[StringLength(50, MinimumLength = 4, ErrorMessage = "Must be between 4 - 50 characters.")]
		public string LAST_EDITED_BY;

		[Required]
		[Display(Name = "Last Edited On")]
		public System.DateTime LAST_EDITED_DATE;
	}

	public class ConsultantMetadata
	{
		[Key]
		[Required]
		[Display(Name = "Consultant ID")]
		public int CONSULTANT_ID;

		[Required]
		[Display(Name = "Consultant Name")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Cannot be more than 50 characters.")]
		public string CONSULTANT_NAME;

		[Display(Name = "Practice")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Cannot be more than 50 characters.")]
		public string CONSULTANT_PRACTICE;

		[Display(Name = "Sogeti Start Date")]
		[DataType(DataType.Date)]
		public Nullable<System.DateTime> SOGETI_START_DATE;

		[Required]
		[Display(Name = "Status")]
		public bool CONSULTANT_EMPLOYMENT_STATUS;

		
		[Display(Name = "AE")]
		[StringLength(50, MinimumLength = 4, ErrorMessage = "Must be between 4 - 50 characters.")]
		public string LAST_EDITED_BY;

		[Required]
		[Display(Name = "Last Edited On")]
		public System.DateTime LAST_EDITED_DATE;
	}

	public class LostReasonMetadata
	{
		[Key]
		[Required]
		[Display(Name = "Lost Reason Id")]
		public int LOST_REASON_ID;

		[Required]
		[Display(Name = "Reason")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Cannot be more than 50 characters.")]
		public string REASON;
	}

	public class OpportunityCatalogMetadata
	{
		[Key]
		[Required]
		[Display(Name = "Project ID")]
		public int OPPORTUNITY_ID;

		[Required]
		[Display(Name = "Account ID")]
		public int CLIENT_ID;

		[Required]
		[Display(Name = "Project Status Id")]
		public int OPPORTUNITY_STATUS_ID;

		[Required]
		[Display(Name = "Location")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Cannot be more than 50 characters.")]
		public string LOCATION;

		[Required]
		[Display(Name = "Sponsor")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Cannot be more than 50 characters.")]
		public string SPONSOR;

		[Required]
		[Display(Name = "Project Name")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Cannot be more than 50 characters.")]
		public string OPPORTUNITY_NAME;

		[Required]
		[Display(Name = "Project Practice")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Cannot be more than 50 characters.")]
		public string OPPORTUNITY_PRACTICE;

		[Display(Name = "Project Value")]
		[RangeAttribute(typeof(decimal), "0.00", "1000000000.00", ErrorMessage = "Value must be between 0 - 1000000000.00")]
		public Nullable<decimal> OPPORTUNITY_VALUE;

		[Required]
		[Display(Name = "Status")]
		public bool OPPORTUNITY_STATUS;

		[Display(Name = "Comment")]
		[StringLength(8000, MinimumLength = 0, ErrorMessage = "Cannot be more than 8000 characters.")]
		public string OPPORTUNITY_COMMENT;

		[Display(Name = "Priority Level")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Cannot be more than 50 characters.")]
		public string OPPORTUNITY_PRIORITY;

		[Display(Name = "Project Type")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Cannot be more than 50 characters.")]
		public string OPPORTUNITY_TYPE;

		[Display(Name = "# of Required Roles")]
		[RangeAttribute(typeof(int), "1", "100", ErrorMessage = "Must be a number between 1-100.")]
		public Nullable<int> NUMBER_OF_REQUIRED_ROLES;

		
		[Display(Name = "AE")]
		[StringLength(50, MinimumLength = 4, ErrorMessage = "Must be between 4 - 50 characters.")]
		public string LAST_EDITED_BY;

		[Required]
		[Display(Name = "Last Edited On")]
		public System.DateTime LAST_EDITED_DATE;
	}

	public class OpportunityGroupMetadata
	{
		[Key]
		[Required]
		[Display(Name = "Opportunity Group ID")]
		public int GROUP_ID;

		[Required]
		[Display(Name = "Project ID")]
		public int OPPORTUNITY_ID;

		[Required]
		[Display(Name = "Required Skills")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Cannot be more than 50 characters.")]
		public string SKILLSET;

		[Required]
		[Display(Name = "Status")]
		public bool OPPORTUNITY_GROUP_STATUS;

		[Required]
		[Display(Name = "Positions Needed")]
		[RangeAttribute(typeof(int), "1", "100", ErrorMessage = "Must be a number between 1 - 100.")]
		public int GROUP_POSITIONS_AVAILABLE;

		[Display(Name = "Max Hire Grade")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Cannot be more than 50 characters.")]
		public string MAX_TARGET_GRADE;

		[Display(Name = "Targeted Hire Grade")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Cannot be more than 50 characters.")]
		public string TARGET_NEW_HIRE_GRADE;

		[Display(Name = "Site")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Cannot be more than 50 characters.")]
		public string SITE;

		[Display(Name = "Duration")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Cannot be more than 50 characters.")]
		public string DURATION;

		[Display(Name = "Targeted Consultants")]
		[StringLength(50, MinimumLength = 0, ErrorMessage = "Cannot be more than 8000 characters.")]
		public string TARGETED_CONSULTANTS;

		[Display(Name = "Candidate Confimed")]
		public Nullable<bool> CANDIDATE_CONFIRMED;

		[Required]
		[Display(Name = "Rate Card Per Hour")]
		[RangeAttribute(typeof(int), "0", "1000000000", ErrorMessage = "Value must be between 0 - 1000000000")]
		public int RATE_CARD_PER_HR;

		[Display(Name = "Expected Start Date")]
		[DataType(DataType.Date)]
		public Nullable<System.DateTime> EXPECTED_START_DATE;

		[Display(Name = "Actual Start Date")]
		[DataType(DataType.Date)]
		public Nullable<System.DateTime> ACTUAL_START_DATE;

		[Display(Name = "End Date")]
		[DataType(DataType.Date)]
		public Nullable<System.DateTime> ACTUAL_END_DATE;

		
		[Display(Name = "AE")]
		[StringLength(50, MinimumLength = 4, ErrorMessage = "Must be between 4 - 50 characters.")]
		public string LAST_EDITED_BY;

		[Required]
		[Display(Name = "Last Edited On")]
		public System.DateTime LAST_EDITED_DATE;
	}

	public class OpportunityStatusMetadata
	{
		[Key]
		[Required]
		[Display(Name = "Project Status ID")]
		public int OPPORTUNITY_STATUS_ID;

		[Required]
		[Display(Name = "Project Status")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Cannot be more than 50 characters.")]
		public string OPPORTUNITY_STATUS_NAME;
	}

	public class SignupInfoMetadata
	{
		[Key]
		[Required]
		[Display(Name = "User ID")]
		public int USER_ID;

		[Required]
		[Display(Name = "User Privilege ID")]
		public int USER_PRIVILEGE_ID;

		[Required]
		[Display(Name = "Username")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Cannot be more than 50 characters.")]
		public string USERNAME;

		[Required]
		[Display(Name = "Password")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Cannot be more than 50 characters.")]
		public string USER_PASSWORD;

		[Required]
		[Display(Name = "Email")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Cannot be more than 50 characters.")]
		public string EMAIL;

		[Required]
		[Display(Name = "First Name")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Cannot be more than 50 characters.")]
		public string FIRSTNAME;

		[Required]
		[Display(Name = "Last Name")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Cannot be more than 50 characters.")]
		public string LASTNAME;


		[Display(Name = "Status")]
		public Nullable<bool> USER_STATUS;


		[Display(Name = "Last Logon")]
		public Nullable<System.DateTime> LAST_LOGON;
	}

	public class UserPrivilegeMetadata
	{
		[Key]
		[Required]
		[Display(Name = "User Privilege ID")]
		public int USER_PRIVILEGE_ID;

		[Required]
		[Display(Name = "User Privilege Name")]
		[StringLength(50, MinimumLength = 1, ErrorMessage = "Cannot be more than 50 characters.")]
		public string USER_PRIVILEGE_NAME;
	}

}