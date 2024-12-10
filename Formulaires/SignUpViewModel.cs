namespace My_Friendly_CRM.ViewModels
{
    // Définition de la classe SignUpViewModel
    // Cette classe est utilisée pour représenter les données nécessaires à l'inscription d'un nouvel utilisateur
    public class SignUpViewModel
    {

        public string Firstname { get; set; } = string.Empty;

        public string Lastname { get; set; } = string.Empty;

        // Propriété pour l'adresse email de l'utilisateur
        // Valeur par défaut définie à une chaîne vide
        public string Email { get; set; } = string.Empty;
        // Propriété pour le mot de passe de l'utilisateur
        // Valeur par défaut définie à une chaîne vide
        public string Password { get; set; } = string.Empty;


    }
}
