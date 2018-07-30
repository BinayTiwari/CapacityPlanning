namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_GradeMaster
    {
        [Key]
        public int GradeID { get; set; }

        [Required]
        [StringLength(10)]
        public string Grade { get; set; }

        public bool IsActive { get; set; }
    }
}
