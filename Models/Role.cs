using My_Friendly_CRM.Enums;

namespace My_Friendly_CRM.Models
{
    public class Role
    {
        public int RoleId { get; init; }

        public Role_Enum Read { get; set; } = Role_Enum.OWNED; // Valeur par défaut

        public Role_Enum Create { get; set; } = Role_Enum.OWNED; // Valeur par défaut

        public Role_Enum Update { get; set; } = Role_Enum.OWNED; // Valeur par défaut

        public Role_Enum Delete { get; set; } = Role_Enum.OWNED; // Valeur par défaut

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public int CreatedBy { get; set; }

        public virtual User CreatedByUser { get; set; }

        public int ModifiedBy { get; set; }

        public virtual User ModifiedByUser { get; set; }

/*        public int OrganisationId { get; set; }

        public virtual Organisation Organisation { get; set; }*/
    }
}