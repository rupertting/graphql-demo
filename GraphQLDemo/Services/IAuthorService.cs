using GraphQLDemo.Entities;
using System.Collections.Generic;

namespace GraphQLDemo.Services
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAuthors();
    }
}