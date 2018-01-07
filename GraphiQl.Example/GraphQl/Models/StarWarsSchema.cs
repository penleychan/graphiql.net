using System;
using GraphQL.Types;

namespace GraphiQl.Example.GraphQl.Models
{
    public class StarWarsSchema : Schema
    {
        public StarWarsSchema()
        {
            Query = new StarWarsQuery(new StarWarsData());
        }
    }
}