using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLDemo.Entities
{
    public class Comment
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
    }
}