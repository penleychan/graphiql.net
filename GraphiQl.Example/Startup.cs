using System;
using System.Threading.Tasks;
using System.Web.Http;
using GraphiQL;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(GraphiQl.Example.Startup))]

namespace GraphiQl.Example
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var httpConfig = new HttpConfiguration();

            RegisterWebApi(httpConfig);
            app.UseGraphiQl();

            app.UseWebApi(httpConfig);
        }

        private void RegisterWebApi(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
