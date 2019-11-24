using GraphQLDemo.Entities;
using GraphQLDemo.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace GraphQLDemo.Controllers
{
    public class AuthorsController : ApiController
    {
        private readonly BlogService blogService;

        public AuthorsController(BlogService blogService)
        {
            this.blogService = blogService;
        }
        
        public IEnumerable<Author> GetAll()
        {
            return blogService.GetAllAuthors();
        }

        [Route("api/Authors/{id}")]
        public Author GetAuthorById(int id)
        {
            return blogService.GetAuthorById(id);
        }
        
        public IEnumerable<Post> GetPostsByAuthor(int id)
        {
            return blogService.GetPostsByAuthor(id);
        }
        
        public IEnumerable<SocialNetwork> GetSocialsByAuthor(int id)
        {
            return blogService.GetSNsByAuthor(id);
        }
    }
}
