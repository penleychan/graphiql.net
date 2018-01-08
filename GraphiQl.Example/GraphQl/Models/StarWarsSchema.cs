using System;
using GraphQL.Types;

namespace GraphiQl.Example.GraphQl.Models
{
    public class StarWarsSchema : Schema
    {
        public StarWarsSchema(Func<Type, GraphType> resolveType) : base(resolveType)
        {
            Query = (StarWarsQuery)resolveType(typeof(StarWarsQuery));
        }
    }
}