namespace Quan_ly_thiet_bi.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DEVICE")]
    public partial class DEVICE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEVICE()
        {
            HISTORies = new HashSet<HISTORY>();
        }

        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string FullCode { get; set; }

        [StringLength(50)]
        public string ScortCode { get; set; }

        public bool? IsUsing { get; set; }

        [StringLength(50)]
        public string DeviceGroup { get; set; }

        [StringLength(50)]
        public string DeviceName { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string Serial { get; set; }

        [StringLength(50)]
        public string VendorName { get; set; }

        [StringLength(50)]
        public string Purpose { get; set; }

        [StringLength(50)]
        public string Creator { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? DateMaintenance { get; set; }

        [StringLength(50)]
        public string Updater { get; set; }

        public DateTime? Updatetime { get; set; }

        public int? Qty { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        [StringLength(500)]
        public string Image1 { get; set; }

        [StringLength(500)]
        public string Image2 { get; set; }

        public virtual GROUP_DEVICE GROUP_DEVICE { get; set; }

        public virtual USER USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORY> HISTORies { get; set; }
    }
}
