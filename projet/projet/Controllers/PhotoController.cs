using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using projet.Profile;
using projet.Wall;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projet.Controllers
{
    [Authorize]
    [Route("Instalite/Photo")]
    public class PhotoController : Controller
    {

        DataAccess db;

        public PhotoController()
        {
            db = new DataAccess();
        }


        // 
        [HttpGet("")]
        public String GetPhoto(String id)
        {

            return db.GetPhoto(id);
        }

        // Post avec lien, renvoie l'id de la photo dans le bd
        [HttpPost("")]
        public String AddPhoto(String UrlPhoto)
        {

            var a = db.AddPhoto(UrlPhoto);
            return a;

            // En binary ancienne version
            /*
            using (var ms = new MemoryStream(2048))
            {
                Request.Body.CopyToAsync(ms);
                ms.ToArray();// returns base64 encoded string JSON result

                var a=db.AddPhoto(ms.ToArray());

                // A effacer : Recuperer L'id de l'utlisateur directement du token
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                Console.WriteLine(userId);
                //

                return a;

            }
            */
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
