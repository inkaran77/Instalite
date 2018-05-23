using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace projet.Profile
{
    public class Follower
    {
        [BsonId]
        private String _id { get; set; }

        [BsonElement("ListUsers")]
        private List<User> ListUsers { get; set; }

        public Follower()
        {
            _id = ObjectId.GenerateNewId().ToString();
            ListUsers = new List<User>();
        }
    }
}
