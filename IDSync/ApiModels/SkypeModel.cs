using System.ComponentModel.DataAnnotations; 

namespace IDSync.ApiModels
{
    public class SkypeModel
    {
        [Key]
        [Required(ErrorMessage = "SamAccountName is required")]
        [StringLength(256, MinimumLength = 0, ErrorMessage = "SamAccountName must be between 0 and 256 characters.")]
        public string SamAccountName { get; set; } 
        public string DisplayName { get; set; }
        public string UserPrincipalName { get; set; }
        public string DistinguishedName { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string RegistrarPool { get; set; }
    }
}
