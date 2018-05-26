using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace projet.Profile
{
    public class Follower
    {
        [BsonId]
        public String _id { get; private set; }

        [BsonElement("ListUsers")]
        public List<String> ListUsers { get; set; }

        public Follower()
        {
            _id = ObjectId.GenerateNewId().ToString();
            ListUsers = new List<String>();
        }

        public Boolean AcceptFollower(String myUserId, String newFollowerId)
        {
            DataAccess db = new DataAccess();

            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }


        public Boolean RefuseFollowRequest(String myUserId, String newRequestId)
        {
            DataAccess db = new DataAccess();

            try
            {
                // On recupére la waiting de l'user à qui on fait une demande d'abonnement
                User me = new User();
                var result = me.GetMyProfile(myUserId);

                // On crée un objet user pour pouvoir récupérer les infors qu'on a bessoin
                me = JsonConvert.DeserializeObject<User>(result);

                // On retire l'utilisateur qu'on accepte en tant que abonné de la liste d'attente
                if (me.Waiting_List.Contains(newRequestId))
                {
                    me.Waiting_List.Remove(newRequestId);
                    // Maj au niveau de la BD
                    var filter = Builders<User>.Filter.Eq("UserId", myUserId);
                    var update = Builders<User>.Update.Set(x => x.Waiting_List, me.Waiting_List);
                    var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
                    return true;
                }
                else return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public Boolean DeleteFollower(String myUserId, String followerId)
        {
            DataAccess db = new DataAccess();

            try
            {
                // On recupére la waiting de l'user à qui on fait une demande d'abonnement
                User me = new User();
                var result = me.GetMyProfile(myUserId);


                // On supprime l'abonné de la liste d'abonnés(followers)
                if (me.Followers.ListUsers.Contains(followerId)==false) return false;

                else
                {
                    me.Followers.ListUsers.Remove(followerId);
                    // Maj au niveau de la BD
                    var filter = Builders<User>.Filter.Eq("UserId", myUserId);
                    var update = Builders<User>.Update.Set(x => x.Followers, me.Followers);
                    var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
                }

                // On supprime l'utlisateur à la liste des abonnements(followings) de l'abonné
                // On récupère le follower
                User follower = new User();
                var result3 = follower.GetMyProfile(followerId);
                follower = JsonConvert.DeserializeObject<User>(result3);

                // On supprime l'id de l'utlisateur à la liste des abonnements de l'abonné
                if (follower.Followings.ListUsers.Contains(myUserId) == false) return false;
                else
                {
                    follower.Followings.ListUsers.Remove(myUserId);
                    // Maj au niveau de la BD
                    var filter = Builders<User>.Filter.Eq("UserId", followerId);
                    var update = Builders<User>.Update.Set(x => x.Followings, follower.Followings);
                    var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public String GetAllMyFollowers(String userId)
        {
            DataAccess db = new DataAccess();
            var filter = Builders<User>.Filter.Eq("UserId", userId);
            var result = db._db.GetCollection<User>("user").Find(filter).FirstOrDefault();
            User u = JsonConvert.DeserializeObject<User>(result.ToJson());


            //// On crée un json pr renvoyer dans le format voulu
            JObject myfollowers = JObject.Parse(@"{'MyFollowers': []}");
            JArray j = (JArray)myfollowers["MyFollowers"];

            if (u.Followers.ListUsers.Capacity == 0) return null;
            foreach (String user in u.Followers.ListUsers)
            {
                var filter2 = Builders<User>.Filter.Eq("UserId", user);
                var result2 = db._db.GetCollection<User>("user").Find<User>(filter2).FirstOrDefault();
                User u1 = JsonConvert.DeserializeObject<User>(result2.ToJson());


                JObject j1 = new JObject(new JProperty("UserId", u1.UserId));
                JProperty jp1 = new JProperty("UrlPhoto", u1.UrlPhoto);
                j1.Add(jp1);
                j.Add(j1);

            }

            return myfollowers.ToString();

        }
    }
}
