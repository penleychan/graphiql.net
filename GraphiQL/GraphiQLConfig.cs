using System.Collections;
using System.Collections.Generic;
using System.Net;
using Microsoft.Owin;

namespace GraphiQL
{
    internal class GraphiQlConfig
    {
        internal GraphQlOptions Options { get; }

        private GraphiQlConfig(GraphQlOptions options)
        {
            Options = options;
        }

        internal static GraphQlOptions Bootstrap(GraphQlOptions options)
        {
            return new GraphiQlConfig(options).Options;
        }
    }

    internal class GraphQlOptions
    {
        internal PathString Path { get; set; }
    }
}