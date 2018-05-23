﻿using System;
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
    public class UserController : Controller
    {
        

        [HttpGet("")]
        [Route("Instalite/GetMyProfile")]
        public IActionResult GetMyProfile()
        {
            // On récupere l'id de l'user du token
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User u = new User();
            return new OkObjectResult(u.GetMyProfile(userId));

        }

        [HttpGet("")]
        [Route("Instalite/GetMyPhotos")]
        public IActionResult GetMyPhotos()
        {
            // On récupere l'id de l'user du token
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User u = new User();
            u.UserId = userId;
            return new OkObjectResult(u.GetMyPhotos(userId));

        }

        [HttpGet("")]
        [Route("Instalite/GetWaitingList")]
        public IActionResult GetWaitingList()
        {
            // On récupere l'id de l'user du token
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User u = new User();
            u.UserId = userId;
            if (u.GetWaitingList(userId) == null)
            {
                return new BadRequestObjectResult("Pas de demande d'abonnement");
            }

            else return new OkObjectResult(u.GetWaitingList(userId));

        }


        [HttpPut("")]
        [Route("Instalite/ModifyMyProfile")]
        public IActionResult ModifyMyProfile([FromBody]User user)
        {
            // On récupere l'id de l'user du token
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
           
            // On recupére les informations contenu dans les champs
            User u = new User()
                {
                    First_name = user.First_name,
                    Last_name = user.Last_name,
                    Email = user.Email,
                    UrlPhoto = user.UrlPhoto,
                    Birth_date = user.Birth_date,
                    City = user.City,
                    Country = user.Country,
                    
                };

            if (u.ModifyMyProfile(u, userId) == true)
            {
                return new OkObjectResult("Votre profil est bien mise à jour");
            }
            else return new BadRequestObjectResult("Aucune modification effectuée");

        }


    }
}