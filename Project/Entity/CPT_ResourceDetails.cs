namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_ResourceDetails
    {
        [Key]
        public int RequestDetailID { get; set; }

        [Required]
        [StringLength(50)]
        public string RequestID { get; set; }

        public int ResourceTypeID { get; set; }

        public int NoOfResources { get; set; }

        [Required]
        [StringLength(50)]
        public string SkillID { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public virtual CPT_ResourceDemand CPT_ResourceDemand { get; set; }
    }
}
