//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyBanHang
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblHangHoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblHangHoa()
        {
            this.tblHoaDons = new HashSet<tblHoaDon>();
        }
    
        public int IDHangHoa { get; set; }
        public string TenHang { get; set; }
        public Nullable<int> SoLuongCon { get; set; }
        public Nullable<int> DonGia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblHoaDon> tblHoaDons { get; set; }
    }
}
