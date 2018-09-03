namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_AllocateResource
    {
        [Key]
        public int AllocationID { get; set; }

        public int ResourceID { get; set; }

        public int? RoleMasterID { get; set; }

        [Required]
        [StringLength(50)]
        public string RequestID { get; set; }

        public int AccountID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public float? Utilization { get; set; }

        public bool? Released { get; set; }

        public int? RequestDetailID { get; set; }

        public virtual CPT_AccountMaster CPT_AccountMaster { get; set; }

        public virtual CPT_ResourceDemand CPT_ResourceDemand { get; set; }

        public virtual CPT_ResourceMaster CPT_ResourceMaster { get; set; }

        public virtual CPT_ResourceDetails CPT_ResourceDetails { get; set; }

        public virtual CPT_RoleMaster CPT_RoleMaster { get; set; }
    }
}
