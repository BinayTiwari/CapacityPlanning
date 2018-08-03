namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_ResourceMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CPT_ResourceMaster()
        {
            CPT_AllocateResource = new HashSet<CPT_AllocateResource>();
            CPT_ResourceDemand = new HashSet<CPT_ResourceDemand>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeMasterID { get; set; }

        [StringLength(50)]
        public string Photo { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeetName { get; set; }

        public int ReportingManagerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string EmployeePassword { get; set; }

        [Required]
        [StringLength(50)]
        public string BaseLocation { get; set; }

        [Required]
        [StringLength(50)]
        public string Mobile { get; set; }

        public int DesignationID { get; set; }

        public int RolesID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? JoiningDate { get; set; }

        public float? PriorWorkExperience { get; set; }

        [StringLength(10)]
        public string PAN { get; set; }

        [StringLength(50)]
        public string Skillsid { get; set; }

        public string Address { get; set; }

        [StringLength(50)]
        public string PassportNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PassportExpiryDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? VisaExpiryDate { get; set; }

        public DateTime? DateOfCreation { get; set; }

        public DateTime? DateOfModification { get; set; }

        public int? CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? LastLogin { get; set; }

        public float? isMapped { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_AllocateResource> CPT_AllocateResource { get; set; }

        public virtual CPT_DesignationMaster CPT_DesignationMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_ResourceDemand> CPT_ResourceDemand { get; set; }

        public virtual CPT_RoleMaster CPT_RoleMaster { get; set; }
    }
}
