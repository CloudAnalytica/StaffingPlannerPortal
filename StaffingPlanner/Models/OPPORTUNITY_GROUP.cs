//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StaffingPlanner.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OPPORTUNITY_GROUP
    {
        public int GROUP_ID { get; set; }
        public int OPPORTUNITY_ID { get; set; }
        public string SKILLSET { get; set; }
        public bool OPPORTUNITY_GROUP_STATUS { get; set; }
        public int GROUP_POSITIONS_AVAILABLE { get; set; }
        public string MAX_TARGET_GRADE { get; set; }
        public string TARGET_NEW_HIRE_GRADE { get; set; }
        public string SITE { get; set; }
        public string DURATION { get; set; }
        public string TARGETED_CONSULTANTS { get; set; }
        public Nullable<bool> CANDIDATE_CONFIRMED { get; set; }
        public Nullable<int> RATE_CARD_PER_HR { get; set; }
        public Nullable<System.DateTime> EXPECTED_START_DATE { get; set; }
        public Nullable<System.DateTime> ACTUAL_START_DATE { get; set; }
        public Nullable<System.DateTime> ACTUAL_END_DATE { get; set; }
        public string LAST_EDITED_BY { get; set; }
        public System.DateTime LAST_EDITED_DATE { get; set; }
        public Nullable<decimal> OPPORTUNITY_VALUE { get; set; }
        public string OPPORTUNITY_PRIORITY { get; set; }
    
        public virtual OPPORTUNITY_CATALOG OPPORTUNITY_CATALOG { get; set; }
    }
}
