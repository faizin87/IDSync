namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppSyncOrder
    {
        public string AppSyncOrderId { get; set; }
        public string AppSyncId { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public string Order { get; set; }
        public string IsEnable { get; set; }
        public string OrganizationUnit { get; set; }
        public string IsEnableExchange { get; set; }
        public string IsEnableSkype { get; set; }
        public string IsEnableSharepoint { get; set; }
    
        public virtual AppSync AppSync { get; set; }
    }
}
