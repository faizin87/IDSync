using Microsoft.SharePoint.Client;
using IDSync.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace IDSync.Helpers
{
    public static partial class SharePointHelper
    {
        public static List<SharePointModel> Get(string SamAccountName = null)
        {
            List<SharePointModel> li = new List<SharePointModel>();
             
                ClientContext clientContext = SpClientContext();
                GroupCollection collGroup = clientContext.Web.SiteGroups;
                clientContext.Credentials = SpNetworkCredential();
                Web web = clientContext.Web;

                string[] SPGX = Configs.MainConfig.Conf("SharePointGroup").Split('↕');
                Group group = null;
                if (SPGX.Length > 1)
                {
                    group = web.SiteGroups.GetByName(SPGX[0].Replace("0",""));
                }
                else
                {
                    group = web.SiteGroups.GetByName(Configs.MainConfig.Conf("SharePointGroup").Replace("0", ""));
                }

                clientContext.Load(group.Users); 
                clientContext.ExecuteQuery();
                int no = 1;
                foreach (User member in group.Users)
                {
                    if (!String.IsNullOrEmpty(SamAccountName))
                    {
                        if (member.Email.ToString().Contains(SamAccountName))
                        {
                            SharePointModel ADM = new SharePointModel();
                            ADM.No = no;
                            ADM.Name = member.LoginName;
                            ADM.DisplayName = member.Title;
                            ADM.SamAccountName = member.Email;
                            ADM.SharepointURL = member.Context.Url; 
                        li.Add(ADM);
                        }
                    }
                    else
                    {
                        SharePointModel ADM = new SharePointModel();
                        ADM.No = no;
                        ADM.Name = member.LoginName;
                        ADM.DisplayName = member.Title;
                        ADM.SamAccountName = member.Email;
                        ADM.SharepointURL = member.Context.Url; 
                    li.Add(ADM);
                    } 
                } 
            return li;
        }
        public static NetworkCredential SpNetworkCredential(string SpUser = null, string SpPassword = null)
        {
            string User = "";
            string Password = "";
            if (String.IsNullOrEmpty(SpUser))
            {
                string[] UserX = Configs.MainConfig.Conf("SharePointUser").Split('↕');
                if (UserX.Length > 1)
                {
                    User = UserX[0];
                }
                else
                {
                    User = Configs.MainConfig.Conf("SharePointUser");
                }

            }
            else
            {
                User = SpUser;
            }
            if (String.IsNullOrEmpty(SpPassword))
            {
                string[] PasswordX = Configs.MainConfig.Conf("SharePointPassword").Split('↕');
                if (PasswordX.Length > 1)
                {
                    Password = PasswordX[0];
                }
                else
                {
                    Password = Configs.MainConfig.Conf("SharePointPassword");
                }

            }
            else
            {
                Password = SpPassword;
            }
            NetworkCredential NetworkCredentials = new NetworkCredential(User, Password, Configs.MainConfig.Conf("AdDomain"));
            return NetworkCredentials;
        }

        public static ClientContext SpClientContext(string SpURL = null)
        {
            ClientContext ctx;
            if (String.IsNullOrEmpty(SpURL))
            { 
                string[] SPUX = Configs.MainConfig.Conf("SharePointUrl").Split('↕');
                if(SPUX.Length > 1)
                { 
                    ctx = new ClientContext(SPUX[0]);
                }
                else
                {
                    ctx = new ClientContext(Configs.MainConfig.Conf("SharePointUrl"));
                }
                
            }
            else
            {
                ctx = new ClientContext(SpURL);
            }

            return ctx;
        }

        public static void Save(SharePointModel Model, string SpURL = null, string SpGroup = null, string SpUser = null, string SpPassword = null)
        {
            try
            {
                ClientContext clientContext = SpClientContext(SpURL);
                GroupCollection collGroup = clientContext.Web.SiteGroups;
                clientContext.Credentials = SpNetworkCredential(SpUser, SpPassword);
                Web web = clientContext.Web;
                User user = web.EnsureUser(Model.SamAccountName); // samAccount
                                                                  // Get the specific site group by name  
                Group group = null;
                if (SpGroup == null || SpGroup == "")
                {
                    string[] SPGX = Configs.MainConfig.Conf("SharePointGroup").Split('↕');

                    if (SPGX.Length > 1)
                    {
                        group = web.SiteGroups.GetByName(SPGX[0].Replace("0", ""));
                    }
                    else
                    {
                        group = web.SiteGroups.GetByName(Configs.MainConfig.Conf("SharePointGroup").Replace("0", ""));
                    }
                }
                else
                {
                    group = web.SiteGroups.GetByName(SpGroup);
                }

                // Add a user to the specific group  
                group.Users.AddUser(user);
                // Execute the query to the server  
                clientContext.ExecuteQuery();
            }
            catch(Exception e)
            {
                //throw new Exception(e.Message.ToString());
            }
           
        }

        public static void Delete(string SamAccountName)
        { 
            ClientContext clientContext = SpClientContext(null);
            GroupCollection collGroup = clientContext.Web.SiteGroups;
            clientContext.Credentials = SpNetworkCredential();
            Web web = clientContext.Web;
            User user = web.EnsureUser(SamAccountName); // samAccount
            // Get the specific site group by name   

            string[] SPGX = Configs.MainConfig.Conf("SharePointGroup").Split('↕');
            Group group = null;
            if (SPGX.Length > 1)
            {
                group = web.SiteGroups.GetByName(SPGX[0].Replace("0", ""));
            }
            else
            {
                group = web.SiteGroups.GetByName(Configs.MainConfig.Conf("SharePointGroup").Replace("0", ""));
            } 
            // Add a user to the specific group   
            group.Users.Remove(user);
            // Execute the query to the server  
            clientContext.ExecuteQuery();  

        }

        public static int CountAll(string SamAccountName = null)
        {
            List<SharePointModel> li = new List<SharePointModel>();
            Group group = null;
            try
            {
                ClientContext clientContext = SpClientContext();
                GroupCollection collGroup = clientContext.Web.SiteGroups;
                clientContext.Credentials = SpNetworkCredential();
                Web web = clientContext.Web;

                string[] SPGX = Configs.MainConfig.Conf("SharePointGroup").Split('↕');
                if (SPGX.Length > 1)
                {
                    group = web.SiteGroups.GetByName(SPGX[0].Replace("0", ""));
                }
                else
                {
                    group = web.SiteGroups.GetByName(Configs.MainConfig.Conf("SharePointGroup").Replace("0", ""));
                }

                clientContext.Load(group.Users);
                clientContext.ExecuteQuery();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
           
            int no = 1;
            foreach (User member in group.Users)
            {
                if (!String.IsNullOrEmpty(SamAccountName))
                {
                    if (member.Email.ToString().Contains(SamAccountName))
                    {
                        SharePointModel ADM = new SharePointModel();
                        ADM.No = no;
                        ADM.Name = member.LoginName;
                        ADM.DisplayName = member.Title;
                        ADM.SamAccountName = member.Email;
                        ADM.SharepointURL = member.Context.Url; 
                        li.Add(ADM);
                    }
                }
                else
                {
                    SharePointModel ADM = new SharePointModel();
                    ADM.No = no;
                    ADM.Name = member.LoginName;
                    ADM.DisplayName = member.Title;
                    ADM.SamAccountName = member.Email;
                    ADM.SharepointURL = member.Context.Url; 
                    li.Add(ADM);
                }

                no++;
            }
            return li.Count;
        }
    }
}