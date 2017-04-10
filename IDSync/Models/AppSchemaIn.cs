namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppSchemaIn
    {
        public string AppSchemaInId { get; set; }
        public string AppSchemaId { get; set; }
        public string QueryIn { get; set; }
        public string SchemaIn { get; set; }
        public string DataType { get; set; }
    
        public virtual AppSchema AppSchema { get; set; }
    }
}
