using System;

namespace IDSync.ApiModels
{ 
    public class ADConfig
    {
        public string Domain { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string LDAP { get; set; }
        public string UserOU { get; set; }
        public string GroupOU { get; set; }
        public string DefaultPassword { get; set; }
        public string Extension1 { get; set; }
        public string Extension2 { get; set; }
        public string Extension3 { get; set; }
        public string Extension4 { get; set; }
        public string Extension5 { get; set; }
        public string Extension6 { get; set; }
        public string Extension7 { get; set; }
        public string Extension8 { get; set; }
        public string Extension9 { get; set; }
        public string Extension10 { get; set; }
        public string Extension11 { get; set; }
        public string Extension12 { get; set; }
        public string Extension13 { get; set; }
        public string Extension14 { get; set; }
        public string Extension15 { get; set; }
    }

    public class ExPowerShellConfig
    {
        public string Mechanism { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PowerShellURI { get; set; }
        public string PowerShellSchemaURI { get; set; }
        public string[] MailboxDatabases { get; set; }
        public string[] ArchiveDatabases { get; set; }
    }

    public class ExWebServiceConfig
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string WebService { get; set; }
    }

    public class SBConfig
    {
        public string Mechanism { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PowerShellURI { get; set; }
        public string PowerShellSchemaURI { get; set; }
        public string AddressType { get; set; }
        public string[] SIPPools { get; set; }
    }

    public class SPConfig
    {
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] Groups { get; set; }
    }

    public class FSConfig
    {
        public string Domain { get; set; }
        public string Mechanism { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
    }

}
