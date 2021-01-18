namespace Quan_ly_thiet_bi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Maintenance")]
    public partial class Maintenance
    {
        [Key]
        [StringLength(50)]
        public string Id_Maintenance { get; set; }

        [StringLength(50)]
        public string Id_device { get; set; }

        [StringLength(50)]
        public string Checkmaintenance { get; set; }

        [StringLength(50)]
        public string FrequencyCheck { get; set; }

        [StringLength(50)]
        public string Personmaintenance { get; set; }

        public virtual Checkmaintenance Checkmaintenance1 { get; set; }

        public virtual DEVICE DEVICE { get; set; }
    }
}
