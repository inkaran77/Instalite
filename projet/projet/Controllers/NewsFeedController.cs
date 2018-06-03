using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projet.Wall;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projet.Controllers
{
    [Authorize]
    public class NewsFeedController : Controller
    {
        [HttpGet("")]
        [Route("Instalite/GetMyNewsFeed")]
        public IActionResult GetMyNewsFeed()
        {
            // On récupere l'id de l'user du token
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            NewsFeed n = new NewsFeed();

            if (n.GetMyNewsFeed(userId) == null)
            {
                return new BadRequestObjectResult("Erreur");
            }
            else return new OkObjectResult(n.GetMyNewsFeed(userId));

        }

    }
}
