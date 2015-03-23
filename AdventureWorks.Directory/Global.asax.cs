using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.WebPages;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventureWorks.Directory
{

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           
            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode("tablet")
            {
                ContextCondition = (context => GetDeviceType(context.GetOverriddenUserAgent()) == "tablet")
            });

            AreaRegistration.RegisterAllAreas();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleMobileConfig.RegisterBundles(BundleTable.Bundles);

            // Cache never expires. You must restart application pool 
            // when you add/delete a view. A non-expiring cache can lead to 
            // heavy server memory load. 

           // ViewEngines.Engines.
            ViewEngines.Engines.Clear(); //SASmart 9/6/13
            ViewEngines.Engines.Add(new RazorViewEngine()); //SASmart 9/6/13

            ViewEngines.Engines.OfType<RazorViewEngine>().First().ViewLocationCache =
            new DefaultViewLocationCache(System.Web.Caching.Cache.NoSlidingExpiration);

            // Add or Replace RazorViewEngine with WebFormViewEngine 
            // if you are using the Web Forms View Engine. 

            var employees = AdventureWorks.Directory.Models.Employees.All.OrderBy(x => x.Last_Name);
        }

         private string GetDeviceType(string ua)
        {
            string ret = "";

            // Check if user agent is a Tablet
           if ((Regex.IsMatch(ua, "iP(a|ro)d", RegexOptions.IgnoreCase) || (Regex.IsMatch(ua, "tablet", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(ua, "RX-34", RegexOptions.IgnoreCase)) || (Regex.IsMatch(ua, "FOLIO", RegexOptions.IgnoreCase))))
            {
                ret = "tablet";
            }
            // Check if user agent is an Android Tablet
            else if ((Regex.IsMatch(ua, "Linux", RegexOptions.IgnoreCase)) && (Regex.IsMatch(ua, "Android", RegexOptions.IgnoreCase)) && (!Regex.IsMatch(ua, "Fennec|mobi|HTC.Magic|HTCX06HT|Nexus.One|SC-02B|fone.945", RegexOptions.IgnoreCase)))
            {
                ret = "tablet";
            }
            // Check if user agent is a Kindle or Kindle Fire
            else if ((Regex.IsMatch(ua, "Kindle", RegexOptions.IgnoreCase)) || (Regex.IsMatch(ua, "Mac.OS", RegexOptions.IgnoreCase)) && (Regex.IsMatch(ua, "Silk", RegexOptions.IgnoreCase)))
            {
                ret = "tablet";
            }
            // Check if user agent is a pre Android 3.0 Tablet
            else if ((Regex.IsMatch(ua, @"GT-P10|SC-01C|SHW-M180S|SGH-T849|SCH-I800|SHW-M180L|SPH-P100|SGH-I987|zt180|HTC(.Flyer|\\_Flyer)|Sprint.ATP51|ViewPad7|pandigital(sprnova|nova)|Ideos.S7|Dell.Streak.7|Advent.Vega|A101IT|A70BHT|MID7015|Next2|nook", RegexOptions.IgnoreCase)) || (Regex.IsMatch(ua, "MB511", RegexOptions.IgnoreCase)) && (Regex.IsMatch(ua, "RUTEM", RegexOptions.IgnoreCase)))
            {
                ret = "tablet";
            }

            // Otherwise assume it is a Mobile Device
           else
           {
               ret = "mobile";
           }
            return ret;
        }
    }
}