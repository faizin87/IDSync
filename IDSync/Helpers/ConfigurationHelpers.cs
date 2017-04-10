using System;
using System.Security.Principal;
using System.Threading;

namespace IDSync.Helpers
{
    public class ConfigurationHelpers
    {
        public string Name = "";

        public static string generateID()
        {
            return Guid.NewGuid().ToString("N");
        } 
    }
}