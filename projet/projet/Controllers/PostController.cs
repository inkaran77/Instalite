using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projet.Profile;
using projet.Wall;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projet.Controllers
{
    [Authorize]
    public class PostController : Controller
    {   
        DataAccess db;

        public PostController()
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

        // POST api/values
        [HttpPost]
        [Route("Instalite/PostPhoto2")]
        public IActionResult Post([FromBody]Post p)
        {
                Post post = new Post()
                {
                    Date = p.Date,
                    Description = p.Description,
                    Title = p.Title,
                    Author = p.Author,
                    UrlPhoto = p.UrlPhoto,
                };

                User u = new User();
                Boolean b=u.PostPhoto(post);
                if (b==true)
                {
                    return new OkObjectResult("Votre poste a était ajouté");
                }
           
                else return new BadRequestObjectResult("Erreur");
            
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
