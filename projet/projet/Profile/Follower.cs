using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace projet.Profile
{
    public class Follower
    {
        [BsonId]
        public String _id { get;private set; }

        [BsonElement("ListUsers")]
        public List<String> ListUsers { get; set; }

        public Follower()
        {
            _id = ObjectId.GenerateNewId().ToString();
            ListUsers = new List<String>();
        }

        public Boolean AcceptFollower (String myUserId,String newFollowerId)
        {
            DataAccess db = new DataAccess();

            try{
                // On recupére la waiting de l'user à qui on fait une demande d'abonnement
                User me = new User();
                var result = me.GetMyProfile(myUserId);

                // On crée un objet user pour pouvoir récupérer les infors qu'on a bessoin
                me = JsonConvert.DeserializeObject<User>(result);
               
                // On retire l'utilisateur qu'on accepte en tant que abonné de la liste d'attente
                if (me.Waiting_List.Contains(newFollowerId))
                {
                    me.Waiting_List.Remove(newFollowerId);
                    // Maj au niveau de la BD
                    var filter = Builders<User>.Filter.Eq("UserId", myUserId);
                    var update = Builders<User>.Update.Set(x => x.Waiting_List, me.Waiting_List);
                    var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
                }
                else return false;

                // On ajoute le nouveau abonné à la liste d'abonnés(followers)
                if (me.Followers.ListUsers.Contains(newFollowerId)) return false;

                else 
                {
                    me.Followers.ListUsers.Add(newFollowerId);
                    // Maj au niveau de la BD
                    var filter = Builders<User>.Filter.Eq("UserId", myUserId);
                    var update = Builders<User>.Update.Set(x => x.Followers, me.Followers);
                    var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
                }

                // On ajoute l'utlisateur à la liste des abonnements(followings) du nouveau abonné
                // On récupère le follower
                User newFollower = new User();
                var result3 = me.GetMyProfile(newFollowerId);
                newFollower = JsonConvert.DeserializeObject<User>(result);

                // On ajoute l'id de l'utlisateur à la liste des abonnements du nouveau abonné
                if (newFollower.Followings.ListUsers.Contains(myUserId) == true) return false;
                else 
                {
                    newFollower.Followings.ListUsers.Add(myUserId);
                    // Maj au niveau de la BD
                    var filter = Builders<User>.Filter.Eq("UserId", newFollowerId);
                    var update = Builders<User>.Update.Set(x => x.Followings, newFollower.Followings);
                    var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
                }
                return true;
            }
            catch (Exception e){
                Console.WriteLine(e);
                return false;
            }
        }

        public Boolean RefuseFollower(String myUserId, String newRequestId)
        {
            return true;
        }
   
    }
}
