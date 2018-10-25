namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_Certificate
    {
        [Key]
        public int CertificateID { get; set; }

        public int? EmployeeID { get; set; }

        public int? SkillID { get; set; }

        public int? Rating { get; set; }

        [StringLength(200)]
        public string CertificatePath { get; set; }

        public virtual CPT_ResourceMaster CPT_ResourceMaster { get; set; }

        public virtual CPT_SkillsMaster CPT_SkillsMaster { get; set; }
    }
}
