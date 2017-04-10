namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AuthGroup
    {
        public string AuthGroupId { get; set; }
        public string Name { get; set; }
        public string AuthLinkId { get; set; }
    
        public virtual AuthLink AuthLink { get; set; }
    }
}
