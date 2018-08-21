namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CPT_EmailTemplate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string BccEmailAddresses { get; set; }

        [StringLength(100)]
        public string Subject { get; set; }

        public string Body { get; set; }

        public bool? IsActive { get; set; }

        public int? EmailAccountId { get; set; }

        public int? LimitedToStores { get; set; }
        public List<string> To { get; set; }
        public List<string> CC { get; set; }
        public List<string> Bcc { get; set; }
        public List<string> ToUserName { get; set; }
        public string UID { get; set; }
    }
}