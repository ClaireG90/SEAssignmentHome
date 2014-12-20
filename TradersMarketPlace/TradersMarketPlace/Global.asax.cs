using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Common;
using Business;
using System.Security.Principal;


namespace TradersMarketPlace
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["accountID"] = "";
        }

        protected void Application_AuthenticateRequest(object s, EventArgs e)
        {
            if (Context.User != null)
            {
                string name = Context.User.Identity.Name;
                UserType userRole = new BAUser().GetUserRoleByUsername(name);

                string[] userTypes = new string[1];
                userTypes[0] = userRole.UserType1;

                GenericPrincipal gp = new GenericPrincipal(Context.User.Identity, userTypes);
                Context.User = gp;
            }
        }
    }
}