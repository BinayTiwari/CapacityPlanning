namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_NewJoiners
    {
        [Key]
        public int NewJoinerID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? DesignationID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? JoiningDate { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        public int? Skills { get; set; }

        public int Account { get; set; }

        [Required]
        [StringLength(50)]
        public string InterviewedBy { get; set; }

        [Required]
        [StringLength(50)]
        public string Experience { get; set; }

        public virtual CPT_AccountMaster CPT_AccountMaster { get; set; }

        public virtual CPT_DesignationMaster CPT_DesignationMaster { get; set; }

        public virtual CPT_SkillsMaster CPT_SkillsMaster { get; set; }
    }
}
