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
    
    public partial class Planting
    {
        public int Id { get; set; }
        public string SoliType { get; set; }
        public string PlantingTime { get; set; }
        public string PlantingSystems { get; set; }
        public string PlantingSpace { get; set; }
        public string Seeding { get; set; }
        public string Remarks { get; set; }
        public int ItemId { get; set; }
    
        public virtual Item Item { get; set; }
    }
}
