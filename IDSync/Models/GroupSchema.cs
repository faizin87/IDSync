namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class GroupSchema
    {
        [Key]
        public string GroupSchemaId { get; set; }
        public string GroupName { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string OrganizationUnit { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public string IsEnable { get; set; }
    }
}
