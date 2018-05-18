using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using projet.Profile;

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


       [HttpPost]
        public IActionResult Post([FromBody]User user)
        {

            if (db.IsIdUsed(user.UserId) == false)
            {
                User u= new User
               {
                   UserId = user.UserId,
                   Password = user.Password,
                   First_name = user.First_name,
                   Last_name = user.Last_name,
                   Gender = user.Gender,
                   Email = user.Email,
                   UrlPhoto = user.UrlPhoto,
                   Birth_date = user.Birth_date,
                   City = user.City,
                   Country = user.Country,
               }; 
                db.Insert(u, "user");
                //db.Inscription(user);
                return new OkObjectResult("Félicitation, vous êtes bien inscrit");
            }
            else return new BadRequestObjectResult("ID déja utilisé");
        }





    }

 }

