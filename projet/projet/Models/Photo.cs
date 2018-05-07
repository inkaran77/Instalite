using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace projet.Models
{
    public class Photo
    {
        public ObjectId Id { get; set; }

        [BsonElement("Image")]
        public BsonBinaryData Image { get; set; }
    }
}
