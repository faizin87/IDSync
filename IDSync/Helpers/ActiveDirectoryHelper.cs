using IDSync.ApiModels; 
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers; 
using System.Threading.Tasks;

namespace IDSync.Helpers
{
    public static partial class ActiveDirectoryHelper
    {
        public static async Task<string> RemoveUserFromGroup(string userDn, string groupDn)
        {
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/RemoveUserFromGroup";
            var client = new HttpClient();
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("userDn", userDn));
            keyValues.Add(new KeyValuePair<string, string>("groupDn", groupDn));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Error";
        }
        public static async Task<string> AddUserToGroup(string userDn, string groupDn, string DistinguishedName)
        { 
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/"+ DistinguishedName + "/AddUserToGroup";
            var client = new HttpClient();
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("userDn", userDn));
            keyValues.Add(new KeyValuePair<string, string>("groupDn", groupDn));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Error";
        }

        public static async Task<string> AddGroupMember(string userDn, string groupDn)
        { 
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/AddMemberGroup";
            var client = new HttpClient();
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("userDn", userDn));
            keyValues.Add(new KeyValuePair<string, string>("groupDn", groupDn));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Error";
        }

        public static async Task<List<initGroup>> GetUserGroupsByUserPrincipalName(string Upn)
        {
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/"+ Upn + "/GroupMembers";
            var client = new HttpClient(); 
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token")); 

            HttpResponseMessage response = await client.GetAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                string[] dataGroups = (await response.Content.ReadAsStringAsync()).Split('#');
                List<initGroup> initGroups = new List<initGroup>(); 
                foreach (var group in dataGroups)
                {
                    initGroups.Add(new initGroup { Name = group });
                }
                return initGroups;
            }
            return null;
        }

        public static async Task<ArrayList> EnumerateOU()
        {
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/GetListOU";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            HttpResponseMessage response = await client.GetAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                ArrayList dataOU = await response.Content.ReadAsAsync<ArrayList>();
                return dataOU;
            }
            return null;
        }

        public static async Task<ArrayList> EnumerateOUChild(string OU)
        {
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/"+ OU + "/GetListChildOU";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            HttpResponseMessage response = await client.GetAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                ArrayList dataOU = await response.Content.ReadAsAsync<ArrayList>();
                return dataOU;
            }
            return null;
        }
        public static async Task<IEnumerable<ActiveDirectoryModel>> GetAll(string distinguishedName, string sortOrder, string currentFilter, string searchString, int? page)
        { 
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/"+ page + "/GetAllUsers?DistinguishedName="+distinguishedName+"&sortOrder="+sortOrder+"&currentFilter="+currentFilter+"&searchString="+searchString;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            HttpResponseMessage response = await client.GetAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<ActiveDirectoryModel> dataAd = await response.Content.ReadAsAsync<IEnumerable<ActiveDirectoryModel>>();
                return dataAd;
            }
            return null;
        }

        public static async Task<IEnumerable<GroupModel>> GetListGroup(string DistinguishedName, string SamAccountName)
        {
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/"+DistinguishedName+"/"+SamAccountName+"/GetAllGroups";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            HttpResponseMessage response = await client.GetAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<GroupModel> dataGroups = await response.Content.ReadAsAsync<IEnumerable<GroupModel>>();
                return dataGroups;
            }
            return null;
        }

        public static async Task<IEnumerable<GroupModel>> GetDetailGroup(string SamAccountName)
        {
            //api/v1/Ad/{SamAccountName}/GetDetailGroup
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/"+SamAccountName+"/GetDetailGroup";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            HttpResponseMessage response = await client.GetAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<GroupModel> dataGroups = await response.Content.ReadAsAsync<IEnumerable<GroupModel>>();
                return dataGroups;
            }
            return null;
        }

        public static async Task<string> GroupCreate(GroupCreateModel Model, string distinguaseName)
        { 
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/GroupCreate?distinguaseName="+ distinguaseName;
            var client = new HttpClient();
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("Name", Model.Name));
            keyValues.Add(new KeyValuePair<string, string>("Description", Model.Description));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Error";
        }

        public static async Task<string> GroupEdit(GroupModel Model, string oldName, string distinguaseName)
        {
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/"+oldName+"/GroupEdit?distinguishedName=" + distinguaseName;
            var client = new HttpClient();
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("Name", Model.Name));
            keyValues.Add(new KeyValuePair<string, string>("Description", Model.Description));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.PutAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Error";
        }

        public static async Task<string> Post(MinimumActiveDirectoryModel Model)
        {
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/SimplePost";
            var client = new HttpClient();
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("SamAccountName", Model.SamAccountName));
            keyValues.Add(new KeyValuePair<string, string>("FirstName", Model.FirstName));
            keyValues.Add(new KeyValuePair<string, string>("LastName", Model.LastName));
            keyValues.Add(new KeyValuePair<string, string>("Password", Model.Password));
            keyValues.Add(new KeyValuePair<string, string>("DisplayName", Model.DisplayName));
            keyValues.Add(new KeyValuePair<string, string>("EmailAddress", Model.EmailAddress));
            keyValues.Add(new KeyValuePair<string, string>("UserPrincipalName", Model.UserPrincipalName));
            keyValues.Add(new KeyValuePair<string, string>("Name", Model.Name));
            keyValues.Add(new KeyValuePair<string, string>("DistinguishedName", Model.DistinguishedName)); 

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Error";
        }

        public static async Task<string> PostAdvance(ActiveDirectoryModel Model)
        {
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/PostAdvance";
            var client = new HttpClient();
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("Country", Model.Country));
            keyValues.Add(new KeyValuePair<string, string>("Notes", Model.Notes));
            keyValues.Add(new KeyValuePair<string, string>("EmployeeID", Model.EmployeeID));
            keyValues.Add(new KeyValuePair<string, string>("Company", Model.Company));
            keyValues.Add(new KeyValuePair<string, string>("SamAccountName", Model.SamAccountName));
            keyValues.Add(new KeyValuePair<string, string>("FirstName", Model.FirstName));
            keyValues.Add(new KeyValuePair<string, string>("LastName", Model.LastName));
            keyValues.Add(new KeyValuePair<string, string>("Office", Model.Office));
            keyValues.Add(new KeyValuePair<string, string>("Password", Model.Password));
            keyValues.Add(new KeyValuePair<string, string>("Street", Model.Street));
            keyValues.Add(new KeyValuePair<string, string>("PostalCode", Model.PostalCode));
            keyValues.Add(new KeyValuePair<string, string>("Province", Model.Province));
            keyValues.Add(new KeyValuePair<string, string>("City", Model.City));
            keyValues.Add(new KeyValuePair<string, string>("Website", Model.Website));
            keyValues.Add(new KeyValuePair<string, string>("Telephone", Model.Telephone));
            keyValues.Add(new KeyValuePair<string, string>("JobTitle", Model.JobTitle));
            keyValues.Add(new KeyValuePair<string, string>("DisplayName", Model.DisplayName));
            keyValues.Add(new KeyValuePair<string, string>("Department", Model.Department));
            keyValues.Add(new KeyValuePair<string, string>("EmailAddress", Model.EmailAddress));
            keyValues.Add(new KeyValuePair<string, string>("UserPrincipalName", Model.UserPrincipalName)); 
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute1", Model.ExtensionAttribute1));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute2", Model.ExtensionAttribute2));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute3", Model.ExtensionAttribute3));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute4", Model.ExtensionAttribute4));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute5", Model.ExtensionAttribute5));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute6", Model.ExtensionAttribute6));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute7", Model.ExtensionAttribute7));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute8", Model.ExtensionAttribute8));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute9", Model.ExtensionAttribute9));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute10", Model.ExtensionAttribute10));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute11", Model.ExtensionAttribute11));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute12", Model.ExtensionAttribute12));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute13", Model.ExtensionAttribute13));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute14", Model.ExtensionAttribute14));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute15", Model.ExtensionAttribute15)); 

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Error";
        }

        public static async Task<string> EditAdvance(ActiveDirectoryModel Model)
        {
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/EditAdvance";
            var client = new HttpClient();
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("Country", Model.Country));
            keyValues.Add(new KeyValuePair<string, string>("Notes", Model.Notes));
            keyValues.Add(new KeyValuePair<string, string>("EmployeeID", Model.EmployeeID));
            keyValues.Add(new KeyValuePair<string, string>("Company", Model.Company));
            keyValues.Add(new KeyValuePair<string, string>("SamAccountName", Model.SamAccountName));
            keyValues.Add(new KeyValuePair<string, string>("FirstName", Model.FirstName));
            keyValues.Add(new KeyValuePair<string, string>("LastName", Model.LastName));
            keyValues.Add(new KeyValuePair<string, string>("Office", Model.Office));
            keyValues.Add(new KeyValuePair<string, string>("Password", Model.Password));
            keyValues.Add(new KeyValuePair<string, string>("Street", Model.Street));
            keyValues.Add(new KeyValuePair<string, string>("PostalCode", Model.PostalCode));
            keyValues.Add(new KeyValuePair<string, string>("Province", Model.Province));
            keyValues.Add(new KeyValuePair<string, string>("City", Model.City));
            keyValues.Add(new KeyValuePair<string, string>("Website", Model.Website));
            keyValues.Add(new KeyValuePair<string, string>("Telephone", Model.Telephone));
            keyValues.Add(new KeyValuePair<string, string>("JobTitle", Model.JobTitle));
            keyValues.Add(new KeyValuePair<string, string>("DisplayName", Model.DisplayName));
            keyValues.Add(new KeyValuePair<string, string>("Department", Model.Department));
            keyValues.Add(new KeyValuePair<string, string>("EmailAddress", Model.EmailAddress));
            keyValues.Add(new KeyValuePair<string, string>("UserPrincipalName", Model.UserPrincipalName));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute1", Model.ExtensionAttribute1));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute2", Model.ExtensionAttribute2));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute3", Model.ExtensionAttribute3));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute4", Model.ExtensionAttribute4));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute5", Model.ExtensionAttribute5));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute6", Model.ExtensionAttribute6));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute7", Model.ExtensionAttribute7));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute8", Model.ExtensionAttribute8));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute9", Model.ExtensionAttribute9));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute10", Model.ExtensionAttribute10));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute11", Model.ExtensionAttribute11));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute12", Model.ExtensionAttribute12));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute13", Model.ExtensionAttribute13));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute14", Model.ExtensionAttribute14));
            keyValues.Add(new KeyValuePair<string, string>("ExtensionAttribute15", Model.ExtensionAttribute15));


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.PutAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Error";
        }

        public static async Task<string> Delete(string SamAccountName)
        {
            //api/v1/Ad/{SamAccountName}/Delete 
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/" + SamAccountName + "/Delete";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            HttpResponseMessage response = await client.DeleteAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync(); 
            }
            return "Error";
        }

        public static async Task<string> GroupDelete(string SamAccountName)
        {
            //api/v1/Ad/{SamAccountName}/GroupDelete
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/" + SamAccountName + "/GroupDelete";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            HttpResponseMessage response = await client.DeleteAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Error";
        }

        public static async Task<ActiveDirectoryModel> GetDetailUserBySamAccountName(string SamAccountName)
        {
            //api/v1/Ad/{SamAccountName}/GetUserBySamAccountName
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/" + SamAccountName + "/GetUserBySamAccountName";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            HttpResponseMessage response = await client.GetAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<ActiveDirectoryModel>();
            }
            return null;
        }

         
        public static async Task<ActiveDirectoryModel> GetDetailUserByEmployeeID(string EmployeeID)
        {
            //api/v1/Ad/{EmployeeID}/GetUserByEmployeeID
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/" + EmployeeID + "/GetUserByEmployeeID";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            HttpResponseMessage response = await client.GetAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<ActiveDirectoryModel>();
            }
            return null;
        }
        public static async Task<string> DirectoryDelete(string Parent, string Child)
        {
            //api/v1/Ad/{Child}/{Parent}/DirectoryDelete
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/" + Child + "/" + Parent + "/DirectoryDelete";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            HttpResponseMessage response = await client.DeleteAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Error";
        }
        public static async Task<string> DirectoryRename(string Parent, string Child, string New)
        {
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/DirectoryRename";
            var client = new HttpClient();
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>(); 
            keyValues.Add(new KeyValuePair<string, string>("Parent", Parent));
            keyValues.Add(new KeyValuePair<string, string>("Child", Child));
            keyValues.Add(new KeyValuePair<string, string>("New", New)); 

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.PutAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Error";
        }
        public static async Task<string> DirectoryCreate(string Parent, string Child, string Description = null)
        {
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/DirectoryRename";
            var client = new HttpClient();
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>();
            keyValues.Add(new KeyValuePair<string, string>("Parent", Parent));
            keyValues.Add(new KeyValuePair<string, string>("Child", Child));
            keyValues.Add(new KeyValuePair<string, string>("Description", Description));

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Error";
        } 
         public static async Task<ServiceCountModel> CountAll()
        {
            //api/v1/Ad/CountAllService/
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/CountAllService";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            HttpResponseMessage response = await client.GetAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<ServiceCountModel>();
            }
            return null;
        } 

        public static async Task<GroupModel> DetailGroup(string SamAccountName)
        {
            //api/v1/Ad/{SamAccountName}/GetDetailGroup
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ad/"+ SamAccountName + "/DetailGroup";
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            HttpResponseMessage response = await client.GetAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<GroupModel>();
            }
            return null;
        }

    }

}

