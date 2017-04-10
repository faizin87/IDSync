namespace IDSync.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class App
    { 
        public string AppId { get; set; }
        public string Name { get; set; }
        public string DbType { get; set; }
        public string Server { get; set; }
        public string SID { get; set; }
        public string Port { get; set; }
        public string DbName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string IsReadOnly { get; set; }
        public virtual ICollection<AppSchema> AppSchema { get; set; }
    }
}
