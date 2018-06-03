using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using projet.Profile;

namespace projet.Wall
{
    public class NewsFeed
    {
        [BsonId]
        public String _id { get; private set; }

        [BsonElement("List_post")]
        public List<Post> List_post { get; set; }

        public NewsFeed()
        {
            _id = ObjectId.GenerateNewId().ToString();
            List_post = new List<Post>();
        }

        public List<Post> GetAllFollowingsPosts(String userId)
        {
            DataAccess db = new DataAccess();
            User u = new User();
            List<Post> res = new List<Post>();

            var result = u.GetMyProfile(userId);
            // On crée un objet user pour pouvoir récupérer les infors qu'on a bessoin
            u = JsonConvert.DeserializeObject<User>(result);

            // On parcours la liste des followings pour récupérer tous leurs posts
            foreach(String id in u.Followings.ListUsers)
            {
                var filter = Builders<User>.Filter.Eq("UserId", id);
                var result2 = db._db.GetCollection<User>("user").Find<User>(filter).FirstOrDefault();
                User following= JsonConvert.DeserializeObject<User>(result2.ToJson());

                foreach(String postId in following.List_post)
                {
                    var filter2 = Builders<Post>.Filter.Eq("_id", postId);
                    var result3 = db._db.GetCollection<Post>("post").Find(filter2).FirstOrDefault();
                    Post p=JsonConvert.DeserializeObject<Post>(result3.ToJson());
                    res.Add(p);
                }

            }
            return res;
        }

        // on fait un tri des posts qu'on a récupérer par date la plus récente
        public String ListPostSort(String userId)
        {
            List<Post> liste = new List<Post>();
            liste = GetAllFollowingsPosts(userId);

            // Tri par plus récent
            liste = liste.OrderByDescending(x => DateTime.Parse(x.Date)).ToList();
           

            // On crée un json pr renvoyer dans le format voulu
            JObject j = JObject.Parse(@"{'NewsFeed': []}");
            JArray newsfeed = (JArray)j["NewsFeed"];
            
            foreach(Post p in liste)
            {
                JObject j1 = new JObject(new JProperty("Lien", p.UrlPhoto));
                newsfeed.Add(j1);
            }

            return j.ToString();
        }

        public String GetMyNewsFeed(String userId)
        {
            try
            {
                return ListPostSort(userId);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}
