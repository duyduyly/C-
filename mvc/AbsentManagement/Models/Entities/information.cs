namespace AbsentManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class information
    {
        [StringLength(50)]
        public string first_name { get; set; }

        [StringLength(50)]
        public string last_name { get; set; }

        public DateTime? birthday { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        [Column(TypeName = "text")]
        public string avartar_url { get; set; }

        public DateTime? created_at { get; set; }

        public long? created_by { get; set; }

        public DateTime? updated_at { get; set; }

        public long? updated_by { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long person_id { get; set; }

        public virtual Person Person { get; set; }
    }
}
