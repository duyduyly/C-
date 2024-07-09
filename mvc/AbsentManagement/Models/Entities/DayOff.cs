namespace AbsentManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DayOff")]
    public partial class DayOff
    {
        public long id { get; set; }

        public int approve_status { get; set; }

        public DateTime date_from { get; set; }

        public DateTime date_to { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string reason { get; set; }

        public long approve_person { get; set; }

        public DateTime? created_at { get; set; }

        public long? created_by { get; set; }

        public DateTime? updated_at { get; set; }

        public long? updated_by { get; set; }

        public long person_id { get; set; }

        public virtual Person Person { get; set; }
    }
}
