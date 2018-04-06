using System;
using MongoDB.Bson;
using MongoDB.Driver;
//using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace projet.Models
{
    public class DataAccess
    {
        MongoClient _client;
        // MongoServer _server;
        IMongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db=_client.GetDatabase("Instalite");

            //_server = _client.GetServer();
           // _db = _server.GetDatabase("EmployeeDB");
        }

        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();
            var result=_db.GetCollection<User>("user").Find(new BsonDocument());

            foreach (var document in result.ToEnumerable())
            {
                allUsers.Add(document);
            }

            return allUsers;
        }


        public void AddUser(User u)
        {
            _db.GetCollection<User>("user").InsertOne(u);   
        }
 

    }
}
