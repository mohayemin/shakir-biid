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
    
    public partial class LivestockFeedPreservation
    {
        public int Id { get; set; }
        public string Ingradient { get; set; }
        public string Amount { get; set; }
        public string Process { get; set; }
        public string Duration { get; set; }
        public string FeedUse { get; set; }
        public string Precaution { get; set; }
        public string Remarks { get; set; }
        public int ItemId { get; set; }
    
        public virtual Item Item { get; set; }
    }
}
