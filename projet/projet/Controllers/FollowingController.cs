using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projet.Profile;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projet.Controllers
{
    [Authorize]
    public class FollowingController : Controller
    {
        [HttpPut("")]
        [Route("Instalite/Follow")]
        public IActionResult Follow(String UserId)
        {
            // On récupere l'id de l'user du token
            string myUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Following f = new Following();
            if (f.Follow(myUserId,UserId) == true)
            {
                return new OkObjectResult("Demande d'abonnement a bien était envoyé");
            }

            else return new BadRequestObjectResult("Erreur");
        }
    }
}
