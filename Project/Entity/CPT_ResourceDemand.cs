namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_ResourceDemand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CPT_ResourceDemand()
        {
            CPT_ResourceDetails = new HashSet<CPT_ResourceDetails>();
        }

        [Key]
        [StringLength(50)]
        public string RequestID { get; set; }

        public int AccountID { get; set; }

        public int CityID { get; set; }

        public int OpportunityID { get; set; }

        public int SalesStageID { get; set; }

        [Required]
        [StringLength(200)]
        public string ProcessName { get; set; }

        public DateTime? DateOfCreation { get; set; }

        public DateTime? DateOfModification { get; set; }

        public int? ResourceRequestBy { get; set; }

        public int? StatusMasterID { get; set; }

        public int? PriorityID { get; set; }

        public virtual CPT_AccountMaster CPT_AccountMaster { get; set; }

        public virtual CPT_CityMaster CPT_CityMaster { get; set; }

        public virtual CPT_OpportunityMaster CPT_OpportunityMaster { get; set; }

        public virtual CPT_PriorityMaster CPT_PriorityMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_ResourceDetails> CPT_ResourceDetails { get; set; }

        public virtual CPT_ResourceMaster CPT_ResourceMaster { get; set; }

        public virtual CPT_SalesStageMaster CPT_SalesStageMaster { get; set; }

        public virtual CPT_StatusMaster CPT_StatusMaster { get; set; }
    }
}
