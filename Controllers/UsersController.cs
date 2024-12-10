using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using My_Friendly_CRM.Datas;
using My_Friendly_CRM.Formulaires;
using My_Friendly_CRM.Interfaces;
using My_Friendly_CRM.Models;
using My_Friendly_CRM.ViewModels;

namespace My_Friendly_CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        // Déclaration des services utilisés par ce contrôleur
        private IUsersServices _service { get; set; }

        private IWebHostEnvironment _hostingEnvironment { get; set; }
        public UsersController(IUsersServices service, IWebHostEnvironment hostingEnvironment)
        {
            _service = service;
            _hostingEnvironment = hostingEnvironment;
        }

        // Action pour s'inscrire
        [HttpPost("signup")]
        public async Task<ActionResult<Guid>> Signup(SignUpViewModel model)
        {
            // Appelle le service pour s'inscrire
            var result = await _service.Signup(model);
            if (result.Success)
            {
              /*  // Définit le chemin vers le fichier de confirmation de compte
                var path = Path.Combine(_hostingEnvironment.ContentRootPath, "Files/", "confirmationDeCompte.html");

                // Lit le contenu du fichier de confirmation de compte
                string content = await System.IO.File.ReadAllTextAsync(path);
                string url = Environment.GetEnvironmentVariable("EMAIL_CLIENT_HOST") ?? string.Empty;
                url += result.Data.ToString();
                content = content.Replace("{0}", url);

                // Envoie l'email de confirmation de compte*/
             //   await EmailService.SendEmailAsync(model.Email, "Gatito Studio - Confirmation d'inscription", content);
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        // Action pour se connecter
        [HttpPost("login")]
        public async Task<ActionResult<LoginResult>> Login(LoginViewModel model)
        {
            LoginResult Response;

            // Appelle le service pour se connecter avec un mot de passe

            string fullName = model.Firstname + " " + model.Lastname;

            var result = await _service.PasswordSignInAsync(fullName, model.Password);

            if (result.Item1.Succeeded)
            {
               /* // Crée les revendications pour le token JWT
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Role, result.UserResult.UserRole),
                    new Claim(ClaimTypes.NameIdentifier, result.UserResult.Id.ToString())
                };

                // Crée la clé de sécurité pour le token JWT
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ANP6f96BON39NkfUbYDF833H9f76Jg"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: "Gatito_API",
                    audience: "Gatito_Audience",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(3600), // Durée de validité du token
                    signingCredentials: creds
                );*/

                // Crée la réponse avec l'utilisateur et le token JWT
                Response = new LoginResult()
                {
                    User = new User()
                    {
                        UserId = result.UserResult.UserId,
                        Role = result.UserResult.Role,
                        Firstname = result.UserResult.Firstname,
                        Lastname = result.UserResult.Lastname,
                    },
                   // Token = new JwtSecurityTokenHandler().WriteToken(token),
                };

                // Retourne la réponse avec un code 200
                return Ok(Response);
            }
            else
            {
                // Retourne une réponse vide avec un code 404 si la connexion échoue
                Response = new LoginResult();
                return NotFound(Response);
            }
        }

    }
}
