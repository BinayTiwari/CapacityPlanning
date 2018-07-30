namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_SalesStageMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CPT_SalesStageMaster()
        {
            CPT_ResourceDemand = new HashSet<CPT_ResourceDemand>();
        }

        [Key]
        public int SalesStageMasterID { get; set; }

        [Required]
        [StringLength(50)]
        public string SalesStageName { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_ResourceDemand> CPT_ResourceDemand { get; set; }
    }
}
