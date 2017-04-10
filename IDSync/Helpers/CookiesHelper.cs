using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace IDSync.Helpers
{
    public class CookiesHelper
    {
        public static void setCookies(List<CookiesModel> Cookies) {
            HttpCookie myCookie = new HttpCookie("AppCookies");
            foreach(var cookie in Cookies) {
                var encryptName = getMd5Hash(cookie.Key);
                myCookie[encryptName] = cookie.Value;
            } 
            myCookie.Expires = DateTime.Now.AddDays(1d);
            HttpContext.Current.Response.Cookies.Add(myCookie); 
        }

        public static string getCookies(string CookiesName)
        {
            var encryptName = getMd5Hash(CookiesName);
            return HttpContext.Current.Request.Cookies["AppCookies"][encryptName];
        }

        public static void deleteCookies()
        {
            HttpCookie myCookie = new HttpCookie("AppCookies"); 
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            HttpContext.Current.Response.Cookies.Add(myCookie);
            HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.CacheControl = "no-cache";
        }

        public static string getMd5Hash(string input)
        {  
            MD5 md5Hasher = MD5.Create(); 
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input)); 
            StringBuilder sBuilder = new StringBuilder();  
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            } 
            return sBuilder.ToString();
        }
    }

    public class CookiesModel {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}