namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Groups
    {
        [Key]
        public string GroupId { get; set; }
        [Key]
        public string SamAccountName { get; set; }
        [Key]
        public string UserPrincipalName { get; set; }
        [Key]
        public string Name { get; set; }
        public string DistinguishedName { get; set; }
        public string GroupCategory { get; set; }
        public string GroupScope { get; set; }
        public string ObjectClass { get; set; }
        public string ObjectGUID { get; set; }
        public string SID { get; set; }
        public string Info { get; set; }
        public string Description { get; set; }
        [Key]
        public string Email { get; set; }
        public string Member { get; set; }
    }
}
