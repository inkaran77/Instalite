using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using projet.Wall;

namespace projet.Profile
{
    public class User
    {
        [BsonId]
        public String _id { get; set;}

        //public ObjectId Id { get; set; }

        [BsonElement("UserId")]
        public string UserId { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("First_name")]
        public string First_name { get; set; }

        [BsonElement("Last_name")]
        public string Last_name { get; set; }

        [BsonElement("Birth_date")]
        public String Birth_date { get; set; }


        [BsonElement("Gender")]
        public string Gender { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }


        [BsonElement("UrlPhoto")]
        public string UrlPhoto { get; set; }


        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("Country")]
        public string Country { get; set; }

        [BsonElement("List_post")]
        public List<String> List_post { get; set; }
       

        [BsonElement("Waiting_List")]
        public List<String> Waiting_List { get; set; }

        public User()
        {
            _id = ObjectId.GenerateNewId().ToString();   
        }

        public Boolean PostPhoto(Post p,String userId)
        {
            DataAccess db = new DataAccess();

            // On recupere les infos de l'utilisateur qui publie le poste
            var result = GetMyProfile(userId);
            User u = JsonConvert.DeserializeObject<User>(result);

            // On ajoute l'id du post à la liste des posts de l'utilisateurs
            u.List_post.Add(p._id);
           
            // On fait la mise à jour au niveau de l'utilisateur
            var filter = Builders<User>.Filter.Eq("UserId", u.UserId);
            var update = Builders<User>.Update.Set(x => x.List_post, u.List_post);

            var result2 = db._db.GetCollection<User>("user").UpdateOne(filter,update);
          
            return db.Insert(p, "post");
        }

        public String GetPost(String urlphoto){
            
            DataAccess db = new DataAccess();

            // On recupere l'id du post correspondant à l'urlphoto
            var filter = Builders<Post>.Filter.Eq("UrlPhoto", urlphoto);
            var result = db._db.GetCollection<Post>("post").Find(filter).FirstOrDefault();

            return result.ToJson();
        }


        public Boolean DeletePost(String urlphoto,String userId)
        {
            Boolean test = false;
            DataAccess db = new DataAccess();

            // On recupere l'id du post correspondant à l'urlphoto
            var filter = Builders<Post>.Filter.Eq("UrlPhoto", urlphoto);
            var result = db._db.GetCollection<Post>("post").Find(filter).FirstOrDefault();
            if (result == null) return test; // si le post n'existe pas
            Post p = JsonConvert.DeserializeObject<Post>(result.ToJson());

            // On va supprimer le post dans la liste de post de l'utilisateur
            var result2 = GetMyProfile(userId);
            User u = JsonConvert.DeserializeObject<User>(result2);

            if(u.List_post.Contains(p._id)==true){
                u.List_post.Remove(p._id);

                // On fait la mise à jour au niveau de l'utilisateur
                var filter2 = Builders<User>.Filter.Eq("UserId", u.UserId);
                var update = Builders<User>.Update.Set(x => x.List_post, u.List_post);
                var result3 = db._db.GetCollection<User>("user").UpdateOne(filter2, update);

                // On va supprimer le post dans sa collection
                var filter3 = Builders<Post>.Filter.Eq("UrlPhoto", urlphoto);
                var result4 = db._db.GetCollection<Post>("post").DeleteOne(filter3);

                test = true;
                return test;
            }

            else return test;
        }

        public String GetMyProfile(String userId)
        {
            DataAccess db = new DataAccess();
            var filter = Builders<User>.Filter.Eq("UserId", userId);

            var fieldsBuilder = Builders<User>.Projection;
            var fields = fieldsBuilder.Exclude(d => d._id);

            var result = db._db.GetCollection<User>("user").Find<User>(filter).Project(fields).FirstOrDefault();
            return result.ToJson();
           
        }

        public String GetMyPhotos(String userId)
        {
            var result=GetMyProfile(userId);

            // On crée un objet user pour pouvoir récupérer les infors qu'on a bessoin
            User u = JsonConvert.DeserializeObject<User>(result);

            List<String> liste_photo = new List<string>();
            foreach(String post in u.List_post)
            {
                DataAccess db = new DataAccess();
                var filter = Builders<Post>.Filter.Eq("_id", post);
                var result2 = db._db.GetCollection<Post>("post").Find<Post>(filter).FirstOrDefault();
                Post p = JsonConvert.DeserializeObject<Post>(result2.ToJson());
                liste_photo.Add(p.UrlPhoto);

            }

            return liste_photo.ToJson();
        }


        public Boolean ModifyMyProfile(User modification, String userId){
            Boolean test = false;
            DataAccess db = new DataAccess();

            // On recupere les infos de l'utilisateur qui publie le poste
            var result = GetMyProfile(userId);
            User u = JsonConvert.DeserializeObject<User>(result);

            if (u.First_name.Equals(modification.First_name) == false)
            {
               var filter = Builders<User>.Filter.Eq("UserId", u.UserId);
               var update = Builders<User>.Update.Set(x => x.First_name, modification.First_name);
               var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
               test = true;
            }

            if (u.Last_name.Equals(modification.Last_name) == false)
            {
                var filter = Builders<User>.Filter.Eq("UserId", u.UserId);
                var update = Builders<User>.Update.Set(x => x.Last_name, modification.Last_name);
                var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
                test = true;
            }

            if (u.Email.Equals(modification.Email) == false)
            {
                var filter = Builders<User>.Filter.Eq("UserId", u.UserId);
                var update = Builders<User>.Update.Set(x => x.Email, modification.Email);
                var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
                test = true;
            }

            if (u.UrlPhoto.Equals(modification.UrlPhoto) == false)
            {
                var filter = Builders<User>.Filter.Eq("UserId", u.UserId);
                var update = Builders<User>.Update.Set(x => x.UrlPhoto, modification.UrlPhoto);
                var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
                test = true;
            }

            if (u.Birth_date.Equals(modification.Birth_date) == false)
            {
                var filter = Builders<User>.Filter.Eq("UserId", u.UserId);
                var update = Builders<User>.Update.Set(x => x.Birth_date, modification.Birth_date);
                var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
                test = true;
            }

            if (u.City.Equals(modification.City) == false)
            {
                var filter = Builders<User>.Filter.Eq("UserId", u.UserId);
                var update = Builders<User>.Update.Set(x => x.City, modification.City);
                var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
                test = true;
            }

            if (u.Country.Equals(modification.Country) == false)
            {
                var filter = Builders<User>.Filter.Eq("UserId", u.UserId);
                var update = Builders<User>.Update.Set(x => x.Country, modification.Country);
                var result2 = db._db.GetCollection<User>("user").UpdateOne(filter, update);
                test = true;
            }


            return test;
        }

          
    }


        

}
