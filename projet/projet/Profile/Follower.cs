using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace projet.Profile
{
    public class Follower
    {
        [BsonId]
        public String _id { get;private set; }

        [BsonElement("ListUsers")]
        public List<User> ListUsers { get; set; }

        public Follower()
        {
            _id = ObjectId.GenerateNewId().ToString();
            ListUsers = new List<User>();
        }
    }
}
