namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_RoleMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CPT_RoleMaster()
        {
            CPT_ResourceMaster = new HashSet<CPT_ResourceMaster>();
        }

        [Key]
        public int RoleMasterID { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_ResourceMaster> CPT_ResourceMaster { get; set; }
    }
}
