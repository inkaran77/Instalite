using System;   
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace projet.Wall
{
    public class Photo
    {
       
        public ObjectId _id { get; set; }

        [BsonElement("UrlPhoto")]
        public String UrlPhoto { get; set; }
    }


}
