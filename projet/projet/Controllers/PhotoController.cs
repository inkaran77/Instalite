using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using projet.Profile;
using projet.Wall;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projet.Controllers
{
    [Route("Instalite/Photo")]
    public class PhotoController : Controller
    {

        DataAccess db;

        public PhotoController()
        {
            db = new DataAccess();
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // Post avec binary, renvoie l'id de la photo dans le bd
        [HttpPost]
        public String AddPhoto()
        {
            using (var ms = new MemoryStream(2048))
            {
                Request.Body.CopyToAsync(ms);
                ms.ToArray();// returns base64 encoded string JSON result

                var a=db.AddPhoto(ms.ToArray());
                return a;

            }

        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
