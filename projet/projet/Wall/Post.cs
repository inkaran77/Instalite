using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using projet.Profile;

namespace projet.Wall
{
    public class Post
    {
        public ObjectId Id { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Like_counter")]
        public int Like_counter { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }

        [BsonElement("Image")]
        public Photo Image { get; set; }

        [BsonElement("Like_like")]
        public List<Like> List_like { get; set; }

        [BsonElement("List_comment")]
        public List<Comment> List_comment { get; set; }



    
    }


}
