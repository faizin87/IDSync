namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AuthLink
    {
        public string AuthLinkId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; } 
        public virtual ICollection<AuthGroup> AuthGroup { get; set; }
    }
}
