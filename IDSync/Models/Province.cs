
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IDSync.Models
{ 
    public partial class Province
    {
        [Key]
        public string ProvinceId { get; set; } 
        public string CountryId { get; set; }
        public string Name { get; set; } 
        public virtual ICollection<City> City { get; set; }
        public virtual Country Country { get; set; }
    }
}
