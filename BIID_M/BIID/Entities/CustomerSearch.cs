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
    
    public partial class CustomerSearch
    {
        public int Id { get; set; }
        public int CustmerId { get; set; }
        public int SearchSubjectId { get; set; }
    
        public virtual CustmerProfile CustmerProfile { get; set; }
    }
}