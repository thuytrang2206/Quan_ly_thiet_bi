namespace Quan_ly_thiet_bi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Checkmaintenance")]
    public partial class Checkmaintenance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Checkmaintenance()
        {
            Maintenances = new HashSet<Maintenance>();
        }

        [Key]
        [StringLength(50)]
        public string Id__Checkmaintenace { get; set; }

        [StringLength(50)]
        public string Classifymaintenance { get; set; }

        [StringLength(200)]
        public string Checkmaintenace { get; set; }

        [StringLength(50)]
        public string FrequencyCheck { get; set; }

        [StringLength(200)]
        public string Type_Device { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Maintenance> Maintenances { get; set; }
    }
}
