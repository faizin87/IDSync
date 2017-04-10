namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TmpPosition
    {
        [Key]
        public string TmpPositionId { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
    }
}
