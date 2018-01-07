using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using GraphiQl.Example.GraphQl;
using GraphiQl.Example.GraphQl.Models;
using GraphQL;
using GraphQL.Types;

namespace GraphiQl.Example.Controllers
{
    [Route("graphql")]
    public class GraphQlController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] GraphQlQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = new StarWarsSchema();
                x.Query = query.Query;
                x.Inputs = query.Variables.ToInputs();
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors.ToString());
            }

            return Ok(result);
        }
    }
}
