namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Country
    { 
        public string CountryId { get; set; }
        public string Name { get; set; }
     
        public virtual ICollection<Province> Province { get; set; }
    }
}
