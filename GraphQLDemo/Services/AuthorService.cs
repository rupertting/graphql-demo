using GraphQLDemo.Entities;
using System.Collections.Generic;

namespace GraphQLDemo.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly List<Author> authors = new List<Author>();

        public AuthorService()
        {
            Author DinoEsposito = new Author
            {
                Id = 1,
                Name = "Dino Esposito",
                Bio = "Dino Esposito has authored more than 20 books and 1,000 articles in ...",
                ImgUrl = "https://secure.gravatar.com/avatar/ace158af8dfab0e682dcc70d965514e5?s=80&d=mm&r=g",
                ProfileUrl = "https://www.red-gate.com/simple-talk/author/dino-esposito/"
            };
            Author LanceTalbert = new Author
            {
                Id = 2,
                Name = "Lance Talbert",
                Bio = "Lance Talbert is a budding game developer that has been learning to program since ...",
                ImgUrl = "https://www.red-gate.com/simple-talk/wp-content/uploads/2018/01/red-gate-bio-pic.jpg",
                ProfileUrl = "https://www.red-gate.com/simple-talk/author/lancetalbert/"
            };
            authors.Add(DinoEsposito);
            authors.Add(LanceTalbert);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return authors;
        }
    }
}