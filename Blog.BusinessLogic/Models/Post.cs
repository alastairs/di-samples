using System;
using System.Collections.Generic;

namespace Blog.BusinessLogic.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public DateTime PublicationDate { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
