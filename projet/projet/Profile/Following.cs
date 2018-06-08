using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace projet.Profile
{
    public class Following
    {
        [BsonId]
        public String _id { get;private  set; }

        [BsonElement("ListUsers")]
        public List<String> ListUsers { get; set; }

        [BsonElement("RequestSendList")]
        public List<String> RequestSendList { get; set; }

        public Following()
        {
            _id = ObjectId.GenerateNewId().ToString();
            ListUsers = new List<String>();
            RequestSendList = new List<String>();
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
                u.Followings.RequestSendList.Add(userId); // ajout à la liste de demande envoyé

                // mise  à jour au niveau de la base de données
                DataAccess db = new DataAccess();
               

                // Maj Waitinglist 
                var filter = Builders<User>.Filter.Eq("UserId", u.UserId);
                var update = Builders<User>.Update.Set(x => x.Waiting_List, u.Waiting_List);
                var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);

                // Maj RequestSendList
                var filter2 = Builders<User>.Filter.Eq("UserId", myUserId);
                var update2 = Builders<User>.Update.Set(x => x.Followings.RequestSendList, u.Followings.RequestSendList);
                var result3 = db._db.GetCollection<User>("user").UpdateOne(filter2, update2);

                return true;
            }

            catch(Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public Boolean UnFollow(String myUserId, String followingId)
        {
            DataAccess db = new DataAccess();

            try
            {
                // On recupére la waiting de l'user à qui on fait une demande d'abonnement
                User me = new User();
                var result = me.GetMyProfile(myUserId);


                // On supprime l'abonnement de la liste d'abonnement(followers)
                if (me.Followings.ListUsers.Contains(followingId) == false) return false;

                else
                {
                    me.Followings.ListUsers.Remove(followingId);
                    // Maj au niveau de la BD
                    var filter = Builders<User>.Filter.Eq("UserId", myUserId);
                    var update = Builders<User>.Update.Set(x => x.Followings, me.Followings);
                    var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
                }

                // On supprime l'utlisateur à la liste des abonnés(followers) de l'utilisateur qu'on suit
                // On récupère le follower
                User following = new User();
                var result3 = following.GetMyProfile(followingId);
                following = JsonConvert.DeserializeObject<User>(result3);

                // On supprime l'id de l'utlisateur à la liste  des abonnés(followers) de l'utilisateur qu'on suit
                if (following.Followers.ListUsers.Contains(myUserId) == false) return false;
                else
                {
                    following.Followers.ListUsers.Remove(myUserId);
                    // Maj au niveau de la BD
                    var filter = Builders<User>.Filter.Eq("UserId", followingId);
                    var update = Builders<User>.Update.Set(x => x.Followers, following.Followers);
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

        public JObject GetAllMyFollowings(String userId)
        {
            DataAccess db = new DataAccess();
            var filter = Builders<User>.Filter.Eq("UserId", userId);
            var result = db._db.GetCollection<User>("user").Find(filter).FirstOrDefault();
            User u = JsonConvert.DeserializeObject<User>(result.ToJson());


            //// On crée un json pr renvoyer dans le format voulu
            JObject myfollowings = JObject.Parse(@"{'MyFollowings': []}");
            JArray j = (JArray)myfollowings["MyFollowings"];

            if (u.Followings.ListUsers.Capacity == 0) return null;
            foreach (String user in u.Followings.ListUsers)
            {
                var filter2 = Builders<User>.Filter.Eq("UserId", user);
                var result2 = db._db.GetCollection<User>("user").Find<User>(filter2).FirstOrDefault();
                User u1 = JsonConvert.DeserializeObject<User>(result2.ToJson());


                JObject j1 = new JObject(new JProperty("UserId", u1.UserId));
                JProperty jp1 = new JProperty("UrlPhoto", u1.UrlPhoto);
                j1.Add(jp1);
                j.Add(j1);

            }

            return myfollowings;

        }

    }
}
