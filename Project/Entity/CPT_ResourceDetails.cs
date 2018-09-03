namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_ResourceDetails
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CPT_ResourceDetails()
        {
            CPT_AllocateResource = new HashSet<CPT_AllocateResource>();
        }

        [Key]
        public int RequestDetailID { get; set; }

        [Required]
        [StringLength(50)]
        public string RequestID { get; set; }

        public int ResourceTypeID { get; set; }

        public float NoOfResources { get; set; }

        [Required]
        [StringLength(50)]
        public string SkillID { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_AllocateResource> CPT_AllocateResource { get; set; }

        public virtual CPT_ResourceDemand CPT_ResourceDemand { get; set; }
    }
}
