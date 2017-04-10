namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppSamAccountName
    {
        public string AppSamAccountNameId { get; set; }
        public string AppSchemaSchemaId { get; set; }
        public string RuleIn { get; set; }
        public string TypeIn { get; set; }
        public string NumIn { get; set; }
        public string RuleOut { get; set; }
        public string TypeOut { get; set; }
        public string NumOut { get; set; }
    
        public virtual AppSchema AppSchema { get; set; }
    }
}
