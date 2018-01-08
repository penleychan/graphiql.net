using System;
using System.Threading.Tasks;
using System.Web.Http;
using GraphiQl.Example.GraphQl;
using GraphiQl.Example.GraphQl.Models;
using GraphiQL;
using GraphQL.Types;
using Microsoft.Owin;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

[assembly: OwinStartup(typeof(GraphiQl.Example.Startup))]

namespace GraphiQl.Example
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            var httpConfig = new HttpConfiguration();

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<StarWarsData>();
            container.Register(() => new StarWarsQuery(container.GetInstance<StarWarsData>()), Lifestyle.Scoped);
            container.Register<DroidType>();

            container.Register<ISchema>(() => new StarWarsSchema(type => (GraphType) container.GetInstance(type)) { Query = container.GetInstance<StarWarsQuery>()}, Lifestyle.Scoped);

            container.RegisterWebApiControllers(httpConfig);
            container.Verify();
            httpConfig.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

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
