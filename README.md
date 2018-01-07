# graphiql.net
GraphiQL for .NET Framework Application (MVC/WebAPI)

Requires following handler to web.config

```<system.webServer>
    <handlers>
      <add name="Owin" verb="" path="*" type="Microsoft.Owin.Host.SystemWeb.OwinHttpHandler, Microsoft.Owin.Host.SystemWeb" />
    </handlers>
</system.webServer>
```