using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using GraphiQl.Example.GraphQl;
using GraphiQl.Example.GraphQl.Models;
using GraphQL;
using GraphQL.Types;
using Newtonsoft.Json;

namespace GraphiQl.Example.Controllers
{
    [Route("graphql")]
    public class GraphQlController : ApiController
    {
        private readonly ISchema _schema;

        public GraphQlController(ISchema schema)
        {
            _schema = schema;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] GraphQlQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var exectionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = query.Variables.ToInputs()
            };

            try
            {
                var result = await new DocumentExecuter().ExecuteAsync(exectionOptions).ConfigureAwait(false);

                if (result.Errors?.Count > 0)
                {
                    return Json(result.Errors);
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
