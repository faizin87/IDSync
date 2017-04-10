namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Products
    {
        [Key]
        public string ProductId { get; set; }
        public string Name { get; set; }
        [Key]
        public string WebEndPoint { get; set; }
        public string Photo { get; set; }
        public string isPublish { get; set; }
    }
}
