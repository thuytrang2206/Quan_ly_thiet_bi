namespace Quan_ly_thiet_bi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GROUP_DEVICE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GROUP_DEVICE()
        {
            DEVICEs = new HashSet<DEVICE>();
        }

        [Key]
        [StringLength(50)]
        public string ID_GROUP { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

        [StringLength(50)]
        public string DESCIPTION { get; set; }

        public bool? STATUS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEVICE> DEVICEs { get; set; }
    }
}
