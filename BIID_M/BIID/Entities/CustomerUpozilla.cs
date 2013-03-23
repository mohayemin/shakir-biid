//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIID.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerUpozilla
    {
        public CustomerUpozilla()
        {
            this.SupplierAddresses = new HashSet<SupplierAddress>();
            this.SupplierUpozillas = new HashSet<SupplierUpozilla>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> DistrictId { get; set; }
    
        public virtual CustomerDistrict CustomerDistrict { get; set; }
        public virtual ICollection<SupplierAddress> SupplierAddresses { get; set; }
        public virtual ICollection<SupplierUpozilla> SupplierUpozillas { get; set; }
    }
}
