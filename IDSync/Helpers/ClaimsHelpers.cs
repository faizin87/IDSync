using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace IDSync.Helpers
{
    public class ClaimsHelpers
    {

        public static string getName() {
            var principal = (HttpContext.Current.User as System.Security.Claims.ClaimsPrincipal).Claims;
            foreach (var claim in principal)
            {

                if (claim.Type.Replace("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/", "") == "name")
                {
                    return claim.Value;
                }
            }
            return "";
        }

        public static string getUPN()
        {
            var principal = (HttpContext.Current.User as System.Security.Claims.ClaimsPrincipal).Claims;
            foreach (var claim in principal)
            {

                if (claim.Type.Replace("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/", "") == "upn")
                {
                    return claim.Value;
                }
            }
            return "";
        }

        public static List<initGroup> getGroups()
        {
            List<initGroup> initGroups = new List<initGroup>();
            var principal = (HttpContext.Current.User as System.Security.Claims.ClaimsPrincipal).Claims;
            foreach (var claim in principal.Where(x => x.Type.ToLower().Contains("group")))
            {
                initGroups.Add(new initGroup { Name = claim.Value }); 
            }
            return initGroups;
        }
        public static async Task<string> GetToken()
        {

            var tokenServiceUrl = Startup.apiUrl + "Token";
            var client = new HttpClient();
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("username", Startup.apiUser));
            keyValues.Add(new KeyValuePair<string, string>("password", Startup.apiPassword));
            keyValues.Add(new KeyValuePair<string, string>("grant_type", Startup.apiGrantType));
            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsAsync<TokenModel>();
                return token.access_token;
            }
            return tokenServiceUrl;
        }

    }
    public class TokenModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string expires_in { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string token_type { get; set; }
    }
    public class initGroup{
        public string Name { get; set; }
    }
}