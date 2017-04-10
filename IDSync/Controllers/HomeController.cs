using IDSync.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDSync.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public void Index()
        { 
            foreach(var x in ClaimsHelpers.getGroups()) { 
                Response.Write("Group => " + x.Name+"<br/>");
            }
        }
    }
}