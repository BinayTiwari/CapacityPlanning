namespace Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CPContext : DbContext
    {
        public CPContext()
            : base("name=CPContext")
        {
        }

        public virtual DbSet<CPT_AccountMaster> CPT_AccountMaster { get; set; }
        public virtual DbSet<CPT_AllocateResource> CPT_AllocateResource { get; set; }
        public virtual DbSet<CPT_CityMaster> CPT_CityMaster { get; set; }
        public virtual DbSet<CPT_CountryMaster> CPT_CountryMaster { get; set; }
        public virtual DbSet<CPT_DesignationMaster> CPT_DesignationMaster { get; set; }
		public virtual DbSet<CPT_EmailTemplate> CPT_EmailTemplate { get; set; }
        public virtual DbSet<CPT_GradeMaster> CPT_GradeMaster { get; set; }
        public virtual DbSet<CPT_MenuMaster> CPT_MenuMaster { get; set; }
        public virtual DbSet<CPT_NewJoiners> CPT_NewJoiners { get; set; }
        public virtual DbSet<CPT_OpportunityMaster> CPT_OpportunityMaster { get; set; }
        public virtual DbSet<CPT_PriorityMaster> CPT_PriorityMaster { get; set; }
        public virtual DbSet<CPT_RegionMaster> CPT_RegionMaster { get; set; }
        public virtual DbSet<CPT_ResourceDemand> CPT_ResourceDemand { get; set; }
        public virtual DbSet<CPT_ResourceDetails> CPT_ResourceDetails { get; set; }
        public virtual DbSet<CPT_ResourceMaster> CPT_ResourceMaster { get; set; }
        public virtual DbSet<CPT_RoleMaster> CPT_RoleMaster { get; set; }
        public virtual DbSet<CPT_SalesStageMaster> CPT_SalesStageMaster { get; set; }
        public virtual DbSet<CPT_SkillsMaster> CPT_SkillsMaster { get; set; }
        public virtual DbSet<CPT_StatusMaster> CPT_StatusMaster { get; set; }
        public virtual DbSet<RoleMenuMapping> RoleMenuMappings { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CPT_AccountMaster>()
                .HasMany(e => e.CPT_AllocateResource)
                .WithRequired(e => e.CPT_AccountMaster)
                .HasForeignKey(e => e.AccountID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CPT_AccountMaster>()
                .HasMany(e => e.CPT_NewJoiners)
                .WithRequired(e => e.CPT_AccountMaster)
                .HasForeignKey(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CPT_AccountMaster>()
                .HasMany(e => e.CPT_ResourceDemand)
                .WithRequired(e => e.CPT_AccountMaster)
                .HasForeignKey(e => e.AccountID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CPT_CountryMaster>()
                .HasMany(e => e.CPT_CityMaster)
                .WithRequired(e => e.CPT_CountryMaster)
                .HasForeignKey(e => e.CountryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CPT_CountryMaster>()
                .HasMany(e => e.CPT_CityMaster1)
                .WithRequired(e => e.CPT_CountryMaster1)
                .HasForeignKey(e => e.CountryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CPT_DesignationMaster>()
                .HasMany(e => e.CPT_NewJoiners)
                .WithOptional(e => e.CPT_DesignationMaster)
                .HasForeignKey(e => e.DesignationID);

            modelBuilder.Entity<CPT_DesignationMaster>()
                .HasMany(e => e.CPT_ResourceMaster)
                .WithRequired(e => e.CPT_DesignationMaster)
                .HasForeignKey(e => e.DesignationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CPT_MenuMaster>()
                .Property(e => e.MenuName)
                .IsUnicode(false);

            modelBuilder.Entity<CPT_MenuMaster>()
                .Property(e => e.MenuURL)
                .IsUnicode(false);

            modelBuilder.Entity<CPT_OpportunityMaster>()
                .HasMany(e => e.CPT_ResourceDemand)
                .WithRequired(e => e.CPT_OpportunityMaster)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CPT_RegionMaster>()
                .HasMany(e => e.CPT_CityMaster)
                .WithRequired(e => e.CPT_RegionMaster)
                .HasForeignKey(e => e.RegionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CPT_RegionMaster>()
                .HasMany(e => e.CPT_CountryMaster)
                .WithRequired(e => e.CPT_RegionMaster)
                .HasForeignKey(e => e.RegionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CPT_ResourceDemand>()
                .HasMany(e => e.CPT_AllocateResource)
                .WithRequired(e => e.CPT_ResourceDemand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CPT_ResourceDemand>()
                .HasMany(e => e.CPT_ResourceDetails)
                .WithRequired(e => e.CPT_ResourceDemand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CPT_ResourceMaster>()
                .HasMany(e => e.CPT_AllocateResource)
                .WithRequired(e => e.CPT_ResourceMaster)
                .HasForeignKey(e => e.ResourceID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CPT_ResourceMaster>()
                .HasMany(e => e.CPT_ResourceDemand)
                .WithOptional(e => e.CPT_ResourceMaster)
                .HasForeignKey(e => e.ResourceRequestBy);

            modelBuilder.Entity<CPT_RoleMaster>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<CPT_RoleMaster>()
                .HasMany(e => e.CPT_ResourceMaster)
                .WithRequired(e => e.CPT_RoleMaster)
                .HasForeignKey(e => e.RolesID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CPT_SalesStageMaster>()
                .HasMany(e => e.CPT_ResourceDemand)
                .WithRequired(e => e.CPT_SalesStageMaster)
                .HasForeignKey(e => e.SalesStageID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CPT_SkillsMaster>()
                .HasMany(e => e.CPT_NewJoiners)
                .WithOptional(e => e.CPT_SkillsMaster)
                .HasForeignKey(e => e.Skills);
        }
    }
}
