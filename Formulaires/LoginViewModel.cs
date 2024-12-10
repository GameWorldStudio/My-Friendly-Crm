using System.ComponentModel.DataAnnotations;

namespace My_Friendly_CRM.Formulaires
{
    // Définition de la classe LoginViewModel
    // Cette classe est utilisée pour capturer les données d'un formulaire de connexion
    public class LoginViewModel
    {
        // Propriété pour le nom d'utilisateur
        // Le champ est requis et doit être de type texte
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [DataType(DataType.Text)]
        public string Firstname { get; set; }

        // Propriété pour le nom d'utilisateur
        // Le champ est requis et doit être de type texte
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [DataType(DataType.Text)]
        public string Lastname { get; set; }

        // Propriété pour le nom d'utilisateur
        // Le champ est requis et doit être de type texte
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Propriété pour le mot de passe
        // Le champ est requis et doit être de type mot de passe
        [Required(ErrorMessage = "Le champ {0} est requis.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
