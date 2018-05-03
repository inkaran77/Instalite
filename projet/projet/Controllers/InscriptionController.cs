using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using projet.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projet.Controllers
{
    [Route("Instalite/Inscription")]
   // [EnableCors("AllowSpecificOrigin")]
    [DisableCors]
    public class InscriptionController : Controller
    {

        DataAccess db;

        public InscriptionController()
        {
            db = new DataAccess();
        }


        // POST Instalite/Inscription
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            
            if (db.IsIdUsed(user.UserId) == false)
            {
                db.Inscription(user);
                return new OkObjectResult("Félicitation, vous êtes bien inscrit");
            }
            else return new BadRequestObjectResult("ID déja utilisé");
        }



    }
}
