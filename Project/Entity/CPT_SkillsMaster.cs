namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_SkillsMaster
    {
        [Key]
        public int SkillsMasterID { get; set; }

        [Required]
        [StringLength(50)]
        public string SkillsName { get; set; }

        public bool IsActive { get; set; }
    }
}
