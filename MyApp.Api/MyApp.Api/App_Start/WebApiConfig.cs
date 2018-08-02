using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MyApp.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
       

            //    GlobalConfiguration.Configuration.MessageHandlers.Insert(0, new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));


            // Web API routes
            config.MapHttpAttributeRoutes();

            var routes = new Dictionary<string, string[]>
            {
                
                 {"Artical", new[] {""}},

            };
            foreach (var group in routes)
            {
                foreach (var route in group.Value)
                {
                    var controller = string.IsNullOrWhiteSpace(route) ? group.Key : route;
                    var name = string.Format("{0}_{1}_Api", group.Key, controller);
                    var routeTemplate = "api/{0}/{1}/{2}/{3}";
                    if (string.IsNullOrWhiteSpace(route))
                    {
                        routeTemplate = "api/{0}/{2}/{3}";
                    }
                    routeTemplate = string.Format(routeTemplate, group.Key, controller, "{action}", "{id}");
                    config.Routes.MapHttpRoute(name, routeTemplate, new { controller, id = RouteParameter.Optional }
                        );
                }
            }


            //  GlobalConfiguration.Configuration.MessageHandlers.Insert(0, new ServerCompressionHandler(new GZipCompressor(), new DeflateCompressor()));
        }
    }
}
