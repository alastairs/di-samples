using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Composing_ASP.NET_MVC.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        public string Summary { get; set; }

        [Required]
        public string Body { get; set; }

        [DisplayName("Publication Date")]
        public DateTime PublicationDate { get; set; }
    }
}