﻿using System;
using System.Web.Mvc;
using System.Web.Routing;
using JET.Web.App_Start;

namespace JET.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
      
    }
}