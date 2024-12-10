using My_Friendly_CRM.Model;
using My_Friendly_CRM.Models;

namespace My_Friendly_CRM.Formulaires
{
    // Définition de la classe LoginResult
    // Cette classe est utilisée pour représenter le résultat d'une tentative de connexion
    public class LoginResult
    {
        // Propriété pour l'utilisateur ayant réussi à se connecter
        // Utilise la classe UserLight pour une représentation allégée de l'utilisateur
        public User User { get; set; }
        // Propriété pour le token JWT généré après une connexion réussie
        // Le token est une chaîne de caractères utilisée pour l'authentification
        public string Token { get; set; } = null!;
    }
}