using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using projet.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projet.Controllers
{
    [Route("api/Connexion")]
    public class ConnexionController : Controller
    {


        DataAccess db;

        public ConnexionController()
        {
            db = new DataAccess();
        }


        // GET: api/values
        [HttpGet]
        public List<User> Get()
        {
            Console.WriteLine("a");
            return db.GetAllUsers();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Boolean Get(String id)
        {
            return db.IsIdUsed(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            // if (db.IsIdValide(id) == false){
            // return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Id déjà prit");
            // }
            // var u = user.Id.ToString();
            //Console.WriteLine(u);
          
           

            return Json(user);


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
