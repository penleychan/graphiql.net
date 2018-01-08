using System;
using GraphQL.Types;

namespace GraphiQl.Example.GraphQl.Models
{
    public class StarWarsQuery : ObjectGraphType
    {
        public StarWarsQuery(StarWarsData data)
        {
            Name = "StarWarsContext";
            Description = "StarWars Context";

            Func<ResolveFieldContext, string, object> func = (context, id) => data.GetDroidByIdAsync(id);
            FieldDelegate<DroidType>(
                "droid",
                "Get droid by Id",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "id", Description = "id of the droid" }
                ),
                resolve: func
            );
        }
    }
}