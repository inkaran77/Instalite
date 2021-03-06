﻿using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using projet.Profile;

namespace projet.Wall
{
    public class Post
    {
        [BsonId]
        public String _id { get;private set; }

        [BsonElement("Date")]
        public String Date { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Like_counter")]
        public int Like_counter { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }

        [BsonElement("UrlPhoto")]
        public String UrlPhoto { get; set; }

        [BsonElement("Like_like")]
        public List<Like> List_like { get; set; }

        [BsonElement("List_comment")]
        public List<Comment> List_comment { get; set; }

        public Post()
        {
            _id = ObjectId.GenerateNewId().ToString();

        }


        public Boolean Like(String urlPhoto, Like l)
        {

            DataAccess db = new DataAccess();

            try
            {
                // On recupère le post dans sa collection
                var filter = Builders<Post>.Filter.Eq("UrlPhoto", urlPhoto);
                var result = db._db.GetCollection<Post>("post").Find(filter).FirstOrDefault();
                Post p = JsonConvert.DeserializeObject<Post>(result.ToJson());

                // On test si la photo n'a pas déjà était liké
                if(AlreadyLiked(urlPhoto,l)==true)
                {
                    return false;
                }

                // On ajoute le like à la liste de like + on incrémente le compteur
                p.Like_counter++;

                // On fait la mise à jour du like counter au niveau du post
                var update = Builders<Post>.Update.Set(x => x.Like_counter, p.Like_counter);
                var result2 = db._db.GetCollection<Post>("post").UpdateOne(filter, update);

                // On fait la mise à jour du liste like  au niveau du post
                //var update2 = Builders<Post>.Update.Set(x => x.List_like, p.List_like);
                var update2 = Builders<Post>.Update.AddToSet(x => x.List_like, l);
                var result3 = db._db.GetCollection<Post>("post").UpdateOne(filter, update2);
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

        }

        public Boolean AlreadyLiked(String urlPhoto, Like l)
        {
            DataAccess db = new DataAccess();

            // on cherche pour ce post si l'utilisateur à déja like
            var test= db._db.GetCollection<Post>("post").AsQueryable()
                     .Where(x => x.UrlPhoto == urlPhoto)
                     .SelectMany(x => x.List_like)
                     .Where(x => x.Like_Author == l.Like_Author)
                     .Any();
            
        
            if (test==false)
            {
                return false;
            }

            else return true;
        }

        public Boolean Comment(String urlPhoto, Comment c)
        {
            DataAccess db = new DataAccess();

            try
            {
                // On recupère le post dans sa collection
                var filter = Builders<Post>.Filter.Eq("UrlPhoto", urlPhoto);
                var result = db._db.GetCollection<Post>("post").Find(filter).FirstOrDefault();
                Post p = JsonConvert.DeserializeObject<Post>(result.ToJson());

                // On ajoute le commentaire à la liste de commentaire

                p.List_comment.Add(c);

                // On fait la mise à jour de la liste de commentaires  au niveau du post
                var update = Builders<Post>.Update.Set(x => x.List_comment, p.List_comment);
                var result2 = db._db.GetCollection<Post>("post").UpdateOne(filter, update);
                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public String GetAllComments(String urlPhoto)
        {
            DataAccess db = new DataAccess();
            var filter = Builders<Post>.Filter.Eq("UrlPhoto", urlPhoto);
            var result = db._db.GetCollection<Post>("post").Find(filter).FirstOrDefault();
            Post p = JsonConvert.DeserializeObject<Post>(result.ToJson());


            //// On crée un json pr renvoyer dans le format voulu
            JObject comments = JObject.Parse(@"{'Comments': []}");
            JArray j = (JArray)comments["Comments"];

            if (p.List_comment.Capacity==0) return null;
            foreach (Comment c in p.List_comment)
            {
                JObject j1 = new JObject(new JProperty("Author", c.Author));
                JProperty jp1 = new JProperty("Message", c.Message);
                j1.Add(jp1);
                j.Add(j1);

            }

            return comments.ToString();

        }
    }

}
