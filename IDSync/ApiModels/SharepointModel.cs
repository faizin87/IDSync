using System; 
using System.ComponentModel.DataAnnotations; 
using System.Web.Mvc;

namespace IDSync.ApiModels
{
    public class SharePointCalendarModel
    {
        [Key]
        public string Id { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Subject { get; set; }
        [AllowHtml]
        public string Body { get; set; }
    }

    public class SharePointModel
    {
        [Key]
        [Required(ErrorMessage = "SamAccountName is required")]
        [StringLength(256, MinimumLength = 0, ErrorMessage = "SamAccountName must be between 0 and 256 characters.")]
        public string SamAccountName { get; set; }
        public string DisplayName { get; set; }
        public string UserPrincipalName { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string DistinguishedName { get; set; }
        [Required(ErrorMessage = "SharepointURL is required")]
        public string SharepointURL { get; set; }
        [Required(ErrorMessage = "Group is required")]
        public string Group { get; set; }
    }
}
