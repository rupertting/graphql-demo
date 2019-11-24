using GraphQL.Types;
using GraphQLDemo.Entities;
using System.Linq;

namespace GraphQLDemo.Types
{
    public class RatingType : ObjectGraphType<Rating>
    {
        public RatingType()
        {
            Field(x => x.Count);
            Field(x => x.Percent);
        }
    }
}