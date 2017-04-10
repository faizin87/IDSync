namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class City
    {
        public string CityId { get; set; }
        public string ProvinceId { get; set; }
        public string Name { get; set; }
    
        public virtual Province Province { get; set; }
    }
}
