//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_cafe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            this.BillInfoes = new HashSet<BillInfo>();
        }
    
        public int Bill_id { get; set; }
        public System.DateTime DateChekIn { get; set; }
        public Nullable<System.DateTime> DateChekOut { get; set; }
        public int inTable { get; set; }
        public int idAccount { get; set; }
        public int status { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual TableFood TableFood { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillInfo> BillInfoes { get; set; }
    }
}
