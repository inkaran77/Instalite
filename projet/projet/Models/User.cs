using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace projet.Models
{
    public class User
    {
        public ObjectId Id { get; set; }

        [BsonElement("UserId")]
        public string UserId { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }
}
}
