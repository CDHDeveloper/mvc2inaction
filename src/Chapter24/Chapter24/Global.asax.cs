﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Chapter24
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        private static RouteBase CreateRoute(string url, object defaults)
        {
            return new Route(url, new RouteValueDictionary(defaults), new CustomRouteHandler());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add(CreateRoute("{category}/{action}", new {controller = "products", action = "index"}));
            routes.Add(CreateRoute("{controller}/{action}/{id}", new {controller = "home", action = "index", id=""}));
//            routes.MapRoute("CategoryRoute", 
//                "{category}/{action}",
//                new { controller = "Products", action="index" }
//            );
//
//            routes.MapRoute(
//                "Default",                                              // Route name
//                "{controller}/{action}/{id}",                           // URL with parameters
//                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
//            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}