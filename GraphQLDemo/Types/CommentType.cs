using GraphQL.Types;
using GraphQLDemo.Entities;

namespace GraphQLDemo.Types
{
    public class CommentType : ObjectGraphType<Comment>
    {
        public CommentType()
        {
            Field(x => x.Count);
            Field(x => x.Description);
            Field(x => x.Url);
        }
    }
}