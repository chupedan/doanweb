//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLGO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NHAPKHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHAPKHO()
        {
            this.CTNHAPKHOes = new HashSet<CTNHAPKHO>();
        }
    
        public string IDPhieuNhap { get; set; }
        public System.DateTime NgayNhapKho { get; set; }
        public string IDNCC { get; set; }
        public string IDND { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTNHAPKHO> CTNHAPKHOes { get; set; }
        public virtual NGUOIDUNG NGUOIDUNG { get; set; }
        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}