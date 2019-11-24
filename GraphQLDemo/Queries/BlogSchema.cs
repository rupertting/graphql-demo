using GraphQL;
using GraphQL.Types;

namespace GraphQLDemo.Queries
{
    public class BlogSchema : Schema
    {
        public BlogSchema(IDependencyResolver dependencyResolver)
          : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<AuthorQuery>();
        }
    }
}