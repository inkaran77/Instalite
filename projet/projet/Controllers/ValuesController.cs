using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projet.Models;

namespace projet.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        DataAccess db;

        public ValuesController()
        {
            db = new DataAccess();
        }


        // GET: api/values
        [HttpGet]
        public String Get()
        {
           
            return db.GetAllUsers2();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Boolean Get(String id)
        {
            
            return db.IsIdValide(id);
        }



        // POST api/values
        [HttpPost]
        public void Post(int id,[FromBody]string value)
        {
           
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
