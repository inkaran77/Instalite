﻿using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace projet.Wall
{
    public class Comment
    {
        [BsonId]
        public String _id { get;private set; }

        [BsonElement("Date")]
        public String Date { get; set; }

        [BsonElement("Message")]
        public string Message { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }
    
        public Comment()
        {
            _id = ObjectId.GenerateNewId().ToString();
        }
    
    
    }


}
