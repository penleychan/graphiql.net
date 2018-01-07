using System;
using System.Reflection;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.StaticFiles.ContentTypes;
using Owin;

namespace GraphiQL
{
    /// <summary>
    /// Require handler to system.webServer
    /// <add name="Owin" verb="" path="*" type="Microsoft.Owin.Host.SystemWeb.OwinHttpHandler, Microsoft.Owin.Host.SystemWeb"/>
    /// </summary>
    public static class GraphiQlExtensions
    {
        public static IAppBuilder UseGraphiQl(this IAppBuilder app)
        {
            return UseGraphiQl(app, GraphiQlConfig.Bootstrap);
        }

        private static IAppBuilder UseGraphiQl(this IAppBuilder app, Func<GraphQlOptions, GraphQlOptions> config)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            var assembly = typeof(GraphiQlExtensions).GetTypeInfo().Assembly;

            var path = "/graphql";
            path = path.StartsWith("/") ? path : "/" + path;

            var graphQlOptions = new GraphQlOptions
            {
                Path = new PathString(path)
            };

            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                RequestPath = config(graphQlOptions).Path,
                FileSystem = new EmbeddedResourceFileSystem(assembly, "GraphiQL.assets"),
                StaticFileOptions = {ContentTypeProvider = new FileExtensionContentTypeProvider()},
            };

            app.UseFileServer(options);

            return app;
        }
    }
}