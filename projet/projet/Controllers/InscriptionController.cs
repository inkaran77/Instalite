using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using projet.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projet.Controllers
{
    [Route("Instalite/Inscription")]
    public class InscriptionController : Controller
    {

        DataAccess db;

        public InscriptionController()
        {
            db = new DataAccess();
        }


        // POST Instalite/Inscription
        [HttpPost]
        public void /*HttpResponseMessage*/ Post([FromBody]User user)
        {
            if (db.IsIdUsed(user.UserId) == false)
            {
                db.Inscription(user);
                Console.Write("Inscription Ok");
            }
            else Console.Write("Id déjà utilisé");    //return Request.CreateResponse(HttpStatusCode.NotFound, "No Data found");
        }



    }
}
