using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using GraphQLDemo.Queries;
using GraphQLDemo.Services;
using GraphQLDemo.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLDemo.DependencyInjection
{
    public class Bootstrapper
    {
        public System.Web.Http.Dependencies.IDependencyResolver Resolver()
        {
            var container = BuildContainer();
            var resolver = new SimpleContainerDependencyResolver(container);
            return resolver;
        }

        private ISimpleContainer BuildContainer()
        {
            var container = new SimpleContainer();
            container.Singleton<IDocumentExecuter>(new DocumentExecuter());
            container.Singleton<IDocumentWriter>(new DocumentWriter(true));

            container.Singleton<IAuthorService>(new AuthorService());

            container.Register<AuthorQuery>();
            container.Register<AuthorType>();
            container.Register<PostType>();
            container.Register<CommentType>();
            container.Register<RatingType>();
            container.Register<SNTypeType>();
            container.Register<SocialNetworkType>();
            container.Register<BlogService>();

            container.Singleton<ISchema>(new BlogSchema(new FuncDependencyResolver(type => container.Get(type))));

            return container;
        }
    }
}