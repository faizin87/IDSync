﻿using IDSync.ApiModels; 
using System.Collections.Generic; 
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IDSync.Helpers
{
    public static partial class ExchangeHelper
    {
        public static async Task<List<ExchangeModel>> GetAll(string sortOrder="", string currentFilter="", string searchString="", int? page=1)
        {
            //
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ex/"+ page + "/GetAll?sortOrder="+ sortOrder + "&currentFilter="+currentFilter+"&searchString="+searchString;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            HttpResponseMessage response = await client.GetAsync(tokenServiceUrl);
            if (response.IsSuccessStatusCode)
            {
                List<ExchangeModel> dataExchanges = await response.Content.ReadAsAsync<List<ExchangeModel>>(); 
                return dataExchanges;
            }
            return null;
        }

        public static async Task<string> Save(ExchangeSaveModel Model)
        {
            //api/v1/Ex/Save
            var tokenServiceUrl = Startup.apiUrl + "api/v1/Ex/Save";
            var client = new HttpClient();
            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>(); 
            keyValues.Add(new KeyValuePair<string, string>("UserPrincipalName",Model.UserPrincipalName)); 
            keyValues.Add(new KeyValuePair<string, string>("Database",Model.Database)); 

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", CookiesHelper.getCookies("Token"));

            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(keyValues);

            HttpResponseMessage response = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            return "Error";
        }

        //   public static List<ExchangeCalendarModel> RetrieveAppointments(string folderId, string mailBox, DateTime startDate, DateTime endDate, bool RootFolder=false)
        //   {
        //       List<ExchangeCalendarModel> li = new List<ExchangeCalendarModel>();

        //       ExchangeService exchangeService;
        //       // load credential
        //       exchangeService = Helpers.ExchangeHelper.ExchangeNetworkCredential(mailBox);

        //       exchangeService.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, mailBox);

        //       folderId = folderId.Replace(" ", "+");
        //       CalendarFolder folder;

        //       if (RootFolder == true)
        //       {
        //           folder = CalendarFolder.Bind(exchangeService, WellKnownFolderName.Calendar); 
        //       }
        //       else
        //       {
        //           folder = CalendarFolder.Bind(exchangeService, folderId);
        //       }

        //       CalendarView view = new CalendarView(startDate, endDate);

        //       FindItemsResults<Appointment> results = folder.FindAppointments(view);
        //       foreach (Appointment appointment in results)
        //       {
        //           Appointment appointmentDetailed = Appointment.Bind(exchangeService, appointment.Id, new PropertySet(BasePropertySet.FirstClassProperties) { RequestedBodyType = BodyType.Text });

        //           ExchangeCalendarModel EM = new ExchangeCalendarModel();

        //           EM.ID = appointment.Id.ToString();
        //           EM.Subject = appointment.Subject.ToString();
        //           EM.StartTime = Convert.ToDateTime(appointment.Start.ToString("M/d/yyyy h:mm tt"));
        //           EM.EndTime = Convert.ToDateTime(appointment.End.ToString("M/d/yyyy h:mm tt"));
        //           EM.Body = appointmentDetailed.Body.Text;
        //           li.Add(EM);

        //       }
        //       //Set it back to null so that any actions that will be taken using the exchange service
        //       //applies to impersonating account (i.e.account used in network credentials)
        //       exchangeService.ImpersonatedUserId = null;
        //       return li;
        //   }

        //   public static CalendarFolder MakeFolder(string mailBox, string FolderName)
        //   {
        //       ExchangeService exchangeService;
        //       exchangeService = ExchangeNetworkCredential(mailBox);
        //       // Create a custom folder class.

        //       CalendarFolder folder = new CalendarFolder(exchangeService);
        //       folder.DisplayName = FolderName; 
        //       folder.Save(WellKnownFolderName.Calendar);
        //       return folder;
        //   }

        //   public static void DeleteFolder(string mailBox, string ID)
        //   {
        //       ExchangeService exchangeService;
        //       exchangeService = ExchangeNetworkCredential(mailBox);
        //       // Create a custom folder class.

        //       Folder folder = Folder.Bind(exchangeService, ID);
        //       folder.Delete(DeleteMode.HardDelete); 
        //   }

        //   public static List<ExchangeFolderModel> ListFolder(string mailBox, int limit=100)
        //   {

        //       List<ExchangeFolderModel> li = new List<ExchangeFolderModel>();
        //       ExchangeService exchangeService;
        //       exchangeService = ExchangeNetworkCredential(mailBox);

        //       // Get all the folders in the message's root folder.
        //       Folder rootfolder = Folder.Bind(exchangeService, WellKnownFolderName.Calendar); 

        //       rootfolder.Load();
        //       foreach (Folder folder in rootfolder.FindFolders(new FolderView(limit)))
        //       {
        //           ExchangeFolderModel EM = new ExchangeFolderModel();
        //           EM.Id = folder.Id.ToString();
        //           EM.DisplayName = folder.DisplayName;
        //           li.Add(EM);
        //       }
        //       return li;
        //   }

        //   public static string GUID()
        //   {
        //       Guid g = Guid.NewGuid();
        //       string GuidString = Convert.ToBase64String(g.ToByteArray());
        //       GuidString = GuidString.Replace("=", "");
        //       GuidString = GuidString.Replace("+", "");
        //       return GuidString;
        //   }

        //   public static int CountAll(string SamAccountName = null)
        //   {
        //       List<ExchangeModel> li = new List<ExchangeModel>();

        //       Collection<PSObject> Result = null;
        //       PSCredential ExchangePSCredUser = new PSCredential(Configs.MainConfig.Conf("ExchangeUsername"), CryptHelpers.EncPassword(Configs.MainConfig.Conf("ExchangePassword")));

        //       WSManConnectionInfo ExchangePSConnection = new WSManConnectionInfo(new Uri(Configs.MainConfig.Conf("ExchangeLiveIdConnectionUri")), Configs.MainConfig.Conf("ExchangePSSchema"), ExchangePSCredUser);
        //       switch (Configs.MainConfig.Conf("ExchangeMecanism"))
        //       {
        //           case "Basic":
        //               ExchangePSConnection.AuthenticationMechanism = AuthenticationMechanism.Basic;
        //               break;
        //           case "Kerberos":
        //               ExchangePSConnection.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
        //               ExchangePSConnection.SkipRevocationCheck = true;
        //               break;
        //           case "Default":
        //               ExchangePSConnection.AuthenticationMechanism = AuthenticationMechanism.Default;
        //               ExchangePSConnection.SkipRevocationCheck = true;
        //               break;
        //           default:
        //               break;
        //       }
        //       Runspace RunSpace = RunspaceFactory.CreateRunspace(ExchangePSConnection);

        //       PowerShell PS = PowerShell.Create();
        //       PSCommand Command = new PSCommand();

        //       Command.AddCommand("Get-Mailbox");
        //       Command.AddParameter("ResultSize", "Unlimited");
        //       PS.Commands = Command;

        //       try
        //       {
        //           RunSpace.Open();
        //           PS.Runspace = RunSpace;
        //           Result = PS.Invoke();
        //       }
        //       catch (Exception e)
        //       {
        //           throw new Exception("Error Exception:"+e.Message.ToString());
        //       }
        //       finally
        //       {
        //           RunSpace.Dispose();
        //           RunSpace = null;
        //           PS.Dispose();
        //           PS = null;
        //       }
        //       if (Result != null)
        //       {
        //           int no = 1;
        //           foreach (var result in Result)
        //           {
        //               if (!String.IsNullOrEmpty(SamAccountName))
        //               {
        //                   if (result.Properties[Attributes.SkypeAttribute.SamAccountName].Value.ToString().Contains(SamAccountName))
        //                   {
        //                       ExchangeModel ADM = new ExchangeModel();
        //                       ADM.No = no;
        //                       ADM.Name = result.Properties[Attributes.ExchangeAttribute.Name].Value.ToString();
        //                       ADM.Username = result.Properties[Attributes.ExchangeAttribute.SamAccountName].Value.ToString();
        //                       ADM.DisplayName = result.Properties[Attributes.ExchangeAttribute.DisplayName].Value.ToString();
        //                       ADM.DistinguishedName = result.Properties[Attributes.ExchangeAttribute.OrganizationalUnit].Value.ToString();
        //                       ADM.SamAccountName = result.Properties[Attributes.ExchangeAttribute.SamAccountName].Value.ToString();
        //                       ADM.UserPrincipalName = result.Properties[Attributes.ExchangeAttribute.UserPrincipalName].Value.ToString();
        //                       li.Add(ADM);
        //                   }
        //               }
        //               else
        //               {
        //                   ExchangeModel ADM = new ExchangeModel();
        //                   ADM.No = no;
        //                   ADM.Name = result.Properties[Attributes.ExchangeAttribute.Name].Value.ToString();
        //                   ADM.Username = result.Properties[Attributes.ExchangeAttribute.SamAccountName].Value.ToString();
        //                   ADM.DisplayName = result.Properties[Attributes.ExchangeAttribute.DisplayName].Value.ToString();
        //                   ADM.DistinguishedName = result.Properties[Attributes.ExchangeAttribute.OrganizationalUnit].Value.ToString();
        //                   ADM.SamAccountName = result.Properties[Attributes.ExchangeAttribute.SamAccountName].Value.ToString();
        //                   ADM.UserPrincipalName = result.Properties[Attributes.ExchangeAttribute.UserPrincipalName].Value.ToString();
        //                   li.Add(ADM);
        //               }
        //               no++;
        //           }
        //       }
        //       return li.Count - 1;
        //   }
    }
}