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
    
    public partial class SeedProduction
    {
        public int Id { get; set; }
        public string ProcedureOfSeed { get; set; }
        public string Condition { get; set; }
        public string SeedStorage { get; set; }
        public string Remarks { get; set; }
        public int ItemId { get; set; }
    
        public virtual Item Item { get; set; }
    }
}