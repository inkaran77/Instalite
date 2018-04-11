using System;
using MongoDB.Bson;
using MongoDB.Driver;
//using MongoDB.Driver.Builders;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace projet.Models
{
    public class DataAccess : InterfaceInscription
    {
        MongoClient _client;
        IMongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _db=_client.GetDatabase("Instalite");
        }


        // Test retour brute
        public List<User> GetAllUsers()
        {
            List<User> allUsers = new List<User>();

            var result=_db.GetCollection<User>("user").Find(new BsonDocument()).ToEnumerable();
             foreach (var document in result)
            {
                
                Console.WriteLine(document);
               allUsers.Add(document);
            }

            return allUsers;
        }

        // Test retour simplifié
        public String GetAllUsers2()
        {
            List<User> allUsers = new List<User>();
            String a="";
            //var result=_db.GetCollection<User>("user").Find(new BsonDocument());

            var projection = Builders<BsonDocument>.Projection.Include("UserId").Include("Password").Exclude("_id");
            var result = _db.GetCollection<BsonDocument>("user").Find(new BsonDocument()).Project(projection).ToEnumerable();
            Console.WriteLine(result.ToJson());
            a = result.ToJson();


            return a;
        }

        public Boolean Inscription(String Id, String Password){

            if(IsIdValide(Id) == false){
                _db.GetCollection<User>("user").InsertOne(new User { UserId = Id, Password = Password });
                return true;
            }
            return false;
        }


        public Boolean IsIdValide(String Id)
        {

            var filter = Builders<User>.Filter.Eq("UserId", Id);
            Boolean result = _db.GetCollection<User>("user").Find(filter).Any();
            return result;
        }
 

    }
}
