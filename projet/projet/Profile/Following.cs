using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace projet.Profile
{
    public class Following
    {
        [BsonId]
        public String _id { get;private  set; }

        [BsonElement("ListUsers")]
        public List<String> ListUsers { get; set; }

        public Following()
        {
            _id = ObjectId.GenerateNewId().ToString();
            ListUsers = new List<String>();
        }
    
        public Boolean Follow (String myUserId,String userId)
        {
            try
            {
                // On recupére la waiting de l'user à qui on fait une demande d'abonnement
                User u = new User();
                var result = u.GetMyProfile(userId);

                // On crée un objet user pour pouvoir récupérer les infors qu'on a bessoin
                u = JsonConvert.DeserializeObject<User>(result);
                if (u.Waiting_List.Contains(myUserId)) return false; // si la demande a déja était faite
                u.Waiting_List.Add(myUserId);

                // mise  à jour au niveau de la base de données
                DataAccess db = new DataAccess();
                var filter = Builders<User>.Filter.Eq("UserId", u.UserId);
                var update = Builders<User>.Update.Set(x => x.Waiting_List, u.Waiting_List);
                var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
                return true;
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
