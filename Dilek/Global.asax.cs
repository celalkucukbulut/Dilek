using Dilek.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Dilek
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
           {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                var serializeModel = new JavaScriptSerializer().Deserialize<UserPrincipalSerializeModel>(authTicket.UserData);

                UserPrincipal newUser = new UserPrincipal(authCookie.Name);
                newUser.MailAddress = serializeModel.MailAddress;
                newUser.Name = serializeModel.Name;
                newUser.ID = serializeModel.ID;
                newUser.Surname = serializeModel.Surname;
                newUser.Username = serializeModel.Username;
                HttpContext.Current.User = newUser;
            }
        }
    }
}
