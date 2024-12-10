namespace My_Friendly_CRM.Models
{
    public class User
    {
        public int UserId { get; init; }

        public string Firstname { get; set; } //Required

        public string Lastname { get; set; } //Required

        public string Email { get; set; } //Required

        public string Fullname => $"{Firstname} {Lastname}";
    
        public string PasswordHash { get; set; }

        public bool EmailConfirm { get; set; } = false;

        public DateTime? LastConnexion { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedOn { get; set; }

        // Foreign keys
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }

      /*  public int OrganisationId { get; set; }
        public virtual Organisation Organisation { get; set; }

        public int? AccountId { get; set; }
        public virtual Account Account { get; set; }

        public int? LeadId { get; set; }
        public virtual Lead Lead { get; set; }

        public int? ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public int? OpportunityId { get; set; }
        public virtual Opportunity Opportunity { get; set; }*/
    }
}
