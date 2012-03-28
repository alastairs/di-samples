using System;
using System.Runtime.Serialization;

namespace Composing_WCF.ServiceModels
{
    [DataContract]
    public class Post
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Summary { get; set; }

        [DataMember]
        public string Body { get; set; }
    }
}
