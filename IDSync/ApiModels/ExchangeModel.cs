using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IDSync.ApiModels
{
    public class ExchangeCalendarModel
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
    public class ExchangeMessageModel
    {
        [Key]
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; } 
        [AllowHtml]
        public string Body { get; set; }
    }
    public class ExchangeFolderModel
    {
        [Key]
        public string Id { get; set; }
        public string DisplayName { get; set; }
    }

    public class ExchangeModel
    {
        [Key]
        [Required(ErrorMessage = "SamAccountName is required")]
        [StringLength(256, MinimumLength = 0, ErrorMessage = "SamAccountName must be between 0 and 256 characters.")]
        public string SamAccountName { get; set; }
        [Required(ErrorMessage = "UserPrincipalName is required")]
        public string UserPrincipalName { get; set; }
        public string DistinguishedName { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Username { get; set; } 
        [Required(ErrorMessage = "Database is required")] 
        public string Database { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ExchangeSaveModel
    {
        [Key]
        [Required(ErrorMessage = "SamAccountName is required")]
        [StringLength(256, MinimumLength = 0, ErrorMessage = "SamAccountName must be between 0 and 256 characters.")]
        public string SamAccountName { get; set; }
        public string Database { get; set; }
    }
}
