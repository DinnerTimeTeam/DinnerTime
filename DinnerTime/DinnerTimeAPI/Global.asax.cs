using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using DinnerTimeAPI.Filters;

namespace DinnerTimeAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.Filters.Add(new RequireHttpsAttribute());
            GlobalConfiguration.Configuration.Filters.Add(new AuthorizeAttribute());
        }
    }
}
