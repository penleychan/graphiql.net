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
            return UseGraphiQl(app, "/graphql");
        }

        public static IAppBuilder UseGraphiQl(this IAppBuilder app, string path)
        {
            if (String.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException(nameof(path));
            }

            path = path.StartsWith("/") ? path : "/" + path;
            return UseGraphiQl(app, x => x.SetPath(new PathString(path)));
        }

        private static IAppBuilder UseGraphiQl(this IAppBuilder app, Action<GraphiQlConfig> setConfig)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (setConfig == null)
            {
                throw new ArgumentNullException(nameof(setConfig));
            }

            var config = new GraphiQlConfig();
            setConfig(config);

            var assembly = typeof(GraphiQlExtensions).GetTypeInfo().Assembly;

            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                RequestPath = config.Path,
                FileSystem = new EmbeddedResourceFileSystem(assembly, "GraphiQL.assets"),
                StaticFileOptions = {ContentTypeProvider = new FileExtensionContentTypeProvider()},
            };

            app.UseFileServer(options);

            return app;
        }
    }
}