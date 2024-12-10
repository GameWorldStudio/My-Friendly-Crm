using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using My_Friendly_CRM.Enums;
using My_Friendly_CRM.Models;

namespace My_Friendly_CRM.Datas
{
    public class ApplicationDbcontext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
      /*  public DbSet<Organisation> Organisations { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }*/

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration pour la table User
            modelBuilder.Entity<User>(ConfigureUser);

            modelBuilder.Entity<Role>(ConfigureRole);
        }

        private void ConfigureUser(EntityTypeBuilder<User> entity)
        {
     
                // Nom de la table
                entity.ToTable("Users");

                // Clé primaire
                entity.HasKey(e => e.UserId);

                // Colonnes
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

   /*             entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .IsRequired();*/

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsRequired();

            entity.Property(e => e.EmailConfirm);

            entity.Property(e => e.LastConnexion);
              

                entity.Property(e => e.CreatedOn)
                    .IsRequired();

            entity.Property(e => e.ModifiedOn);

                // Relations avec les clés étrangères
                entity.HasOne(e => e.Role)
                    .WithMany()
                    .HasForeignKey(e => e.RoleId)
                    .OnDelete(DeleteBehavior.SetNull);

              /*  entity.HasOne(e => e.Organisation)
                    .WithMany()
                    .HasForeignKey(e => e.OrganisationId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Account)
                    .WithMany()
                    .HasForeignKey(e => e.AccountId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.Lead)
                    .WithMany()
                    .HasForeignKey(e => e.LeadId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.Contact)
                    .WithMany()
                    .HasForeignKey(e => e.ContactId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(e => e.Opportunity)
                    .WithMany()
                    .HasForeignKey(e => e.OpportunityId)
                    .OnDelete(DeleteBehavior.SetNull);*/
            
        }

        private void ConfigureRole(EntityTypeBuilder<Role> entity)
        {
            // Nom de la table
            entity.ToTable("Roles");

            // Clé primaire
            entity.HasKey(e => e.RoleId);

            // Colonnes
            entity.Property(e => e.RoleId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Read)
                .IsRequired()
                .HasDefaultValue(Role_Enum.OWNED);

            entity.Property(e => e.Create)
                .IsRequired()
                .HasDefaultValue(Role_Enum.OWNED);

            entity.Property(e => e.Update)
                .IsRequired()
                .HasDefaultValue(Role_Enum.OWNED);

            entity.Property(e => e.Delete)
                .IsRequired()
                .HasDefaultValue(Role_Enum.OWNED);

            entity.Property(e => e.CreatedOn)
                .IsRequired();

            entity.Property(e => e.ModifiedOn)
                .IsRequired();

            // Relations
            entity.HasOne(e => e.CreatedByUser)
                .WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.ModifiedByUser)
                .WithMany()
                .HasForeignKey(e => e.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            /*entity.HasOne(e => e.Organisation)
                .WithMany()
                .HasForeignKey(e => e.OrganisationId)
                .OnDelete(DeleteBehavior.Restrict);*/
        }
    }
}
