using IDSync.ApiModels;
using IDSync.DAL;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers; 
using System.Threading.Tasks; 

namespace IDSync.Helpers
{
    public class AuthHelpers
    {
        
        public static async Task<ActiveDirectoryModel> GetUserByUserPrincipalName(string Upn)
        { 
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/"+Upn+"/GetUserByUserPrincipalName";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));
            HttpResponseMessage response = await client.GetAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                ActiveDirectoryModel model = await response.Content.ReadAsAsync<ActiveDirectoryModel>();
                return  model;
            }
            return null;
        }
        public static bool IsMember(string Group)
        {
            String currentApp = Startup.application.ToLower();
            var getClaimGroup = ClaimsHelpers.getGroups().Where(x => x.Name.ToLower().Equals(currentApp+" "+Group.ToLower()));
            if(getClaimGroup.Count() > 0) {
                return true;
            }
            return false;
        }

        public static bool IsAdmin()
        {
            String currentApp = Startup.application.ToLower();
            var getClaimGroup = ClaimsHelpers.getGroups().Where(x => x.Name.ToLower().Equals(currentApp + " administrator"));
            if (getClaimGroup.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public static bool IsAllow(string link)
        {
            Dal db = new Dal();
            if (IsAdmin())
            {
                return true;
            }
            else
            {
                var getClaimGroup = ClaimsHelpers.getGroups();
                foreach (var g in getClaimGroup)
                {
                    var AuthGroup = from s in db.AuthGroup
                                    where s.Name.Equals(g.Name) && s.AuthLink.Link.Equals(link)
                                    select s;
                    if (AuthGroup.Count() > 0)
                    {
                        return true;
                    }
                }

            } 
            return false; 
        }
         
    }
}