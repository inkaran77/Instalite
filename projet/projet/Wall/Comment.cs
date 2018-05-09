using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace projet.Wall
{
    public class Comment
    {
        public ObjectId Id { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [BsonElement("Message")]
        public string Message { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }
    }
}
