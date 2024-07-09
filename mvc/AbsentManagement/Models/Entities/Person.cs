namespace AbsentManagement.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person")]
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            DayOffs = new HashSet<DayOff>();
        }

        public long id { get; set; }

        [StringLength(100)]
        public string subject_name { get; set; }

        public int person_type { get; set; }

        public DateTime? created_at { get; set; }

        public long? created_by { get; set; }

        public DateTime? updated_at { get; set; }

        public long? updated_by { get; set; }

        public long account_id { get; set; }

        public virtual Account Account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DayOff> DayOffs { get; set; }

        public virtual information information { get; set; }
    }
}
