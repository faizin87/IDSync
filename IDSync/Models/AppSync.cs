namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppSync
    { 
        public string AppSyncId { get; set; }
        public string Name { get; set; }
     
        public virtual ICollection<AppSyncOrder> AppSyncOrder { get; set; }
    }
}
