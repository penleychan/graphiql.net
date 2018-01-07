using System.Collections;
using System.Collections.Generic;
using System.Net;
using Microsoft.Owin;

namespace GraphiQL
{
    public class GraphiQlConfig
    {
        public PathString Path { get; private set; }

        public void SetPath(PathString path)
        {
            Path = path;
        }
    }
}