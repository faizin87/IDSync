namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class Users
    {
        [Key]
        public string UserId { get; set; }
        [Key]
        public Nullable<System.DateTime> LastLogon { get; set; }
        [Key]
        public Nullable<System.DateTime> WhenCreated { get; set; }
        [Key]
        public Nullable<System.DateTime> WhenChanged { get; set; }
        public string MsExchHomeServerName { get; set; }
        public string PrimaryUserAddress { get; set; }
        public string SIPAddress { get; set; }
        public string SIPServer { get; set; }
        [DisplayName("Country")]
        [Required(ErrorMessage = "Country is required")]
        [StringLength(3, MinimumLength = 0, ErrorMessage = "Country must be between 1 and 3 characters.")]
        public string Country { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Notes is required")]
        [StringLength(1024, MinimumLength = 1, ErrorMessage = "Notes must be between 1 and 1024 characters.")]
        public string Notes { get; set; }
        [Key]
        [Required(ErrorMessage = "EmployeeID is required")]
        [StringLength(16, MinimumLength = 0, ErrorMessage = "EmployeeID must be between 0 and 16 characters.")]
        public string EmployeeID { get; set; }
        [Required(ErrorMessage = "Company is required")]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "Company must be between 1 and 64 characters.")]
        public string Company { get; set; }
        [Key]
        [Required(ErrorMessage = "SamAccountName is required")]
        [StringLength(256, MinimumLength = 0, ErrorMessage = "SamAccountName must be between 0 and 256 characters.")]
        public string SamAccountName { get; set; }
        [Key]
        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "FirstName must be between 1 and 64 characters.")]
        public string FirstName { get; set; }
        [Key]
        [Required(ErrorMessage = "LastName is required")]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "LastName must be between 1 and 64 characters.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Office is required")]
        [StringLength(128, MinimumLength = 1, ErrorMessage = "Office must be between 1 and 128 characters.")]
        public string Office { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Street is required")]
        [StringLength(1024, MinimumLength = 1, ErrorMessage = "Street must be between 1 and 1024 characters.")]
        public string Street { get; set; }
        [Required(ErrorMessage = "PostalCode is required")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Street must be between 1 and 40 characters.")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Province is required")]
        [StringLength(128, MinimumLength = 1, ErrorMessage = "Province must be between 1 and 128 characters.")]
        public string Province { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(128, MinimumLength = 1, ErrorMessage = "City must be between 1 and 128 characters.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Website is required")]
        [StringLength(2048, MinimumLength = 1, ErrorMessage = "Website must be between 1 and 2048 characters.")]
        public string Website { get; set; }
        [Required(ErrorMessage = "Telephone is required")]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "Telephone must be between 1 and 64 characters.")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "JobTitle is required")]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "JobTitle must be between 1 and 64 characters.")]
        public string JobTitle { get; set; }
        [Key]
        [Required(ErrorMessage = "DisplayName is required")]
        [StringLength(256, MinimumLength = 0, ErrorMessage = "DisplayName must be between 0 and 256 characters.")]
        public string DisplayName { get; set; }
        [Required(ErrorMessage = "Department is required")]
        [StringLength(64, MinimumLength = 1, ErrorMessage = "Department must be between 1 and 64 characters.")]
        public string Department { get; set; }
        [Key]
        public string Manager { get; set; }
        [Required(ErrorMessage = "EmailAddress is required")]
        [StringLength(256, MinimumLength = 0, ErrorMessage = "EmailAddress must be between 0 and 256 characters.")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        public string UserPrincipalName { get; set; }
        public string Name { get; set; }
        public string DistinguishedName { get; set; }
        [Key]
        public short IsEnableSkype { get; set; }
        [Key]
        public short IsEnableExchange { get; set; }
        [Key]
        public short IsEnableSharepoint { get; set; }
        public string SharepointURL { get; set; }
        public bool IsEnable { get; set; }
        public string MemberOf { get; set; }
        public string ExtensionAttribute1 { get; set; }
        public string ExtensionAttribute2 { get; set; }
        public string ExtensionAttribute3 { get; set; }
        public string ExtensionAttribute4 { get; set; }
        public string ExtensionAttribute5 { get; set; }
        public string ExtensionAttribute6 { get; set; }
        public string ExtensionAttribute7 { get; set; }
        public string ExtensionAttribute8 { get; set; }
        public string ExtensionAttribute9 { get; set; }
        public string ExtensionAttribute10 { get; set; }
        public string ExtensionAttribute11 { get; set; }
        public string ExtensionAttribute12 { get; set; }
        public string ExtensionAttribute13 { get; set; }
        public string ExtensionAttribute14 { get; set; }
        public string ExtensionAttribute15 { get; set; }
    }
}
