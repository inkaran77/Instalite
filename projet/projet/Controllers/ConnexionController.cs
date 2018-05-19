using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using projet.Profile;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projet.Controllers
{
    
    [AllowAnonymous]
    [Route("Instalite/Connexion")]
    //[Route("token")]
    public class ConnexionController : Controller
    {
        DataAccess db;
       
        public ConnexionController()
        {
            db = new DataAccess();
            //_configuration= new IConfiguration();

        }


        // GET: Instalite/Connexion?UserId=&Password=
        [HttpGet("")]
        public IActionResult Get(String Userid, String Password)
        {
            if (db.IsIdUsed(Userid) == false)
            {
                //String a = "Id";
                return new NotFoundObjectResult("L'utilisateur n'existe pas");
            }

            if (db.IsIdUsed(Userid) == true)
            {
                if (db.ValidePassword(Userid, Password) == false)
                {
                    return new BadRequestObjectResult("Mot de passe erroné");
                }
            }

            // Création du token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.NameId, Userid)
            };
           
            const string sec = "401abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sec));
           
            var token = new JwtSecurityToken
            (
                issuer: "instalite.fr",
                audience: "instalite.fr",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(40),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
          
        }


    }

   
    /*
    // SANS TOKEN 


    [AllowAnonymous]
    [Route("Instalite/Connexion")]
    public class ConnexionController : Controller
    {


        DataAccess db;

        public ConnexionController()
        {
            db = new DataAccess();
        }


        // GET: Instalite/Connexion/Connexion?UserId=&Password=
        [HttpGet("")]
        public IActionResult Get(String Userid,String Password)
        {
            if (db.IsIdUsed(Userid) == false) 
            {
                //String a = "Id";
                return new NotFoundObjectResult("L'utilisateur n'existe pas");
            }

            if (db.IsIdUsed(Userid) == true)
            {
                if(db.ValidePassword(Userid,Password)==false)
                {
                    return new BadRequestObjectResult("Mot de passe erroné");
                }
            }

            // rajouter token
            return new OkObjectResult("Vous êtes connecté");

        }

        
    }
    */
    
}
