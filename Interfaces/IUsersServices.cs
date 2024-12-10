//using GatitoStudioAPI.Formulaires;
using My_Friendly_CRM.Models;
using Microsoft.AspNetCore.Identity;
using My_Friendly_CRM.Model;
using My_Friendly_CRM.ViewModels;

namespace My_Friendly_CRM.Interfaces
{
    // Définition de l'interface IUsersServices
    // Cette interface définit les opérations disponibles pour la gestion des utilisateurs
    public interface IUsersServices
    {
        // Méthode pour confirmer l'inscription d'un utilisateur avec un token de confirmation
      //  Task<Response<bool>> Confirm(Guid token);

        // Méthode pour trouver un utilisateur par son identifiant
        Task<User> FindUser(string? id);

        // Méthode pour signer l'utilisateur avec un nom d'utilisateur et un mot de passe
        // Retourne un tuple contenant le résultat de la tentative de connexion et l'utilisateur trouvé
        Task<(SignInResult, User? UserResult)> PasswordSignInAsync(string userName, string password);

        // Méthode pour inscrire un nouvel utilisateur
        Task<Response<Guid>> Signup(SignUpViewModel model);
    }
}
