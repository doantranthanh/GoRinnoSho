using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace JET.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Bootstrapper.Initialise();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);          
        }
    }
}
