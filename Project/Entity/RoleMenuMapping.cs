namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleMenuMapping")]
    public partial class RoleMenuMapping
    {
        [Key]
        [Column("RoleMenuMapping")]
        public int RoleMenuMapping1 { get; set; }

        public int? MenuID { get; set; }

        public int? RoleID { get; set; }

        public virtual CPT_MenuMaster CPT_MenuMaster { get; set; }
    }
}
