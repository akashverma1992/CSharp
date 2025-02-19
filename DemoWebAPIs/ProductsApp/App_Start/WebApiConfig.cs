﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProductsApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {
                    ApiControllers = "Products",
                    id = RouteParameter.Optional
                }
            );

            //config.Routes.MapHttpRoute(
            //    name: "UpdateApi",
            //    routeTemplate: "api/{controller}/{Product}",
            //    defaults: new {
            //        ApiControllers = "Products",
            //        product = RouteParameter.Optional
            //    }
            //);
        }
    }
}
