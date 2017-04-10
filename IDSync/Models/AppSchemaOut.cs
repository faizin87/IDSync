namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppSchemaOut
    {
        public string AppSchemaOutId { get; set; }
        public string AppSchemaId { get; set; }
        public string TableTarget { get; set; }
        public string SchemaOut { get; set; }
        public string DataType { get; set; }
    
        public virtual AppSchema AppSchema { get; set; }
    }
}
