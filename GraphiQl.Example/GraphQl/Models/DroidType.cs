using GraphQL.Types;

namespace GraphiQl.Example.GraphQl.Models
{
    public class DroidType : ObjectGraphType<Droid>
    {
        public DroidType()
        {
            Field(x => x.Id, nullable: true);
            Field(x => x.Name, nullable: true).Description("The name of the Droid.");
        }
    }

    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(x => x.Id).Description("Person's Id.");
            Field(x => x.Name).Description("Person's Name.");
            Field(x => x.Age).Resolve(x => 25).Description("Person's Age.");
        }
    }
}