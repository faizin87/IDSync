namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Logs
    {
        [Key]
        public string LogId { get; set; }
        public string Type { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string SamAccountName { get; set; }
        public string Description { get; set; }
        public string Sync { get; set; }
        public string ReadBy { get; set; }
    }
}
