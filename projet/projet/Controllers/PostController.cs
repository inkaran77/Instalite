using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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


        [HttpGet("")]
        [Route("Instalite/GetPost")]
        public IActionResult Get(String UrlPhoto)
        {
            User u = new User();
            return new OkObjectResult(u.GetPost(UrlPhoto));
        }

        [HttpPost]
        [Route("Instalite/PostPhoto")]
        public IActionResult Post([FromBody]Post p)
        {
                //Post post = new Post()
                //{
                //    Date = p.Date,
                //    Description = p.Description,
                //    Title = p.Title,
                //    Author = p.Author,
                //    UrlPhoto = p.UrlPhoto,
                //    List_like = new List<Like>(),
                //    List_comment = new List<Comment>(),
                //    Like_counter = 0,
                //};
                
                // On récupere l'id de l'user du token
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                User u = new User();
                Boolean b=u.PostPhoto(p,userId);
                if (b==true)
                {
                    return new OkObjectResult("Votre poste a était ajouté");
                }
           
                else return new BadRequestObjectResult("Erreur");
            
        }

       
        [HttpPut("")]
        [Route("Instalite/Like")]
        public IActionResult Like(String UrlPhoto)
        {
            // On récupere l'id de l'user du token
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Post p = new Post();
            Like l = new Like();
            l.Author = userId;
            if(p.Like(UrlPhoto,l)==true)
            {
                return new OkObjectResult("Post liké");
            } 

            else return new BadRequestObjectResult("Erreur");
        }

        [HttpPut("")]
        [Route("Instalite/Comment")]
        public IActionResult Comment(String UrlPhoto,String Message)
        {
            // On récupere l'id de l'user du token
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Post post = new Post();
            Comment c = new Comment();
            c.Author = userId;
            c.Date = DateTime.Now.ToString();
            c.Message = Message;

            if (post.Comment(UrlPhoto, c) == true)
            {
                return new OkObjectResult("Post commenté");
            }

            else return new BadRequestObjectResult("Erreur");
        }

        [HttpPut("")]
        [Route("Instalite/GetAllComments")]
        public IActionResult GetAllComments(String UrlPhoto)
        {
             
            Post post = new Post();
            if (post.GetAllComments(UrlPhoto) == null)
            {
                return new BadRequestObjectResult("Pas de commentaire");
            }

            else return new OkObjectResult(post.GetAllComments(UrlPhoto));
            
        }


        // DELETE api/values/5
        [HttpDelete("")]
        [Route("Instalite/DeletePost")]
        public IActionResult DeletePost(String UrlPhoto)
        {
            // On récupere l'id de l'user du token
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User u = new User();

            if (u.DeletePost(UrlPhoto, userId) == true)
            {
                return new OkObjectResult("Votre poste a était supprimé");
            }
            else return new BadRequestObjectResult("Erreur");

        }
    }
}
