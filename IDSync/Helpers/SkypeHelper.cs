//using IDSync.Models;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Management.Automation;
//using System.Management.Automation.Runspaces;

//namespace IDSync.Helpers
//{
//    public static partial class SkypeHelper
//    {

//        public static void Save(SkypeModel Model)
//        {
//            PSCredential SkypePSCredUser = new PSCredential(Configs.MainConfig.Conf("SkypeUsername"), CryptHelpers.EncPassword(Configs.MainConfig.Conf("SkypePassword")));

//            WSManConnectionInfo SkypePSConnection = new WSManConnectionInfo(new Uri(Configs.MainConfig.Conf("SkypeLiveIdConnectionUri")), Configs.MainConfig.Conf("SkypePSSchema"), SkypePSCredUser);
//            switch (Configs.MainConfig.Conf("SkypeMecanism"))
//            {
//                case "Basic":
//                    SkypePSConnection.AuthenticationMechanism = AuthenticationMechanism.Basic;
//                    break;
//                case "Kerberos":
//                    SkypePSConnection.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
//                    SkypePSConnection.SkipRevocationCheck = true;
//                    break;
//                case "Default":
//                    SkypePSConnection.AuthenticationMechanism = AuthenticationMechanism.Default;
//                    SkypePSConnection.SkipRevocationCheck = true;
//                    break;
//                default:
//                    break;
//            }

//            Runspace RunSpace = RunspaceFactory.CreateRunspace(SkypePSConnection);

//            PowerShell PS = PowerShell.Create();
//            PSCommand Command = new PSCommand();
//            Command.AddCommand("Enable-CsUser");
//            Command.AddParameter("Identity", Model.SamAccountName);
//            Command.AddParameter("RegistrarPool", Configs.MainConfig.Conf("SkypeDefaultRegistrarPool"));
//            Command.AddParameter("SipAddressType", Configs.MainConfig.Conf("SkypeDefaultSipAddressType"));
//            Command.AddParameter("SipDomain", Configs.MainConfig.Conf("AdDomain"));

//            PS.Commands = Command;

//            try
//            {
//                RunSpace.Open();
//                PS.Runspace = RunSpace;
//                Collection<PSObject> Result = PS.Invoke();
//            }
//            catch (Exception e)
//            {

//                //throw new Exception(e.Message);
//            }
//            finally
//            {
//                RunSpace.Close();
//                RunSpace = null;
//                PS.Dispose();
//                PS = null;
//            } 
//        }

//        public static List<SkypeModel> Get(string SamAccountName=null)
//        {
//            List<SkypeModel> li = new List<SkypeModel>();
//            Collection<PSObject> Result = null;
//            PSCredential SkypePSCredUser = new PSCredential(Configs.MainConfig.Conf("SkypeUsername"), CryptHelpers.EncPassword(Configs.MainConfig.Conf("SkypePassword")));
//            WSManConnectionInfo SkypePSConnection = new WSManConnectionInfo(new Uri(Configs.MainConfig.Conf("SkypeLiveIdConnectionUri")), Configs.MainConfig.Conf("SkypePSSchema"), SkypePSCredUser);
//            switch (Configs.MainConfig.Conf("SkypeMecanism"))
//            {
//                case "Basic":
//                    SkypePSConnection.AuthenticationMechanism = AuthenticationMechanism.Basic;
//                    break;
//                case "Kerberos":
//                    SkypePSConnection.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
//                    SkypePSConnection.SkipRevocationCheck = true;
//                    break;
//                case "Default":
//                    SkypePSConnection.AuthenticationMechanism = AuthenticationMechanism.Default;
//                    SkypePSConnection.SkipRevocationCheck = true;
//                    break;
//                default:
//                    break;
//            }

//            Runspace RunSpace = RunspaceFactory.CreateRunspace(SkypePSConnection);

//            PowerShell PS = PowerShell.Create();
//            PSCommand Command = new PSCommand();

//            Command.AddCommand("Get-CSUser");

//            PS.Commands = Command;

//            try
//            {
//                RunSpace.Open();
//                PS.Runspace = RunSpace;
//                Result = PS.Invoke();
                
//            }
//            catch (Exception e)
//            {
//                throw new Exception("Error Exception: " + e.ToString());
//            }
//            finally
//            {
//                RunSpace.Dispose();
//                RunSpace = null;
//                PS.Dispose();
//                PS = null;
//            }
             
//            if (Result != null)
//            {
//                int no = 1;
//                foreach (var result in Result)
//                {
//                    if (!String.IsNullOrEmpty(SamAccountName))
//                    {
//                        if (result.Properties[Attributes.SkypeAttribute.SamAccountName].Value.ToString().Contains(SamAccountName))
//                        {
//                            SkypeModel ADM = new SkypeModel();
//                            ADM.No = no;
//                            ADM.Name = result.Properties[Attributes.SkypeAttribute.Name].Value.ToString();
//                            ADM.DisplayName = result.Properties[Attributes.SkypeAttribute.DisplayName].Value.ToString();
//                            ADM.SamAccountName = result.Properties[Attributes.SkypeAttribute.SamAccountName].Value.ToString();
//                            ADM.UserPrincipalName = result.Properties[Attributes.SkypeAttribute.UserPrincipalName].Value.ToString();
//                            ADM.RegistrarPool = result.Properties[Attributes.SkypeAttribute.RegistrarPool].Value.ToString();
//                            li.Add(ADM);
//                        }
//                    }
//                    else
//                    {
//                        SkypeModel ADM = new SkypeModel();
//                        ADM.No = no;
//                        ADM.Name = result.Properties[Attributes.SkypeAttribute.Name].Value.ToString();
//                        ADM.DisplayName = result.Properties[Attributes.SkypeAttribute.DisplayName].Value.ToString();
//                        ADM.SamAccountName = result.Properties[Attributes.SkypeAttribute.SamAccountName].Value.ToString();
//                        ADM.UserPrincipalName = result.Properties[Attributes.SkypeAttribute.UserPrincipalName].Value.ToString();
//                        ADM.RegistrarPool = result.Properties[Attributes.SkypeAttribute.RegistrarPool].Value.ToString();
//                        li.Add(ADM);
//                    }
                    
//                    no++;
//                }
//            } 
            
//            return li;
//        }

//        public static int CountAll(string SamAccountName = null)
//        { 
//            Collection<PSObject> Result = null;
//            PSCredential SkypePSCredUser = new PSCredential(Configs.MainConfig.Conf("SkypeUsername"), CryptHelpers.EncPassword(Configs.MainConfig.Conf("SkypePassword")));
//            WSManConnectionInfo SkypePSConnection = new WSManConnectionInfo(new Uri(Configs.MainConfig.Conf("SkypeLiveIdConnectionUri")), Configs.MainConfig.Conf("SkypePSSchema"), SkypePSCredUser);
//            switch (Configs.MainConfig.Conf("SkypeMecanism"))
//            {
//                case "Basic":
//                    SkypePSConnection.AuthenticationMechanism = AuthenticationMechanism.Basic;
//                    break;
//                case "Kerberos":
//                    SkypePSConnection.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
//                    SkypePSConnection.SkipRevocationCheck = true;
//                    break;
//                case "Default":
//                    SkypePSConnection.AuthenticationMechanism = AuthenticationMechanism.Default;
//                    SkypePSConnection.SkipRevocationCheck = true;
//                    break;
//                default:
//                    break;
//            }

//            Runspace RunSpace = RunspaceFactory.CreateRunspace(SkypePSConnection);

//            PowerShell PS = PowerShell.Create();
//            PSCommand Command = new PSCommand();

//            Command.AddCommand("Get-CSUser");

//            PS.Commands = Command;

//            try
//            {
//                RunSpace.Open();
//                PS.Runspace = RunSpace;
//                Result = PS.Invoke();

//            }
//            catch (Exception e)
//            {
//                throw new Exception("Error Exception: " + e.ToString());
//            }
//            finally
//            {
//                RunSpace.Dispose();
//                RunSpace = null;
//                PS.Dispose();
//                PS = null;
//            }
//            return Result.Count; ;
//        }
//    }
//}