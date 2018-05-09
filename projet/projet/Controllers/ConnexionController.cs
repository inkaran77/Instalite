using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using projet.Profile;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projet.Controllers
{

    [Route("Instalite/Connexion")]
   //[EnableCors("AllowSpecificOrigin")]
    [DisableCors]
    public class ConnexionController : Controller
    {


        DataAccess db;

        public ConnexionController()
        {
            db = new DataAccess();
        }


        // GET: Instalite/Connexion/Connexion?UserId=&Password=
        [HttpGet("")]
       // [DisableCors]
        public IActionResult Get(String Userid,String Password)
        {
            if (db.IsIdUsed(Userid) == false) 
            {
                //String a = "Id";
                return new NotFoundObjectResult("L'utilisateur n'existe pas");
            }

            if (db.IsIdUsed(Userid) == true)
            {
                if(db.ValidePassword(Userid,Password)==false)
                {
                    return new BadRequestObjectResult("Mot de passe erroné");
                }
            }

            // rajouter token
            return new OkObjectResult("Vous êtes connecté");

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
