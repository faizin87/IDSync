namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppSchema
    { 
    
        public string AppSchemaId { get; set; }
        public string AppId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    
        public virtual App App { get; set; } 
        public virtual ICollection<AppSamAccountName> AppSamAccountName { get; set; } 
        public virtual ICollection<AppSchemaIn> AppSchemaIn { get; set; } 
        public virtual ICollection<AppSchemaOut> AppSchemaOut { get; set; }
    }
}
