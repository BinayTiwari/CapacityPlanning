namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_RegionMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CPT_RegionMaster()
        {
            CPT_CityMaster = new HashSet<CPT_CityMaster>();
            CPT_CountryMaster = new HashSet<CPT_CountryMaster>();
        }

        [Key]
        public int RegionMasterID { get; set; }

        [Required]
        [StringLength(50)]
        public string RegionName { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_CityMaster> CPT_CityMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_CountryMaster> CPT_CountryMaster { get; set; }
    }
}
