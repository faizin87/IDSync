using IDSync.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
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
        //public static PrincipalContext GetPrincipalContext(string OU)
        //{
        //    return new PrincipalContext(ContextType.Domain, Configs.MainConfig.Conf("AdDomain"), OU + "," + Configs.MainConfig.Conf("AdOU"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //}
        //public static ArrayList EnumerateOU()
        //{
        //    ArrayList alObjects = new ArrayList();
        //    try
        //    {
        //        DirectoryEntry directoryObject = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));

        //        foreach (DirectoryEntry child in directoryObject.Children)
        //        {
        //            string childPath = child.Path.ToString();
        //            alObjects.Add(childPath.Remove(0, 7));
        //            //remove the LDAP prefix from the path

        //            child.Close();
        //            child.Dispose();
        //        }
        //        directoryObject.Close();
        //        directoryObject.Dispose();
        //    }
        //    catch (DirectoryServicesCOMException e)
        //    {
        //        Console.WriteLine("An Error Occurred: " + e.Message.ToString());
        //    }
        //    return alObjects;
        //}
        //public static ArrayList EnumerateOUChild(string OU)
        //{
        //    ArrayList allObjects = new ArrayList();
        //    try
        //    {
        //        DirectoryEntry directoryObject = new DirectoryEntry(Configs.MainConfig.Conf("AdPath") + OU + "," + Configs.MainConfig.Conf("AdOU"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));

        //        foreach (DirectoryEntry child in directoryObject.Children)
        //        {
        //            string childPath = child.Path.ToString();
        //            allObjects.Add(childPath.Remove(0, 7));
        //            //remove the LDAP prefix from the path

        //            child.Close();
        //            child.Dispose();
        //        }
        //        directoryObject.Close();
        //        directoryObject.Dispose();
        //    }
        //    catch (DirectoryServicesCOMException e)
        //    {
        //        Console.WriteLine("An Error Occurred: " + e.Message.ToString());
        //    }
        //    return allObjects;
        //}
        //public static IEnumerable<ActiveDirectoryModel> Get(string DistinguishedName, string SamAccountName)
        //{
        //    List<ActiveDirectoryModel> li = new List<ActiveDirectoryModel>();
        //    DirectorySearcher search;
        //    if (DistinguishedName != null)
        //    {
        //        DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + DistinguishedName, Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //        search = new DirectorySearcher(searchRoot);
        //    }
        //    else
        //    {
        //        DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath") + "/" + Configs.MainConfig.Conf("AdOU"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //        search = new DirectorySearcher(searchRoot);
        //    } 

        //    search.Filter = "(&(objectClass=user)(objectCategory=person))";
        //    if (SamAccountName != null)
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person)(SamAccountName=" + SamAccountName + "))";
        //    }
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmailAddress);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DisplayName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.FirstName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.LastName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.UserPrincipalName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DistinguishedName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmployeeID); 
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Country);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Notes);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Company);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Office);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Street);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PostalCode);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Province);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.City);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Website);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Telephone);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.JobTitle);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Department);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Manager);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Name);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.userAccountControl); 
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.MsExchHomeServerName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PrimaryUserAddress);
        //    search.PageSize = 1000;

        //    SearchResultCollection Result = search.FindAll();
        //    if (Result != null)
        //    { 
        //        List<SharePointModel> SPM = null; 
        //        if (Configs.MainConfig.Conf("EnableSharepoint").Equals("true"))
        //        {
        //            SPM = SharePointHelper.Get();
        //        }

        //        int no = 1;
        //        for (int counter = 0; counter < Result.Count; counter++)
        //        {
        //            var result = Result[counter];
        //            if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.SamAccountName))
        //            {

        //                    ActiveDirectoryModel ADM = new ActiveDirectoryModel();
        //                    ADM.No = no;
        //                    ADM.DisplayName = (result.Properties[Attributes.ActiveDirectoryAttribute.DisplayName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.DisplayName][0] : null);
        //                    ADM.EmailAddress = (result.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress][0] : null);
        //                    ADM.EmployeeID = (result.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID][0] : null);
        //                    ADM.FirstName = (result.Properties[Attributes.ActiveDirectoryAttribute.FirstName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.FirstName][0] : null);
        //                    ADM.LastName = (result.Properties[Attributes.ActiveDirectoryAttribute.LastName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.LastName][0] : null);
        //                    ADM.SamAccountName = (result.Properties[Attributes.ActiveDirectoryAttribute.SamAccountName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.SamAccountName][0] : null);
        //                    ADM.UserPrincipalName = (result.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName][0] : null);
        //                    ADM.DistinguishedName = (result.Properties[Attributes.ActiveDirectoryAttribute.DistinguishedName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.DistinguishedName][0] : null);
        //                    ADM.Manager = (result.Properties[Attributes.ActiveDirectoryAttribute.Manager].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Manager][0] : null);
        //                    ADM.JobTitle = (result.Properties[Attributes.ActiveDirectoryAttribute.JobTitle].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.JobTitle][0] : null);
        //                    ADM.Name = (result.Properties[Attributes.ActiveDirectoryAttribute.Name].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Name][0] : null);
        //                    ADM.Notes = (result.Properties[Attributes.ActiveDirectoryAttribute.Notes].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Notes][0] : null);
        //                    ADM.Office = (result.Properties[Attributes.ActiveDirectoryAttribute.Office].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Office][0] : null);
        //                    ADM.PostalCode = (result.Properties[Attributes.ActiveDirectoryAttribute.PostalCode].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.PostalCode][0] : null);
        //                    ADM.Province = (result.Properties[Attributes.ActiveDirectoryAttribute.Province].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Province][0] : null);
        //                    ADM.Street = (result.Properties[Attributes.ActiveDirectoryAttribute.Street].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Street][0] : null);
        //                    ADM.Telephone = (result.Properties[Attributes.ActiveDirectoryAttribute.Telephone].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Telephone][0] : null);
        //                    ADM.Website = (result.Properties[Attributes.ActiveDirectoryAttribute.Website].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Website][0] : null);
        //                    ADM.City = (result.Properties[Attributes.ActiveDirectoryAttribute.City].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.City][0] : null);
        //                    ADM.Company = (result.Properties[Attributes.ActiveDirectoryAttribute.Company].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Company][0] : null);
        //                    ADM.Country = (result.Properties[Attributes.ActiveDirectoryAttribute.Country].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Country][0] : null);
        //                    ADM.Department = (result.Properties[Attributes.ActiveDirectoryAttribute.Department].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Department][0] : null);


        //                    int flags = (int)result.Properties[Attributes.ActiveDirectoryAttribute.userAccountControl][0];

        //                    ADM.IsEnable = !Convert.ToBoolean(flags & 0x0002);

        //                    ADM.EnableSkype = 0;
        //                    if (Configs.MainConfig.Conf("EnableSkype").Equals("true"))
        //                    {
        //                        // Sync
        //                        ADM.PrimaryUserAddress = (result.Properties[Attributes.ActiveDirectoryAttribute.PrimaryUserAddress].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.PrimaryUserAddress][0] : null);
        //                        if (ADM.PrimaryUserAddress != null)
        //                        {
        //                            ADM.EnableSkype = 1;
        //                        }
        //                    }
        //                    ADM.EnableExchange = 0;
        //                    if (Configs.MainConfig.Conf("EnableExchange").Equals("true"))
        //                    {
        //                        ADM.MsExchHomeServerName = (result.Properties[Attributes.ActiveDirectoryAttribute.MsExchHomeServerName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.MsExchHomeServerName][0] : null);
        //                        if (ADM.MsExchHomeServerName != null)
        //                        {
        //                            ADM.EnableExchange = 1;
        //                        }
        //                    }

        //                    if (Configs.MainConfig.Conf("EnableSharepoint").Equals("true"))
        //                    {
        //                        if (!SPM.Exists(sp => sp.SamAccountName == ADM.EmailAddress))
        //                        {
        //                            ADM.EnableSharepoint = 0;
        //                        }
        //                        else
        //                        {
        //                            ADM.EnableSharepoint = 1;
        //                        }
        //                    }

        //                    li.Add(ADM);
        //                    no++;
        //                }
        //            } 
        //    }
        //    return li;
        //}
        //public static IEnumerable<GroupModel> GetListGroup(string DistinguishedName, string SamAccountName)
        //{
        //    List<GroupModel> li = new List<GroupModel>();
        //    DirectorySearcher search;
        //    if (DistinguishedName != null)
        //    {
        //        DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + DistinguishedName, Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //        search = new DirectorySearcher(searchRoot);
        //    }
        //    else
        //    {
        //        DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath") + "/" + Configs.MainConfig.Conf("AdOU"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //        search = new DirectorySearcher(searchRoot);
        //    }
        //    //

        //    search.Filter = "(&(objectClass=group))";
        //    if (SamAccountName != null)
        //    {
        //        search.Filter = "(&(objectClass=group)(SamAccountName=" + SamAccountName + "))";
        //    }
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.Name);
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.DistinguishedName);
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.Description);
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.Info);
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.SID);
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.Email);

        //    SearchResultCollection Result = search.FindAll();
        //    if (Result != null)
        //    {
        //        int no = 1;
        //        for (int counter = 0; counter < Result.Count; counter++)
        //        {
        //            var result = Result[counter];
        //            if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.Name)
        //                )
        //            {
        //                GroupModel ADM = new GroupModel();
        //                ADM.Name = (result.Properties[Attributes.GroupAttribute.Name].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.Name][0] : null);
        //                ADM.SamAccountName = (result.Properties[Attributes.GroupAttribute.SamAccountName].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.SamAccountName][0] : null);
        //                byte[] sid_ = (result.Properties[Attributes.GroupAttribute.SID].Count > 0 ? result.Properties[Attributes.GroupAttribute.SID][0] as byte[] : null);
        //                ADM.Info = (result.Properties[Attributes.GroupAttribute.Info].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.Info][0] : null);
        //                ADM.Description = (result.Properties[Attributes.GroupAttribute.Description].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.Description][0] : null);
        //                ADM.DistinguishedName = (result.Properties[Attributes.GroupAttribute.DistinguishedName].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.DistinguishedName][0] : null);
        //                SecurityIdentifier sid = new SecurityIdentifier(sid_, 0);
        //                ADM.SID = sid.Value;
        //                ADM.Email = (result.Properties[Attributes.GroupAttribute.Email].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.Email][0] : null);
        //                li.Add(ADM);
        //                no++;
        //            }
        //        }

        //    }
        //    return li;
        //}

        //public static IEnumerable<GroupModel> GetGroup(GroupModel Model)
        //{
        //    if (Model.DistinguishedName != null && Model.Email != null)
        //    {
        //        List<GroupModel> li = new List<GroupModel>();
        //        DirectorySearcher search;
        //        DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath") + "/" + Configs.MainConfig.Conf("AdOU"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //        search = new DirectorySearcher(searchRoot);

        //        search.Filter = "(&(objectClass=group)(mail=" + Model.Email + "))";
        //        search.PropertiesToLoad.Add(Attributes.GroupAttribute.Name);
        //        search.PropertiesToLoad.Add(Attributes.GroupAttribute.DistinguishedName);
        //        search.PropertiesToLoad.Add(Attributes.GroupAttribute.SamAccountName);
        //        search.PropertiesToLoad.Add(Attributes.GroupAttribute.Description);
        //        search.PropertiesToLoad.Add(Attributes.GroupAttribute.Info);
        //        search.PropertiesToLoad.Add(Attributes.GroupAttribute.SID);
        //        search.PropertiesToLoad.Add(Attributes.GroupAttribute.Email);

        //        SearchResultCollection Result = search.FindAll();
        //        if (Result != null)
        //        {
        //            int no = 1;
        //            for (int counter = 0; counter < Result.Count; counter++)
        //            {
        //                var result = Result[counter];
        //                if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.Name)
        //                    )
        //                {
        //                    GroupModel ADM = new GroupModel();
        //                    ADM.Name = (result.Properties[Attributes.GroupAttribute.Name].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.Name][0] : null);
        //                    ADM.SamAccountName = (result.Properties[Attributes.GroupAttribute.SamAccountName].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.SamAccountName][0] : null);
        //                    byte[] sid_ = (result.Properties[Attributes.GroupAttribute.SID].Count > 0 ? result.Properties[Attributes.GroupAttribute.SID][0] as byte[] : null);
        //                    ADM.Info = (result.Properties[Attributes.GroupAttribute.Info].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.Info][0] : null);
        //                    ADM.Description = (result.Properties[Attributes.GroupAttribute.Description].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.Description][0] : null);
        //                    ADM.DistinguishedName = (result.Properties[Attributes.GroupAttribute.DistinguishedName].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.DistinguishedName][0] : null);
        //                    SecurityIdentifier sid = new SecurityIdentifier(sid_, 0);
        //                    ADM.SID = sid.Value;
        //                    ADM.Email = (result.Properties[Attributes.GroupAttribute.Email].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.Email][0] : null);
        //                    li.Add(ADM);
        //                    no++;
        //                }
        //            }

        //        }
        //        return li;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public static string GetOU(string DistinguishedName, int Type = 0)
        //{
        //    string OU = "";
        //    if (DistinguishedName != null)
        //    {
        //        string[] directoryEntryPath = DistinguishedName.Replace(Configs.MainConfig.Conf("AdDomain") + "/", "").Split(',');
        //        //Getting the each items of the array and spliting again with the "=" character
        //        var nox = 1;
        //        foreach (var splitedPath in directoryEntryPath)
        //        {
        //            string[] eleiments = splitedPath.Split('=');
        //            //If the 1st element of the array is "OU" string then get the 2dn element
        //            if (eleiments[0].Trim() == "OU")
        //            {
        //                switch (Type)
        //                {
        //                    case 1:
        //                        if (nox == 1)
        //                        {
        //                            OU += "OU=" + @eleiments[1];
        //                        }
        //                        else
        //                        {
        //                            OU += ",OU=" + @eleiments[1];
        //                        }
        //                        break;
        //                    default:
        //                        if (nox == 1)
        //                        {
        //                            OU += @eleiments[1];
        //                        }
        //                        else
        //                        {
        //                            OU += "-" + @eleiments[1];
        //                        }
        //                        break;
        //                }


        //                nox++;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        OU = "";
        //    }
        //    return OU;
        //} 

        //public static string GroupCreate(GroupModel Model)
        //{
        //    string result = null;
        //    DirectoryEntry entry = null;
        //    if (Model.DistinguishedName == null)
        //    {
        //        entry = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    }
        //    else
        //    {
        //        entry = new DirectoryEntry("LDAP://" + Model.DistinguishedName, Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    }
        //    if (CheckGroup(Model.Name) == 0)
        //    {
        //        try
        //        {
        //            // create group entry
        //            DirectoryEntry group = entry.Children.Add("CN=" + Model.Name, "group");

        //            // set properties
        //            group.Properties[Attributes.GroupAttribute.SamAccountName].Value = Model.Name;
        //            group.Properties[Attributes.GroupAttribute.Description].Value = Model.Description;
        //            group.Properties[Attributes.GroupAttribute.Email].Value = Model.Email;
        //            group.Properties[Attributes.GroupAttribute.Info].Value = Model.Info;

        //            // save group
        //            group.CommitChanges();
        //            result = "1";
        //        }
        //        catch (Exception e)
        //        {
        //            e.Message.ToString();
        //            result = "0";
        //        }
        //    }
        //    else
        //    {
        //        result = "-1";
        //    }
        //    return result;
        //}

        //public static string GroupEdit(GroupModel Model, string oldName)
        //{
        //    string result = null;
        //    DirectoryEntry group = new DirectoryEntry(Configs.MainConfig.Conf("AdPath") + "/" + Model.DistinguishedName, Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));

        //    try
        //    {
        //        // create group entry 

        //        // set properties
        //        group.Properties[Attributes.GroupAttribute.SamAccountName].Value = Model.Name;
        //        group.Properties[Attributes.GroupAttribute.Description].Value = Model.Description;
        //        group.Properties[Attributes.GroupAttribute.Email].Value = Model.Email;
        //        group.Properties[Attributes.GroupAttribute.Info].Value = Model.Info;
        //        // save group
        //        group.CommitChanges();
        //        if (Model.Name == oldName)
        //        {
        //            group.Rename("CN=" + Model.Name);
        //        }
        //        else if (CheckGroup(Model.Name) > 0 && Model.Name != oldName)
        //        {
        //            result = "-1";
        //        }
        //        else
        //        {
        //            group.Rename("CN=" + Model.Name);
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        e.Message.ToString();
        //        result = "0";
        //    }

        //    return result;
        //}

        //public static void Post(ActiveDirectoryModel Model)
        //{
        //    string result = null;
        //    PrincipalContext principalContext = null;
        //    if (Model.DistinguishedName == null)
        //    {
        //        principalContext = GetPrincipalContextDomain();
        //    }
        //    else
        //    {
        //        principalContext = GetPrincipalContext(Model.DistinguishedName);
        //    }
        //    using (principalContext)
        //    {
        //        using (UserPrincipal newUser = new UserPrincipal(principalContext))
        //        {
        //            string defaultValue = "";

        //            newUser.SamAccountName = !string.IsNullOrEmpty(Model.SamAccountName) ? Model.SamAccountName : defaultValue;
        //            newUser.EmailAddress = !string.IsNullOrEmpty(Model.SamAccountName) ? Model.SamAccountName + "@" + Configs.MainConfig.Conf("AdDomain") : defaultValue;
        //            newUser.UserPrincipalName = !string.IsNullOrEmpty(Model.SamAccountName) ? Model.SamAccountName + "@" + Configs.MainConfig.Conf("AdDomain") : defaultValue;
        //            newUser.GivenName = !string.IsNullOrEmpty(Model.FirstName) ? Model.FirstName : defaultValue;
        //            if (!string.IsNullOrEmpty(Model.LastName))
        //            {
        //                newUser.Surname = Model.LastName.Trim();
        //            }
        //            newUser.DisplayName = !string.IsNullOrEmpty(Model.DisplayName) ? Model.DisplayName : defaultValue;
        //            newUser.Name = !string.IsNullOrEmpty(Model.DisplayName) ? Model.DisplayName : defaultValue;

        //            newUser.SetPassword(Configs.MainConfig.Conf("AdDefaultPassword"));
        //            newUser.Enabled = true;
        //            newUser.PasswordNeverExpires = true;
        //            //newUser.ExpirePasswordNow();

        //            try
        //            {
        //                newUser.Save();
        //                if (newUser.GetUnderlyingObjectType() == typeof(DirectoryEntry))
        //                {
        //                    using (DirectoryEntry entry = (DirectoryEntry)newUser.GetUnderlyingObject())
        //                    {
        //                        if (!string.IsNullOrEmpty(Model.EmployeeID))
        //                            entry.Properties[Attributes.ActiveDirectoryAttribute.Notes].Value = Model.EmployeeID;
        //                        entry.CommitChanges();
        //                    }
        //                    result = "User is successfully created. " + Model.DisplayName;
        //                }
        //            }
        //            catch (Exception e)
        //            {
        //                result = "Exception creating user object. " + Model.DisplayName + " " + e.Message;
        //            }
        //        }
        //    }

        //}

        //public static string PostAdvance(ActiveDirectoryModel Model)
        //{
        //    DirectoryEntry dirEntry = null;
        //    if (Model.DistinguishedName != null)
        //    {
        //        dirEntry = new DirectoryEntry("LDAP://" + Model.DistinguishedName, Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    }
        //    else
        //    {
        //        dirEntry = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    }
        //    //
        //    try
        //    {
        //        DirectoryEntry newUser = dirEntry.Children.Add("CN=" + Model.Name, "User");
        //        newUser.Properties[Attributes.ActiveDirectoryAttribute.SamAccountName].Value = Model.SamAccountName;  

        //        if (!String.IsNullOrEmpty(Model.Name))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.Name].Value = Model.Name;
        //        }else { 
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.Name].Value = Model.SamAccountName;
        //        }

        //        if (!String.IsNullOrEmpty(Model.EmailAddress))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress].Value = Model.EmailAddress;
        //        }

        //        if (!String.IsNullOrEmpty(Model.EmailAddress))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName].Value = Model.EmailAddress;
        //        }

        //        if (!String.IsNullOrEmpty(Model.Notes))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.Notes].Value = Model.Notes;
        //        }

        //        if (!String.IsNullOrEmpty(Model.FirstName))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.FirstName].Value = Model.FirstName;
        //        }

        //        if (!String.IsNullOrEmpty(Model.EmployeeID))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID].Value = Model.EmployeeID;
        //        }

        //        if (!String.IsNullOrEmpty(Model.LastName))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.LastName].Value = Model.LastName;
        //        }

        //        if (!String.IsNullOrEmpty(Model.DisplayName))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.DisplayName].Value = Model.DisplayName;
        //        }

        //        if (!String.IsNullOrEmpty(Model.Website))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.Website].Value = Model.Website;
        //        }

        //        if (!String.IsNullOrEmpty(Model.Telephone))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.Telephone].Value = Model.Telephone;
        //        }

        //        if (!String.IsNullOrEmpty(Model.JobTitle))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.JobTitle].Value = Model.JobTitle;
        //        }

        //        if (!String.IsNullOrEmpty(Model.PostalCode))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.PostalCode].Value = Model.PostalCode;
        //        }

        //        if (!String.IsNullOrEmpty(Model.Department))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.Department].Value = Model.Department;
        //        }

        //        if (!String.IsNullOrEmpty(Model.Street))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.Street].Value = Model.Street;
        //        }

        //        if (!String.IsNullOrEmpty(Model.Office))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.Office].Value = Model.Office;
        //        }

        //        if (!String.IsNullOrEmpty(Model.Company))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.Company].Value = Model.Company;
        //        }

        //        if (!String.IsNullOrEmpty(Model.Country))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.Country].Value = Model.Country;
        //        }

        //        if (!String.IsNullOrEmpty(Model.Province))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.Province].Value = Model.Province;
        //        }

        //        if (!String.IsNullOrEmpty(Model.City))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.City].Value = Model.City;
        //        }

        //        if (!String.IsNullOrEmpty(Model.Manager))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.Manager].Value = Model.Manager;
        //        }

        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute1))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute1].Value = Model.ExtensionAttribute1;
        //        }
        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute2))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute2].Value = Model.ExtensionAttribute2;
        //        }
        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute3))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute3].Value = Model.ExtensionAttribute3;
        //        }
        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute4))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute4].Value = Model.ExtensionAttribute4;
        //        }
        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute5))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute5].Value = Model.ExtensionAttribute5;
        //        }
        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute6))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute6].Value = Model.ExtensionAttribute6;
        //        }
        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute7))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute7].Value = Model.ExtensionAttribute7;
        //        }
        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute8))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute8].Value = Model.ExtensionAttribute8;
        //        }
        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute9))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute9].Value = Model.ExtensionAttribute9;
        //        }
        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute10))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute10].Value = Model.ExtensionAttribute10;
        //        }
        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute11))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute11].Value = Model.ExtensionAttribute11;
        //        }
        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute12))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute12].Value = Model.ExtensionAttribute12;
        //        }
        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute13))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute13].Value = Model.ExtensionAttribute13;
        //        }
        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute14))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute14].Value = Model.ExtensionAttribute14;
        //        }
        //        if (!String.IsNullOrEmpty(Model.ExtensionAttribute15))
        //        {
        //            newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute15].Value = Model.ExtensionAttribute15;
        //        }
        //        /** 
        //        */
        //        newUser.CommitChanges();
        //        //If you dont have an SSL connection you can not set password
        //        newUser.Invoke("SetPassword", new object[] { Configs.MainConfig.Conf("AdDefaultPassword") });
        //        newUser.Properties["LockOutTime"].Value = 0;
        //        //Enable user
        //        int val = (int)newUser.Properties["userAccountControl"].Value;
        //        newUser.Properties["userAccountControl"].Value = val & ~0x2;
        //        newUser.CommitChanges();
        //        dirEntry.Close();
        //        return "Success";
        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message.ToString();
        //    }

        //} 

        //public static string EditAdvance(ActiveDirectoryModel Model)
        //{
        //    DirectorySearcher search;
        //    if (Model.DistinguishedName != null)
        //    {
        //        DirectoryEntry searchRoot = new DirectoryEntry("LDAP://" + Model.DistinguishedName, Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //        search = new DirectorySearcher(searchRoot);
        //    }
        //    else
        //    {
        //        DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //        search = new DirectorySearcher(searchRoot);
        //    }
        //    //

        //    search.Filter = "(&(objectClass=user)(objectCategory=person))";
        //    if (Model.SamAccountName != null)
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person)(samAccountName=" + Model.SamAccountName + "))";
        //    } 

        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmailAddress);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DisplayName); 
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.FirstName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.LastName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.UserPrincipalName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmployeeID);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Country);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Notes);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Company);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Office);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Street);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PostalCode);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Province);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.City);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Website);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Telephone);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.JobTitle);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Department);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Manager);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Name);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute1);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute2);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute3);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute4);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute5);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute6);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute7);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute8);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute9);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute10);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute11);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute12);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute13);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute14);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute15);
        //    SearchResult result = search.FindOne();

        //    try
        //    {
        //        DirectoryEntry newUser = result.GetDirectoryEntry();
        //        /**if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.EmailAddress))
        //        {
        //            if (!String.IsNullOrEmpty(Model.EmailAddress))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress].Value = Model.EmailAddress;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.EmailAddress))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress].Add(Model.EmailAddress);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.UserPrincipalName))
        //        {
        //            if (!String.IsNullOrEmpty(Model.EmailAddress))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName].Value = Model.EmailAddress;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.EmailAddress))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName].Add(Model.EmailAddress);
        //            }
        //        }
        //        **/
        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.Notes))
        //        {
        //            if (!String.IsNullOrEmpty(Model.Notes))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Notes].Value = Model.Notes;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.Notes))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Notes].Add(Model.Notes);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.EmployeeID))
        //        {
        //            if (!String.IsNullOrEmpty(Model.EmployeeID))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID].Value = Model.EmployeeID;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.EmployeeID))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID].Add(Model.EmployeeID);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.FirstName))
        //        {
        //            if (!String.IsNullOrEmpty(Model.FirstName))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.FirstName].Value = Model.FirstName;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.FirstName))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.FirstName].Add(Model.FirstName);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.LastName))
        //        {
        //            if (!String.IsNullOrEmpty(Model.LastName))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.LastName].Value = Model.LastName;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.LastName))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.LastName].Add(Model.LastName);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.DisplayName))
        //        {
        //            if (!String.IsNullOrEmpty(Model.DisplayName))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.DisplayName].Value = Model.DisplayName;
        //            }
        //            else
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.DisplayName].Value = Model.FirstName + " " + Model.LastName;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.DisplayName))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.DisplayName].Add(Model.DisplayName);
        //            }
        //            else
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.DisplayName].Add(Model.FirstName + " " + Model.LastName);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.Website))
        //        {
        //            if (!String.IsNullOrEmpty(Model.Website))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Website].Value = Model.Website;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.Website))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Website].Add(Model.Website);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.Telephone))
        //        {
        //            if (!String.IsNullOrEmpty(Model.Telephone))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Telephone].Value = Model.Telephone;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.Telephone))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Telephone].Add(Model.Telephone);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.JobTitle))
        //        {
        //            if (!String.IsNullOrEmpty(Model.JobTitle))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.JobTitle].Value = Model.JobTitle;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.JobTitle))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.JobTitle].Add(Model.JobTitle);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.PostalCode))
        //        {
        //            if (!String.IsNullOrEmpty(Model.PostalCode))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.PostalCode].Value = Model.PostalCode;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.PostalCode))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.PostalCode].Add(Model.PostalCode);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.Department))
        //        {
        //            if (!String.IsNullOrEmpty(Model.Department))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Department].Value = Model.Department;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.Department))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Department].Add(Model.Department);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.Street))
        //        {
        //            if (!String.IsNullOrEmpty(Model.Street))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Street].Value = Model.Street;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.Street))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Street].Add(Model.Street);
        //            }
        //        }


        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.Office))
        //        {
        //            if (!String.IsNullOrEmpty(Model.Office))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Office].Value = Model.Office;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.Office))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Office].Add(Model.Office);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.Company))
        //        {
        //            if (!String.IsNullOrEmpty(Model.Company))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Company].Value = Model.Company;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.Company))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Company].Add(Model.Company);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.Country))
        //        {
        //            if (!String.IsNullOrEmpty(Model.Country))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Country].Value = Model.Country;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.Country))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Country].Add(Model.Country);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.Province))
        //        {
        //            if (!String.IsNullOrEmpty(Model.Province))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Province].Value = Model.Province;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.Province))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Province].Add(Model.Province);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.City))
        //        {
        //            if (!String.IsNullOrEmpty(Model.City))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.City].Value = Model.City;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.City))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.City].Add(Model.City);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.Manager))
        //        {
        //            if (!String.IsNullOrEmpty(Model.Manager))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Manager].Value = Model.Manager;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.Manager))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.Manager].Add(Model.Manager);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute1))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute1))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute1].Value = Model.ExtensionAttribute1;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute1))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute1].Add(Model.ExtensionAttribute1);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute2))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute2))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute2].Value = Model.ExtensionAttribute2;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute2))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute2].Add(Model.ExtensionAttribute2);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute3))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute3))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute3].Value = Model.ExtensionAttribute3;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute3))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute3].Add(Model.ExtensionAttribute3);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute4))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute4))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute4].Value = Model.ExtensionAttribute4;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute4))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute4].Add(Model.ExtensionAttribute4);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute5))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute5))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute5].Value = Model.ExtensionAttribute5;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute5))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute5].Add(Model.ExtensionAttribute5);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute6))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute6))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute6].Value = Model.ExtensionAttribute6;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute6))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute6].Add(Model.ExtensionAttribute6);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute7))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute7))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute7].Value = Model.ExtensionAttribute7;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute7))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute7].Add(Model.ExtensionAttribute7);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute8))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute8))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute8].Value = Model.ExtensionAttribute8;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute8))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute8].Add(Model.ExtensionAttribute8);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute9))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute9))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute9].Value = Model.ExtensionAttribute9;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute9))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute9].Add(Model.ExtensionAttribute9);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute10))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute10))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute10].Value = Model.ExtensionAttribute10;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute10))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute10].Add(Model.ExtensionAttribute10);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute11))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute11))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute11].Value = Model.ExtensionAttribute11;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute11))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute11].Add(Model.ExtensionAttribute11);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute12))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute12))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute12].Value = Model.ExtensionAttribute12;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute12))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute12].Add(Model.ExtensionAttribute12);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute13))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute13))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute13].Value = Model.ExtensionAttribute13;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute13))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute13].Add(Model.ExtensionAttribute13);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute14))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute14))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute14].Value = Model.ExtensionAttribute14;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute14))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute14].Add(Model.ExtensionAttribute14);
        //            }
        //        }

        //        if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.extensionAttribute15))
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute15))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute15].Value = Model.ExtensionAttribute15;
        //            }
        //        }
        //        else
        //        {
        //            if (!String.IsNullOrEmpty(Model.ExtensionAttribute15))
        //            {
        //                newUser.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute15].Add(Model.ExtensionAttribute15);
        //            }
        //        }

        //        newUser.CommitChanges();
        //        search.Dispose();
        //        return "Success";
        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message.ToString();
        //    }


        //}

        //public static string Delete(string SamAccountName)
        //{
        //    string result = null;
        //    // set up domain context
        //    using (PrincipalContext principalContext = Helpers.ActiveDirectoryHelper.GetPrincipalContextDomain())
        //    {

        //        // find the user you want to delete
        //        UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, SamAccountName);

        //        if (userPrincipal != null)
        //        {
        //            try
        //            {
        //                userPrincipal.Delete();
        //                result = "Success delete user. " + SamAccountName;
        //            }
        //            catch (Exception e)
        //            {

        //                result = "Exception delete user. " + SamAccountName + " " + e.Message;
        //            }

        //        }
        //        else
        //        {
        //            result = "User not found";
        //        }
        //    }
        //    return result;
        //}

        //public static string GroupDelete(string SamAccountName)
        //{
        //    string result = null;
        //    // set up domain context
        //    using (PrincipalContext principalContext = Helpers.ActiveDirectoryHelper.GetPrincipalContextDomain())
        //    {

        //        // find the user you want to delete 
        //        GroupPrincipal group = GroupPrincipal.FindByIdentity(principalContext, SamAccountName);
        //        if (group != null)
        //        {
        //            try
        //            {

        //                group.Delete();
        //                result = "Success delete user. " + SamAccountName;
        //            }
        //            catch (Exception e)
        //            {

        //                result = "Exception delete user. " + SamAccountName + " " + e.Message;
        //            }

        //        }
        //        else
        //        {
        //            result = "User not found";
        //        }
        //    }
        //    return result;
        //}

        //public static ActiveDirectoryModel GetDetails(string SamAccountName)
        //{
        //    DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    DirectorySearcher search = new DirectorySearcher(searchRoot);
        //    //
        //    if (SamAccountName != null)
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person)(SamAccountName=" + SamAccountName + "))";
        //    }
        //    else
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person))";
        //    }


        //    List<SharePointModel> SPM = null; 

        //    if (Configs.MainConfig.Conf("EnableSharepoint").Equals("true"))
        //    {
        //        SPM = SharePointHelper.Get(SamAccountName);
        //    }


        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmailAddress);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DisplayName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Country);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Notes);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmployeeID);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Company);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.FirstName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.LastName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Office);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Street);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PostalCode);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Province);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.City);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Website);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Telephone);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.JobTitle);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DisplayName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Department);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Manager);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmailAddress);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.UserPrincipalName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Name);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DistinguishedName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.MemberOf);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute1);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute2);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute3);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute4);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute5);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute6);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute7);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute8);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute9);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute10);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute11);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute12);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute13);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute14);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute15);

        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.MsExchHomeServerName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PrimaryUserAddress);
        //    search.PageSize = 1000;

        //    SearchResultCollection Result = search.FindAll();
        //    ActiveDirectoryModel ADM = new ActiveDirectoryModel();
        //    if (Result != null)
        //    {
        //        int no = 1;
        //        for (int counter = 0; counter < Result.Count; counter++)
        //        {
        //            var result = Result[counter];
        //            if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.SamAccountName))
        //            {

        //                ADM.No = no;
        //                ADM.City = (result.Properties[Attributes.ActiveDirectoryAttribute.City].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.City][0] : null);
        //                ADM.Company = (result.Properties[Attributes.ActiveDirectoryAttribute.Company].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Company][0] : null);
        //                ADM.Country = (result.Properties[Attributes.ActiveDirectoryAttribute.Country].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Country][0] : null);
        //                ADM.Department = (result.Properties[Attributes.ActiveDirectoryAttribute.Department].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Department][0] : null);
        //                ADM.DisplayName = (result.Properties[Attributes.ActiveDirectoryAttribute.DisplayName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.DisplayName][0] : null);
        //                ADM.EmailAddress = (result.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress][0] : null);
        //                ADM.EmployeeID = (result.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID][0] : null);

        //                ADM.FirstName = (result.Properties[Attributes.ActiveDirectoryAttribute.FirstName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.FirstName][0] : null);
        //                ADM.JobTitle = (result.Properties[Attributes.ActiveDirectoryAttribute.JobTitle].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.JobTitle][0] : null);
        //                ADM.LastName = (result.Properties[Attributes.ActiveDirectoryAttribute.LastName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.LastName][0] : null);
        //                ADM.Manager = (result.Properties[Attributes.ActiveDirectoryAttribute.Manager].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Manager][0] : null);
        //                ADM.Name = (result.Properties[Attributes.ActiveDirectoryAttribute.Name].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Name][0] : null);
        //                ADM.Notes = (result.Properties[Attributes.ActiveDirectoryAttribute.Notes].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Notes][0] : null);
        //                ADM.Office = (result.Properties[Attributes.ActiveDirectoryAttribute.Office].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Office][0] : null);
        //                ADM.PostalCode = (result.Properties[Attributes.ActiveDirectoryAttribute.PostalCode].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.PostalCode][0] : null);
        //                ADM.Province = (result.Properties[Attributes.ActiveDirectoryAttribute.Province].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Province][0] : null);
        //                ADM.SamAccountName = (result.Properties[Attributes.ActiveDirectoryAttribute.SamAccountName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.SamAccountName][0] : null);
        //                ADM.Street = (result.Properties[Attributes.ActiveDirectoryAttribute.Street].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Street][0] : null);
        //                ADM.Telephone = (result.Properties[Attributes.ActiveDirectoryAttribute.Telephone].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Telephone][0] : null);
        //                ADM.UserPrincipalName = (result.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName][0] : null);
        //                ADM.Website = (result.Properties[Attributes.ActiveDirectoryAttribute.Website].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Website][0] : null);

        //                ADM.ExtensionAttribute1 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute1].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute1][0] : null);
        //                ADM.ExtensionAttribute2 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute2].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute2][0] : null);
        //                ADM.ExtensionAttribute3 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute3].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute3][0] : null);
        //                ADM.ExtensionAttribute4 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute4].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute4][0] : null);
        //                ADM.ExtensionAttribute5 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute5].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute5][0] : null);
        //                ADM.ExtensionAttribute6 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute6].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute6][0] : null);
        //                ADM.ExtensionAttribute7 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute7].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute7][0] : null);
        //                ADM.ExtensionAttribute8 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute8].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute8][0] : null);
        //                ADM.ExtensionAttribute9 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute9].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute9][0] : null);
        //                ADM.ExtensionAttribute10 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute10].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute10][0] : null);
        //                ADM.ExtensionAttribute11 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute11].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute11][0] : null);
        //                ADM.ExtensionAttribute12 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute12].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute12][0] : null);
        //                ADM.ExtensionAttribute13 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute13].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute13][0] : null);
        //                ADM.ExtensionAttribute14 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute14].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute14][0] : null);
        //                ADM.ExtensionAttribute15 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute15].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute15][0] : null);


        //                ADM.DistinguishedName = (result.Properties[Attributes.ActiveDirectoryAttribute.DistinguishedName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.DistinguishedName][0] : null);

        //                for (int index = 0; index < result.Properties[Attributes.ActiveDirectoryAttribute.MemberOf].Count; index++)
        //                {
        //                    ADM.MemberOf += result.Properties[Attributes.ActiveDirectoryAttribute.MemberOf][index].ToString() + "#";
        //                }


        //                ADM.EnableSkype = 0;
        //                if (Configs.MainConfig.Conf("EnableSkype").Equals("true"))
        //                {
        //                    // Sync
        //                    ADM.PrimaryUserAddress = (result.Properties[Attributes.ActiveDirectoryAttribute.PrimaryUserAddress].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.PrimaryUserAddress][0] : null);
        //                    if (ADM.PrimaryUserAddress != null)
        //                    {
        //                        ADM.EnableSkype = 1;
        //                    }
        //                }
        //                ADM.EnableExchange = 0;
        //                if (Configs.MainConfig.Conf("EnableExchange").Equals("true"))
        //                {
        //                    ADM.MsExchHomeServerName = (result.Properties[Attributes.ActiveDirectoryAttribute.MsExchHomeServerName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.MsExchHomeServerName][0] : null);
        //                    if (ADM.MsExchHomeServerName != null)
        //                    {
        //                        ADM.EnableExchange = 1;
        //                    }
        //                }

        //                if (Configs.MainConfig.Conf("EnableSharepoint").Equals("true"))
        //                {
        //                    if (!SPM.Exists(sp => sp.SamAccountName == ADM.EmailAddress))
        //                    {
        //                        ADM.EnableSharepoint = 0;
        //                    }
        //                    else
        //                    {
        //                        ADM.EnableSharepoint = 1;
        //                    }
        //                }
        //                no++;
        //            }
        //        }

        //    }
        //    return ADM;
        //}


        //public static int GetDetailBySamAccountName(string SamAccountName)
        //{
        //    DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    DirectorySearcher search = new DirectorySearcher(searchRoot); 
        //    //
        //    if (SamAccountName != null)
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person)(samAccountName=" + SamAccountName + "))";
        //    }
        //    else
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person))";
        //    }


        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmailAddress);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DisplayName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Country);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Notes);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmployeeID);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Company);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.FirstName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.LastName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Office);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Street);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PostalCode);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Province);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.City);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Website);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Telephone);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.JobTitle);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DisplayName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Department);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Manager);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmailAddress);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.UserPrincipalName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Name);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DistinguishedName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.MemberOf);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute1);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute2);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute3);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute4);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute5);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute6);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute7);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute8);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute9);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute10);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute11);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute12);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute13);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute14);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute15);

        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.MsExchHomeServerName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PrimaryUserAddress);
        //    search.PageSize = 1000;
        //    SearchResultCollection Result = search.FindAll();
        //    return Result.Count;
        //}

        //public static ActiveDirectoryModel GetDetailByEmployeeID(string EmployeID)
        //{
        //    DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    DirectorySearcher search = new DirectorySearcher(searchRoot);
        //    //
        //    if (EmployeID != null)
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person)(employeeId=" + EmployeID + "))";
        //    }
        //    else
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person))";
        //    }


        //    List<SharePointModel> SPM = null; 
        //    if (Configs.MainConfig.Conf("EnableSharepoint").Equals("true"))
        //    {
        //        SPM = SharePointHelper.Get();
        //    }


        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmailAddress);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DisplayName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Country);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Notes);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmployeeID);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Company);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.FirstName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.LastName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Office);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Street);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PostalCode);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Province);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.City);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Website);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Telephone);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.JobTitle);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DisplayName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Department);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Manager);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmailAddress);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.UserPrincipalName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Name);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DistinguishedName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.MemberOf);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute1);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute2);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute3);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute4);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute5);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute6);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute7);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute8);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute9);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute10);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute11);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute12);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute13);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute14);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.extensionAttribute15);

        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.MsExchHomeServerName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PrimaryUserAddress);
        //    search.PageSize = 1000;
        //    SearchResultCollection Result = search.FindAll();
        //    ActiveDirectoryModel ADM = new ActiveDirectoryModel();
        //    if (Result != null)
        //    {
        //        int no = 1;
        //        for (int counter = 0; counter < Result.Count; counter++)
        //        {
        //            var result = Result[counter];
        //            if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.SamAccountName))
        //            {

        //                ADM.No = no;
        //                ADM.City = (result.Properties[Attributes.ActiveDirectoryAttribute.City].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.City][0] : null);
        //                ADM.Company = (result.Properties[Attributes.ActiveDirectoryAttribute.Company].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Company][0] : null);
        //                ADM.Country = (result.Properties[Attributes.ActiveDirectoryAttribute.Country].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Country][0] : null);
        //                ADM.Department = (result.Properties[Attributes.ActiveDirectoryAttribute.Department].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Department][0] : null);
        //                ADM.DisplayName = (result.Properties[Attributes.ActiveDirectoryAttribute.DisplayName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.DisplayName][0] : null);
        //                ADM.EmailAddress = (result.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress][0] : null);
        //                ADM.EmployeeID = (result.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID][0] : null);

        //                ADM.FirstName = (result.Properties[Attributes.ActiveDirectoryAttribute.FirstName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.FirstName][0] : null);
        //                ADM.JobTitle = (result.Properties[Attributes.ActiveDirectoryAttribute.JobTitle].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.JobTitle][0] : null);
        //                ADM.LastName = (result.Properties[Attributes.ActiveDirectoryAttribute.LastName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.LastName][0] : null);
        //                ADM.Manager = (result.Properties[Attributes.ActiveDirectoryAttribute.Manager].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Manager][0] : null);
        //                ADM.Name = (result.Properties[Attributes.ActiveDirectoryAttribute.Name].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Name][0] : null);
        //                ADM.Notes = (result.Properties[Attributes.ActiveDirectoryAttribute.Notes].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Notes][0] : null);
        //                ADM.Office = (result.Properties[Attributes.ActiveDirectoryAttribute.Office].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Office][0] : null);
        //                ADM.PostalCode = (result.Properties[Attributes.ActiveDirectoryAttribute.PostalCode].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.PostalCode][0] : null);
        //                ADM.Province = (result.Properties[Attributes.ActiveDirectoryAttribute.Province].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Province][0] : null);
        //                ADM.SamAccountName = (result.Properties[Attributes.ActiveDirectoryAttribute.SamAccountName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.SamAccountName][0] : null);
        //                ADM.Street = (result.Properties[Attributes.ActiveDirectoryAttribute.Street].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Street][0] : null);
        //                ADM.Telephone = (result.Properties[Attributes.ActiveDirectoryAttribute.Telephone].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Telephone][0] : null);
        //                ADM.UserPrincipalName = (result.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName][0] : null);
        //                ADM.Website = (result.Properties[Attributes.ActiveDirectoryAttribute.Website].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Website][0] : null);

        //                ADM.ExtensionAttribute1 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute1].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute1][0] : null);
        //                ADM.ExtensionAttribute2 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute2].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute2][0] : null);
        //                ADM.ExtensionAttribute3 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute3].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute3][0] : null);
        //                ADM.ExtensionAttribute4 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute4].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute4][0] : null);
        //                ADM.ExtensionAttribute5 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute5].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute5][0] : null);
        //                ADM.ExtensionAttribute6 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute6].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute6][0] : null);
        //                ADM.ExtensionAttribute7 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute7].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute7][0] : null);
        //                ADM.ExtensionAttribute8 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute8].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute8][0] : null);
        //                ADM.ExtensionAttribute9 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute9].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute9][0] : null);
        //                ADM.ExtensionAttribute10 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute10].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute10][0] : null);
        //                ADM.ExtensionAttribute11 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute11].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute11][0] : null);
        //                ADM.ExtensionAttribute12 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute12].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute12][0] : null);
        //                ADM.ExtensionAttribute13 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute13].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute13][0] : null);
        //                ADM.ExtensionAttribute14 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute14].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute14][0] : null);
        //                ADM.ExtensionAttribute15 = (result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute15].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.extensionAttribute15][0] : null);


        //                ADM.DistinguishedName = (result.Properties[Attributes.ActiveDirectoryAttribute.DistinguishedName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.DistinguishedName][0] : null);

        //                for (int index = 0; index < result.Properties[Attributes.ActiveDirectoryAttribute.MemberOf].Count; index++)
        //                {
        //                    ADM.MemberOf += result.Properties[Attributes.ActiveDirectoryAttribute.MemberOf][index].ToString() + "#";
        //                }

        //                ADM.EnableSkype = 0;
        //                if (Configs.MainConfig.Conf("EnableSkype").Equals("true"))
        //                {
        //                    // Sync
        //                    ADM.PrimaryUserAddress = (result.Properties[Attributes.ActiveDirectoryAttribute.PrimaryUserAddress].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.PrimaryUserAddress][0] : null);
        //                    if (ADM.PrimaryUserAddress != null)
        //                    {
        //                        ADM.EnableSkype = 1;
        //                    }
        //                }
        //                ADM.EnableExchange = 0;
        //                if (Configs.MainConfig.Conf("EnableExchange").Equals("true"))
        //                {
        //                    ADM.MsExchHomeServerName = (result.Properties[Attributes.ActiveDirectoryAttribute.MsExchHomeServerName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.MsExchHomeServerName][0] : null);
        //                    if (ADM.MsExchHomeServerName != null)
        //                    {
        //                        ADM.EnableExchange = 1;
        //                    }
        //                } 

        //                if (Configs.MainConfig.Conf("EnableSharepoint").Equals("true"))
        //                {
        //                    if (!SPM.Exists(sp => sp.SamAccountName == ADM.EmailAddress))
        //                    {
        //                        ADM.EnableSharepoint = 0;
        //                    }
        //                    else
        //                    {
        //                        ADM.EnableSharepoint = 1;
        //                    }
        //                }


        //                no++;
        //            }
        //        }

        //    }
        //    return ADM;
        //}
        //public static string DirectoryDelete(string Parent, string Child)
        //{
        //    try
        //    {
        //        DirectoryEntry directoryObject;
        //        if (Parent == "0")
        //        {
        //            directoryObject = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //        }
        //        else
        //        {
        //            directoryObject = new DirectoryEntry("LDAP://" + Parent, Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //        }

        //        DirectoryEntries children = directoryObject.Children;
        //        try
        //        {
        //            DirectoryEntry badObject = children.Find(Child);
        //            badObject.DeleteTree();
        //            directoryObject.CommitChanges();
        //            return ("the object has been deleted");
        //        }
        //        catch (Exception e)
        //        {
        //            return ("the object was not found or deleted: " + e.ToString());
        //        }
        //    }
        //    catch (DirectoryServicesCOMException e)
        //    {
        //        return ("An Error Occurred: " + e.Message.ToString());
        //    }
        //}
        //public static string DirectoryRename(string Parent, string Child, string New)
        //{
        //    try
        //    {
        //        DirectoryEntry directoryObject;
        //        if (Parent == "0")
        //        {
        //            directoryObject = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //        }
        //        else
        //        {
        //            directoryObject = new DirectoryEntry("LDAP://" + Parent, Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //        }

        //        DirectoryEntries children = directoryObject.Children;
        //        try
        //        {
        //            DirectoryEntry badObject = children.Find(Child);
        //            badObject.Rename(New);
        //            directoryObject.CommitChanges();
        //            return ("the object has been renamed");
        //        }
        //        catch (Exception e)
        //        {
        //            return ("the object was not found or deleted: " + e.ToString());
        //        }
        //    }
        //    catch (DirectoryServicesCOMException e)
        //    {
        //        return ("An Error Occurred: " + e.Message.ToString());
        //    }
        //}
        //public static void DirectoryCreate(string Parent, string Child, string Description = null)
        //{
        //    try
        //    {
        //        DirectoryEntry directoryObject;
        //        if (Parent == "")
        //        {
        //            directoryObject = new DirectoryEntry(Configs.MainConfig.Conf("AdPath") + "/" + Configs.MainConfig.Conf("AdOU"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //        }
        //        else
        //        {
        //            directoryObject = new DirectoryEntry("LDAP://" + Parent, Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //        }

        //        DirectoryEntries children = directoryObject.Children;
        //        try
        //        {
        //            DirectoryEntry badObject = children.Add(Child, "OrganizationalUnit");
        //            if (!String.IsNullOrEmpty(Description))
        //            {
        //                badObject.Properties["description"].Value = Description;
        //            }
        //            badObject.CommitChanges(); 
        //        }
        //        catch (Exception e)
        //        {
        //           //throw new Exception("the object was not found or deleted: " + e.ToString());
        //        }
        //    }
        //    catch (DirectoryServicesCOMException e)
        //    {
        //        //throw new Exception("An Error Occurred: " + e.Message.ToString());
        //    }
        //}
        //public static IEnumerable<ActiveDirectoryModel> GetAll(string SamAccountName)
        //{
        //    List<ActiveDirectoryModel> li = new List<ActiveDirectoryModel>();
        //    DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    DirectorySearcher search = new DirectorySearcher(searchRoot);

        //    if (SamAccountName != null)
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person)(SamAccountName=" + SamAccountName + "))";
        //    }
        //    else
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person))";
        //    }

        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmailAddress);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DisplayName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.FirstName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.LastName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.UserPrincipalName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DistinguishedName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmployeeID);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Country);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Notes);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Company);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Office);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Street);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PostalCode);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Province);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.City);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Website);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Telephone);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.JobTitle);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Department);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Manager);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Name);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.userAccountControl);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.WhenCreated);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.WhenChanged);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.LastLogon);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.MsExchHomeServerName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SIPAddress);


        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.MsExchHomeServerName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PrimaryUserAddress);
        //    search.PageSize = 1000;

        //    SearchResultCollection Result = search.FindAll();

        //    if (Result != null)
        //    {

        //        List<SharePointModel> SPM = null; 
        //        if (Configs.MainConfig.Conf("EnableSharepoint").Equals("true"))
        //        {
        //            SPM = SharePointHelper.Get();
        //        }
        //        int no = 1;
        //        for (int counter = 0; counter < Result.Count; counter++)
        //        {
        //            var result = Result[counter];
        //            if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.SamAccountName))
        //            { 
        //                ActiveDirectoryModel ADM = new ActiveDirectoryModel();
        //                ADM.No = no;
        //                ADM.DisplayName = (result.Properties[Attributes.ActiveDirectoryAttribute.DisplayName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.DisplayName][0] : null);
        //                ADM.EmailAddress = (result.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress][0] : null);
        //                ADM.EmployeeID = (result.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID][0] : null);
        //                ADM.FirstName = (result.Properties[Attributes.ActiveDirectoryAttribute.FirstName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.FirstName][0] : null);
        //                ADM.LastName = (result.Properties[Attributes.ActiveDirectoryAttribute.LastName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.LastName][0] : null);
        //                ADM.SamAccountName = (result.Properties[Attributes.ActiveDirectoryAttribute.SamAccountName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.SamAccountName][0] : null);
        //                ADM.UserPrincipalName = (result.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName][0] : null);
        //                ADM.DistinguishedName = (result.Properties[Attributes.ActiveDirectoryAttribute.DistinguishedName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.DistinguishedName][0] : null);

        //                ADM.Manager = (result.Properties[Attributes.ActiveDirectoryAttribute.Manager].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Manager][0] : null);
        //                ADM.JobTitle = (result.Properties[Attributes.ActiveDirectoryAttribute.JobTitle].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.JobTitle][0] : null);
        //                ADM.Name = (result.Properties[Attributes.ActiveDirectoryAttribute.Name].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Name][0] : null);
        //                ADM.Notes = (result.Properties[Attributes.ActiveDirectoryAttribute.Notes].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Notes][0] : null);
        //                ADM.Office = (result.Properties[Attributes.ActiveDirectoryAttribute.Office].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Office][0] : null);
        //                ADM.PostalCode = (result.Properties[Attributes.ActiveDirectoryAttribute.PostalCode].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.PostalCode][0] : null);
        //                ADM.Province = (result.Properties[Attributes.ActiveDirectoryAttribute.Province].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Province][0] : null);
        //                ADM.Street = (result.Properties[Attributes.ActiveDirectoryAttribute.Street].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Street][0] : null);
        //                ADM.Telephone = (result.Properties[Attributes.ActiveDirectoryAttribute.Telephone].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Telephone][0] : null);
        //                ADM.Website = (result.Properties[Attributes.ActiveDirectoryAttribute.Website].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Website][0] : null);
        //                ADM.City = (result.Properties[Attributes.ActiveDirectoryAttribute.City].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.City][0] : null);
        //                ADM.Company = (result.Properties[Attributes.ActiveDirectoryAttribute.Company].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Company][0] : null);
        //                ADM.Country = (result.Properties[Attributes.ActiveDirectoryAttribute.Country].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Country][0] : null);
        //                ADM.Department = (result.Properties[Attributes.ActiveDirectoryAttribute.Department].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Department][0] : null);

        //                ADM.LastLogon = (result.Properties[Attributes.ActiveDirectoryAttribute.LastLogon].Count > 0 ? DateTime.FromFileTime(((long)result.Properties[Attributes.ActiveDirectoryAttribute.LastLogon][0])) : new DateTime(0));
        //                ADM.WhenCreated = (result.Properties[Attributes.ActiveDirectoryAttribute.WhenCreated].Count > 0 ? (DateTime)result.Properties[Attributes.ActiveDirectoryAttribute.WhenCreated][0] : new DateTime(0));
        //                ADM.WhenChanged = (result.Properties[Attributes.ActiveDirectoryAttribute.WhenChanged].Count > 0 ? (DateTime)result.Properties[Attributes.ActiveDirectoryAttribute.WhenChanged][0] : new DateTime(0));
        //                ADM.MsExchHomeServerName = (result.Properties[Attributes.ActiveDirectoryAttribute.MsExchHomeServerName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.MsExchHomeServerName][0] : null);
        //                ADM.SIPAddress = (result.Properties[Attributes.ActiveDirectoryAttribute.SIPAddress].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.SIPAddress][0] : null);
        //                ADM.SIPServer = null;

        //                int flags = (int)result.Properties[Attributes.ActiveDirectoryAttribute.userAccountControl][0];

        //                ADM.IsEnable = !Convert.ToBoolean(flags & 0x0002);

        //                ADM.EnableSkype = 0;
        //                if (Configs.MainConfig.Conf("EnableSkype").Equals("true"))
        //                {
        //                    // Sync
        //                    ADM.PrimaryUserAddress = (result.Properties[Attributes.ActiveDirectoryAttribute.PrimaryUserAddress].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.PrimaryUserAddress][0] : null);
        //                    if (ADM.PrimaryUserAddress != null)
        //                    {
        //                        ADM.EnableSkype = 1;
        //                    }
        //                }
        //                ADM.EnableExchange = 0;
        //                if (Configs.MainConfig.Conf("EnableExchange").Equals("true"))
        //                {
        //                    ADM.MsExchHomeServerName = (result.Properties[Attributes.ActiveDirectoryAttribute.MsExchHomeServerName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.MsExchHomeServerName][0] : null);
        //                    if (ADM.MsExchHomeServerName != null)
        //                    {
        //                        ADM.EnableExchange = 1;
        //                    }
        //                }


        //                if (Configs.MainConfig.Conf("EnableSharepoint").Equals("true"))
        //                {
        //                    if (!SPM.Exists(sp => sp.SamAccountName == ADM.EmailAddress))
        //                    {
        //                        ADM.EnableSharepoint = 0;
        //                    }
        //                    else
        //                    {
        //                        ADM.EnableSharepoint = 1;
        //                    }
        //                }

        //                li.Add(ADM);
        //                no++;
        //            }
        //        }

        //    }
        //    return li;
        //}
        //public static IEnumerable<ActiveDirectoryModel> Search(string SamAccountName)
        //{
        //    List<ActiveDirectoryModel> li = new List<ActiveDirectoryModel>();
        //    DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    DirectorySearcher search = new DirectorySearcher(searchRoot);

        //    if (SamAccountName != null)
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person)(SamAccountName=" + SamAccountName + "))";
        //    }
        //    else
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person))";
        //    }

        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmailAddress);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DisplayName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.FirstName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.LastName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.UserPrincipalName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DistinguishedName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmployeeID);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Country);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Notes);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Company);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Office);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Street);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PostalCode);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Province);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.City);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Website);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Telephone);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.JobTitle);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Department);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Manager);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Name); 

        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.MsExchHomeServerName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PrimaryUserAddress);
        //    search.PageSize = 1000;

        //    SearchResultCollection Result = search.FindAll();

        //    if (Result != null)
        //    {

        //        int no = 1;
        //        for (int counter = 0; counter < Result.Count; counter++)
        //        {
        //            var result = Result[counter];
        //            if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.SamAccountName) &&
        //                    result.Properties.Contains(Attributes.ActiveDirectoryAttribute.EmailAddress) &&
        //                    result.Properties.Contains(Attributes.ActiveDirectoryAttribute.FirstName) &&
        //                    result.Properties.Contains(Attributes.ActiveDirectoryAttribute.DisplayName)
        //               )
        //            {

        //                ActiveDirectoryModel ADM = new ActiveDirectoryModel();
        //                ADM.No = no;
        //                ADM.DisplayName = (result.Properties[Attributes.ActiveDirectoryAttribute.DisplayName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.DisplayName][0] : null);
        //                ADM.EmailAddress = (result.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress][0] : null);
        //                ADM.EmployeeID = (result.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID][0] : null);
        //                ADM.FirstName = (result.Properties[Attributes.ActiveDirectoryAttribute.FirstName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.FirstName][0] : null);
        //                ADM.LastName = (result.Properties[Attributes.ActiveDirectoryAttribute.LastName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.LastName][0] : null);
        //                ADM.SamAccountName = (result.Properties[Attributes.ActiveDirectoryAttribute.SamAccountName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.SamAccountName][0] : null);
        //                ADM.UserPrincipalName = (result.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName][0] : null);
        //                ADM.DistinguishedName = (result.Properties[Attributes.ActiveDirectoryAttribute.DistinguishedName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.DistinguishedName][0] : null);

        //                ADM.Manager = (result.Properties[Attributes.ActiveDirectoryAttribute.Manager].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Manager][0] : null);
        //                ADM.JobTitle = (result.Properties[Attributes.ActiveDirectoryAttribute.JobTitle].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.JobTitle][0] : null);
        //                ADM.Name = (result.Properties[Attributes.ActiveDirectoryAttribute.Name].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Name][0] : null);
        //                ADM.Notes = (result.Properties[Attributes.ActiveDirectoryAttribute.Notes].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Notes][0] : null);
        //                ADM.Office = (result.Properties[Attributes.ActiveDirectoryAttribute.Office].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Office][0] : null);
        //                ADM.PostalCode = (result.Properties[Attributes.ActiveDirectoryAttribute.PostalCode].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.PostalCode][0] : null);
        //                ADM.Province = (result.Properties[Attributes.ActiveDirectoryAttribute.Province].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Province][0] : null);
        //                ADM.Street = (result.Properties[Attributes.ActiveDirectoryAttribute.Street].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Street][0] : null);
        //                ADM.Telephone = (result.Properties[Attributes.ActiveDirectoryAttribute.Telephone].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Telephone][0] : null);
        //                ADM.Website = (result.Properties[Attributes.ActiveDirectoryAttribute.Website].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Website][0] : null);
        //                ADM.City = (result.Properties[Attributes.ActiveDirectoryAttribute.City].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.City][0] : null);
        //                ADM.Company = (result.Properties[Attributes.ActiveDirectoryAttribute.Company].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Company][0] : null);
        //                ADM.Country = (result.Properties[Attributes.ActiveDirectoryAttribute.Country].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Country][0] : null);
        //                ADM.Department = (result.Properties[Attributes.ActiveDirectoryAttribute.Department].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Department][0] : null);


        //                li.Add(ADM);
        //                no++;
        //            }
        //        }

        //    }
        //    return li;
        //}
        //public static string CountAll(string SamAccountName)
        //{
        //    List<ActiveDirectoryModel> li = new List<ActiveDirectoryModel>();
        //    List<ActiveDirectoryModel> EX = new List<ActiveDirectoryModel>();
        //    List<ActiveDirectoryModel> SB = new List<ActiveDirectoryModel>(); 
        //    DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    DirectorySearcher search = new DirectorySearcher(searchRoot);

        //    if (SamAccountName != null)
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person)(SamAccountName=" + SamAccountName + "))";
        //    }
        //    else
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person))";
        //    }

        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.MsExchHomeServerName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PrimaryUserAddress);

        //    search.PageSize = 1000;
        //    SearchResultCollection Result = search.FindAll();

        //    if (Result != null)
        //    {

        //        for (int counter = 0; counter < Result.Count; counter++)
        //        {
        //            var result = Result[counter];
        //            if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.SamAccountName))
        //            {
        //                ActiveDirectoryModel EXM = new ActiveDirectoryModel();
        //                ActiveDirectoryModel SBM = new ActiveDirectoryModel(); 
        //                ActiveDirectoryModel ADM = new ActiveDirectoryModel();
        //                ADM.SamAccountName = (String)result.Properties[Attributes.ActiveDirectoryAttribute.SamAccountName][0].ToString();
        //                li.Add(ADM);

        //                EXM.MsExchHomeServerName = (result.Properties[Attributes.ActiveDirectoryAttribute.MsExchHomeServerName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.MsExchHomeServerName][0] : null);
        //                if (EXM.MsExchHomeServerName != null)
        //                {
        //                    EXM.EnableExchange = 1;
        //                    EX.Add(EXM);
        //                }

        //                ADM.PrimaryUserAddress = (result.Properties[Attributes.ActiveDirectoryAttribute.PrimaryUserAddress].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.PrimaryUserAddress][0] : null);
        //                if (ADM.PrimaryUserAddress != null)
        //                {
        //                    SBM.EnableSkype = 1;
        //                    SB.Add(SBM);
        //                }
        //            }
        //        }
        //    }

        //    return li.Count.ToString() + "#" + EX.Count.ToString() + "#" + SB.Count.ToString();
        //}
        //public static int CountAllEnable(string SamAccountName)
        //{
        //    List<ActiveDirectoryModel> li = new List<ActiveDirectoryModel>();
        //    DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    DirectorySearcher search = new DirectorySearcher(searchRoot);

        //    if (SamAccountName != null)
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person)(SamAccountName=" + SamAccountName + "))";
        //    }
        //    else
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person))";
        //    }

        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmailAddress);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DisplayName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.FirstName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.userAccountControl);


        //    SearchResultCollection Result = search.FindAll();
        //    if (Result != null)
        //    {

        //        for (int counter = 0; counter < Result.Count; counter++)
        //        {
        //            var result = Result[counter];
        //            if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.SamAccountName) &&
        //                    result.Properties.Contains(Attributes.ActiveDirectoryAttribute.EmailAddress) &&
        //                    result.Properties.Contains(Attributes.ActiveDirectoryAttribute.FirstName) &&
        //                    result.Properties.Contains(Attributes.ActiveDirectoryAttribute.DisplayName)
        //               )
        //            {
        //                ActiveDirectoryModel ADM = new ActiveDirectoryModel();
        //                int flags = (int)result.Properties[Attributes.ActiveDirectoryAttribute.userAccountControl][0];

        //                bool IsEnable = !Convert.ToBoolean(flags & 0x0002);

        //                if (IsEnable)
        //                {
        //                    ADM.IsEnable = IsEnable;
        //                    li.Add(ADM);
        //                }
        //            }
        //        }
        //    }

        //    return li.Count;
        //}
        //public static int CheckGroup(string SamAccountName)
        //{
        //    DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    DirectorySearcher search = new DirectorySearcher(searchRoot);
        //    // 
        //    search.Filter = "(&(objectClass=group)(SamAccountName=" + SamAccountName + "))";

        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.Name);
        //    SearchResultCollection Result = search.FindAll();
        //    return Result.Count;
        //}

        //public static GroupModel DetailGroup(string SamAccountName)
        //{
        //    DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    DirectorySearcher search = new DirectorySearcher(searchRoot);
        //    // 
        //    search.Filter = "(&(objectClass=group)(SamAccountName=" + SamAccountName + "))";

        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.Name);
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.Email);
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.SID);
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.Info);
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.Description);
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.DistinguishedName);
        //    search.PropertiesToLoad.Add(Attributes.GroupAttribute.Member);
        //    SearchResultCollection Result = search.FindAll();
        //    GroupModel ADM = new GroupModel();
        //    if (Result != null)
        //    {
        //        int no = 1;
        //        for (int counter = 0; counter < Result.Count; counter++)
        //        {
        //            var result = Result[counter];
        //            if (result.Properties.Contains(Attributes.GroupAttribute.SamAccountName) &&
        //                    result.Properties.Contains(Attributes.GroupAttribute.Name)
        //               )
        //            {
        //                ADM.No = no;
        //                ADM.Name = (result.Properties[Attributes.GroupAttribute.Name].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.Name][0] : null);
        //                ADM.SamAccountName = (result.Properties[Attributes.GroupAttribute.SamAccountName].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.SamAccountName][0] : null);
        //                byte[] sid_ = (result.Properties[Attributes.GroupAttribute.SID].Count > 0 ? result.Properties[Attributes.GroupAttribute.SID][0] as byte[] : null);
        //                ADM.Info = (result.Properties[Attributes.GroupAttribute.Info].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.Info][0] : null);
        //                ADM.Description = (result.Properties[Attributes.GroupAttribute.Description].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.Description][0] : null);
        //                ADM.DistinguishedName = (result.Properties[Attributes.GroupAttribute.DistinguishedName].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.DistinguishedName][0] : null);
        //                SecurityIdentifier sid = new SecurityIdentifier(sid_, 0);
        //                ADM.SID = sid.Value;
        //                foreach (object dn in result.Properties[Attributes.GroupAttribute.Member])
        //                {
        //                    ADM.Member += dn + "#";
        //                }

        //                ADM.Email = (result.Properties[Attributes.GroupAttribute.Email].Count > 0 ? (String)result.Properties[Attributes.GroupAttribute.Email][0] : null);
        //                no++;
        //            }
        //        }

        //    }
        //    return ADM;
        //}
        //public static IEnumerable<ActiveDirectoryModel> GetManager(string SamAccountName)
        //{
        //    List<ActiveDirectoryModel> li = new List<ActiveDirectoryModel>();
        //    DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    DirectorySearcher search = new DirectorySearcher(searchRoot);

        //    if (SamAccountName != null)
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person)(SamAccountName=" + SamAccountName + "))";
        //    }
        //    else
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person))";
        //    }

        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.FirstName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmailAddress);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DisplayName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DistinguishedName);
        //    SearchResultCollection Result = search.FindAll();

        //    if (Result != null)
        //    {
        //        int no = 1;
        //        for (int counter = 0; counter < Result.Count; counter++)
        //        {
        //            var result = Result[counter];
        //            if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.SamAccountName) &&
        //                    result.Properties.Contains(Attributes.ActiveDirectoryAttribute.EmailAddress) &&
        //                    result.Properties.Contains(Attributes.ActiveDirectoryAttribute.FirstName) &&
        //                    result.Properties.Contains(Attributes.ActiveDirectoryAttribute.DisplayName)
        //               )
        //            {

        //                ActiveDirectoryModel ADM = new ActiveDirectoryModel();
        //                ADM.No = no;
        //                ADM.DisplayName = (result.Properties[Attributes.ActiveDirectoryAttribute.DisplayName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.DisplayName][0] : null);
        //                ADM.DistinguishedName = (result.Properties[Attributes.ActiveDirectoryAttribute.DistinguishedName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.DistinguishedName][0] : null);
        //                li.Add(ADM);
        //                no++;
        //            }
        //        }

        //    }
        //    return li;
        //}

        //public static string SamAccountName(string sAn)
        //{
        //    string SamAccountName = "";
        //    if (GetDetailBySamAccountName(sAn) == 0)
        //    {
        //        SamAccountName = sAn;
        //    }
        //    else
        //    {
        //        if (GetDetailBySamAccountName(sAn + "01") == 0)
        //        {
        //            SamAccountName = sAn + "01";
        //        }
        //        else
        //        {
        //            if (GetDetailBySamAccountName(sAn + "02") == 0)
        //            {
        //                SamAccountName = sAn + "02";
        //            }
        //            else
        //            {
        //                if (GetDetailBySamAccountName(sAn + "03") == 0)
        //                {
        //                    SamAccountName = sAn + "03";
        //                }
        //                else
        //                {
        //                    if (GetDetailBySamAccountName(sAn + "04") == 0)
        //                    {
        //                        SamAccountName = sAn + "04";
        //                    }
        //                    else
        //                    {
        //                        if (GetDetailBySamAccountName(sAn + "05") == 0)
        //                        {
        //                            SamAccountName = sAn + "05";
        //                        }
        //                        else
        //                        {
        //                            SamAccountName = sAn + "07";
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return SamAccountName;
        //} 

        //public static ActiveDirectoryModel GetReturnLogin(string upn)
        //{
        //    DirectoryEntry searchRoot = new DirectoryEntry(Configs.MainConfig.Conf("AdPath"), Configs.MainConfig.Conf("AdAccount"), Configs.MainConfig.Conf("AdPassword"));
        //    DirectorySearcher search = new DirectorySearcher(searchRoot);
        //    //
        //    if (upn != null)
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person)(mail=" + upn + "))";
        //    }
        //    else
        //    {
        //        search.Filter = "(&(objectClass=user)(objectCategory=person))";
        //    }


        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName); 
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmailAddress);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DisplayName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Country);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Notes);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmployeeID);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Company);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.SamAccountName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.FirstName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.LastName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Office);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Street);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PostalCode);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Province);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.City);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Website);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Telephone);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.JobTitle);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DisplayName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Department);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Manager);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.EmailAddress);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.UserPrincipalName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.Name);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.DistinguishedName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.MemberOf);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.MsExchHomeServerName);
        //    search.PropertiesToLoad.Add(Attributes.ActiveDirectoryAttribute.PrimaryUserAddress); 


        //    search.PageSize = 1000;
        //    SearchResultCollection Result = search.FindAll();
        //    ActiveDirectoryModel ADM = new ActiveDirectoryModel();

        //    List<SharePointModel> SPM = null;
        //    if (Configs.MainConfig.Conf("EnableSharepoint").Equals("true"))
        //    {
        //        SPM = SharePointHelper.Get();
        //    }

        //    if (Result != null)
        //    {
        //        int no = 1;
        //        for (int counter = 0; counter < Result.Count; counter++)
        //        {
        //            var result = Result[counter];
        //            if (result.Properties.Contains(Attributes.ActiveDirectoryAttribute.SamAccountName))
        //            {

        //                ADM.City = (result.Properties[Attributes.ActiveDirectoryAttribute.City].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.City][0] : null);
        //                ADM.Company = (result.Properties[Attributes.ActiveDirectoryAttribute.Company].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Company][0] : null);
        //                ADM.Country = (result.Properties[Attributes.ActiveDirectoryAttribute.Country].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Country][0] : null);
        //                ADM.Department = (result.Properties[Attributes.ActiveDirectoryAttribute.Department].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Department][0] : null);
        //                ADM.DisplayName = (result.Properties[Attributes.ActiveDirectoryAttribute.DisplayName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.DisplayName][0] : null);
        //                ADM.EmailAddress = (result.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.EmailAddress][0] : null);
        //                ADM.EmployeeID = (result.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.EmployeeID][0] : null);

        //                ADM.FirstName = (result.Properties[Attributes.ActiveDirectoryAttribute.FirstName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.FirstName][0] : null);
        //                ADM.JobTitle = (result.Properties[Attributes.ActiveDirectoryAttribute.JobTitle].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.JobTitle][0] : null);
        //                ADM.LastName = (result.Properties[Attributes.ActiveDirectoryAttribute.LastName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.LastName][0] : null);
        //                ADM.Manager = (result.Properties[Attributes.ActiveDirectoryAttribute.Manager].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Manager][0] : null);
        //                ADM.Name = (result.Properties[Attributes.ActiveDirectoryAttribute.Name].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Name][0] : null);
        //                ADM.Notes = (result.Properties[Attributes.ActiveDirectoryAttribute.Notes].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Notes][0] : null);
        //                ADM.Office = (result.Properties[Attributes.ActiveDirectoryAttribute.Office].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Office][0] : null);
        //                ADM.PostalCode = (result.Properties[Attributes.ActiveDirectoryAttribute.PostalCode].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.PostalCode][0] : null);
        //                ADM.Province = (result.Properties[Attributes.ActiveDirectoryAttribute.Province].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Province][0] : null);
        //                ADM.SamAccountName = (result.Properties[Attributes.ActiveDirectoryAttribute.SamAccountName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.SamAccountName][0] : null);
        //                ADM.Street = (result.Properties[Attributes.ActiveDirectoryAttribute.Street].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Street][0] : null);
        //                ADM.Telephone = (result.Properties[Attributes.ActiveDirectoryAttribute.Telephone].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Telephone][0] : null);
        //                ADM.UserPrincipalName = (result.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.UserPrincipalName][0] : null);
        //                ADM.Website = (result.Properties[Attributes.ActiveDirectoryAttribute.Website].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.Website][0] : null);


        //                ADM.DistinguishedName = (result.Properties[Attributes.ActiveDirectoryAttribute.DistinguishedName].Count > 0 ? (String)result.Properties[Attributes.ActiveDirectoryAttribute.DistinguishedName][0] : null);

        //                for (int index = 0; index < result.Properties[Attributes.ActiveDirectoryAttribute.MemberOf].Count; index++)
        //                {
        //                    ADM.MemberOf += result.Properties[Attributes.ActiveDirectoryAttribute.MemberOf][index].ToString() + "#";
        //                }

        //                no++;
        //            }
        //        }

        //    }
        //    return ADM;
        //}
    }

}

