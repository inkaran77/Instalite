using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projet.Profile;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projet.Controllers
{
    [Authorize]
    public class FollowerController : Controller
    {
        [HttpPut("")]
        [Route("Instalite/AcceptFollower")]
        public IActionResult AcceptFollower(String UserId)
        {
            // On récupere l'id de l'user du token
            string myUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Follower f = new Follower();
            if (f.AcceptFollower(myUserId,UserId) == true)
            {
                return new OkObjectResult("Vous avez accepté " + UserId);
            }

            else return new BadRequestObjectResult("Erreur");
        }    
    
    
        [HttpDelete("")]
        [Route("Instalite/RefuseFollowRequest")]
        public IActionResult RefuseFollowRequest(String UserId)
        {
            // On récupere l'id de l'user du token
            string myUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Follower f = new Follower();
            if (f.RefuseFollowRequest(myUserId,UserId) == true)
            {
                return new OkObjectResult("Demande d'abonnement "+ UserId+" refusée");
            }

            else return new BadRequestObjectResult("Erreur");
        }    
    
        [HttpDelete("")]
        [Route("Instalite/RefuseFollowRequest")]
        public IActionResult DeleteFollower(String UserId)
        {
            // On récupere l'id de l'user du token
            string myUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Follower f = new Follower();
            if (f.DeleteFollower(myUserId,UserId) == true)
            {
                return new OkObjectResult("Abonné "+ UserId+" supprimé");
            }

            else return new BadRequestObjectResult("Erreur");
        } 

        [HttpGet("")]
        [Route("Instalite/GetAllMyFollowers")]
        public IActionResult GetAllMyFollowers()
        {
            // On récupere l'id de l'user du token
            String myUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User u = new User();

            if (u.Followers.GetAllMyFollowers(myUserId) == null)
            {
                return new BadRequestObjectResult("Pas d'abonnées");
            }

            else return new OkObjectResult(u.Followers.GetAllMyFollowers(myUserId));

        }

    
    }
}
