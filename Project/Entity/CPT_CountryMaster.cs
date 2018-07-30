namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_CountryMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CPT_CountryMaster()
        {
            CPT_CityMaster = new HashSet<CPT_CityMaster>();
            CPT_CityMaster1 = new HashSet<CPT_CityMaster>();
        }

        [Key]
        public int CountryMasterID { get; set; }

        public int RegionID { get; set; }

        [Required]
        [StringLength(50)]
        public string CountryName { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_CityMaster> CPT_CityMaster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_CityMaster> CPT_CityMaster1 { get; set; }

        public virtual CPT_RegionMaster CPT_RegionMaster { get; set; }
    }
}
