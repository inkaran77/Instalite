using System;   
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace projet.Wall
{
    public class Photo
    {
        public ObjectId Id { get; set; }

        [BsonElement("Image")]
        public Byte[] Image { get; set; }
    }


}
