namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_SkillsMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CPT_SkillsMaster()
        {
            CPT_NewJoiners = new HashSet<CPT_NewJoiners>();
        }

        [Key]
        public int SkillsMasterID { get; set; }

        [Required]
        [StringLength(50)]
        public string SkillsName { get; set; }

        public bool IsActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CPT_NewJoiners> CPT_NewJoiners { get; set; }
    }
}
