using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using My_Friendly_CRM.Datas;
using My_Friendly_CRM.Interfaces;
using My_Friendly_CRM.Model;
using My_Friendly_CRM.Models;
using My_Friendly_CRM.ViewModels;

namespace My_Friendly_CRM.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly ApplicationDbcontext _context;
        public UsersServices(ApplicationDbcontext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> FindUser(string? id)
        {
            return await _context.Users.FindAsync(Guid.Parse(id));
        }

        public async Task<(SignInResult, User? UserResult)> PasswordSignInAsync(string userName, string password)
        {
            var user = await _context.Users
                .Where(x => string.Equals(x.Fullname.ToLower(), userName.ToLower()) && x.EmailConfirm).FirstOrDefaultAsync();

            if (user is null)
            {
                return (SignInResult.Failed, null);
            }

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            PasswordVerificationResult passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (passwordVerificationResult.Equals(SignInResult.Success))
            {
                return (SignInResult.Success, user);
            }

            return (SignInResult.Failed, null);
        }

        public async Task<Model.Response<Guid>> Signup(SignUpViewModel model)
        {
            Model.Response<Guid> response = new Model.Response<Guid>();

            var result = await _context.Users
                .Where(x => x.Email.ToUpper().Equals(model.Email.ToUpper()))
                .FirstOrDefaultAsync();

            if (result is null)
            {
                var user = new User
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Email = model.Email,
                    EmailConfirm = true // TODO : Mettre en place la confirmation par mail
                   // Role = new Role,
                   // TokenConfirm = Guid.NewGuid()
                };

                // Hash le mot de passe de l'utilisateur
                PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
                user.PasswordHash = passwordHasher.HashPassword(user, model.Password);
                // Ajoute le nouvel utilisateur au contexte de la base de données
                _context.Users.Add(user);
                // Enregistre les modifications dans la base de données de manière asynchrone
                await _context.SaveChangesAsync();
                // Met à jour l'objet de réponse avec le token de confirmation de l'utilisateur
              //  response.Data = user.TokenConfirm;
                response.Success = true;

            }
            else
            {
                // Si le pseudo existe déjà, met à jour l'objet de réponse avec un message d'erreur
                response.Message = "Ce mail existe déjà";
                response.ReturnCode = 1;
            }

            return response;
        }
    }
}
