using System;
using System.Web;
using System.Web.Mvc;
using IDSync.Models;
using System.Web.Security;
using Microsoft.Owin.Security.WsFederation;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using IDSync.Helpers;
using System.Configuration;
using IDSync.Interface;
using IDSync.DAL;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace IDSync.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IUsersRepository usersRepository;
        private Dal db = new Dal();
        public AccountController()
        {
            this.usersRepository = new UsersRepository(new Dal());
        }

        public AccountController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }  
        public async Task<ActionResult> SignIn()
        {
            if (!Request.IsAuthenticated)
            {
                HttpContext.GetOwinContext().Authentication.Challenge(new AuthenticationProperties { RedirectUri = "/" },
                    WsFederationAuthenticationDefaults.AuthenticationType);
                return View();
            }
            else
            { 
                string token = await ClaimsHelpers.GetToken();
                List<CookiesModel> Cookies = new List<CookiesModel>();
                Cookies.Add(new CookiesModel { Key = "EnableExchange", Value="true" });
                Cookies.Add(new CookiesModel { Key = "EnableSkype", Value = "true" });
                Cookies.Add(new CookiesModel { Key = "session_user_id", Value = "true" });
                Cookies.Add(new CookiesModel { Key = "id", Value = "true" });
                Cookies.Add(new CookiesModel { Key = "session_fullname", Value = "true" });
                Cookies.Add(new CookiesModel { Key = "Token", Value = token }); 
                if (token != null)
                {
                    CookiesHelper.setCookies(Cookies);
                } 
                    string desc;
                    if (Request.Browser.IsMobileDevice)
                    {
                        desc = "Mobile#" + Request.Browser.Platform + "#" + Request.Browser.Version;
                    }
                    else
                    {
                        desc = "Desktop#" + Request.Browser.Platform + "#" + Request.Browser.Version;
                    }
                    var logs = new Logs()
                    {
                        LogId = ConfigurationHelpers.generateID(),
                        SamAccountName = User.Identity.Name,
                        Date = DateTime.Now,
                        Type = "0",
                        Description = desc
                    };
                    db.Logs.Add(logs);
                    db.SaveChanges();

                    return RedirectToAction("Index", "Home");
            } 
        }

        public void SignOut()
        {
            string callbackUrl = Url.Action("SignIn", "Account", routeValues: null, protocol: Request.Url.Scheme);

            HttpContext.GetOwinContext().Authentication.SignOut(
                new AuthenticationProperties { RedirectUri = callbackUrl },
                WsFederationAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);
        }


        // Logout user active
        public void Logout()
        {
            CookiesHelper.deleteCookies();
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear(); 
            this.SignOut();
        }
         
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}