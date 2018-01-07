using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace GraphiQl.Example.GraphQl
{
    public class GraphQlQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }

    }
}