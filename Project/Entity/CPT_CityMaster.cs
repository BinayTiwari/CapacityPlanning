namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_CityMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CPT_CityMaster()
        {
            CPT_AccountMaster = new HashSet<CPT_AccountMaster>();
            CPT_ResourceDemand = new HashSet<CPT_ResourceDemand>();
        }

        [Key]
        public int CityID { get; set; }

        public int RegionID { get; set; }

        public int CountryID { get; set; }

        [Required]
        [StringLength(50)]
        public string CityName { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_AccountMaster> CPT_AccountMaster { get; set; }

        public virtual CPT_CountryMaster CPT_CountryMaster { get; set; }

        public virtual CPT_CountryMaster CPT_CountryMaster1 { get; set; }

        public virtual CPT_RegionMaster CPT_RegionMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_ResourceDemand> CPT_ResourceDemand { get; set; }
    }
}
