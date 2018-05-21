using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace projet.Wall
{
    public class Like
    {
        [BsonId]
        public String _id { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }
    
        public Like()
        {
            _id = ObjectId.GenerateNewId().ToString();
        }
    }

}
