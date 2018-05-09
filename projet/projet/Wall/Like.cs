using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace projet.Wall
{
    public class Like
    {
        public ObjectId Id { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }
    }
}
