using IDSync.ApiModels;
using IDSync.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IDSync.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task Index()
        { 
            foreach(var x in await ExchangeHelper.GetAll()) { 
                Response.Write(x.UserPrincipalName+"<br/>");
            }
        }

        public async Task<string> Post()
        {
            ExchangeSaveModel model = new ExchangeSaveModel(); 
            model.SamAccountName = "arrmanantha.cnasir";
            model.Database = "Mailbox Database";
            return await ExchangeHelper.Save(model);
        }
    }
}