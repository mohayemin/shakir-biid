﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using BIID.Entities;

namespace BIID.Areas.DirectoryInfo.Models
{

    public class SectorOrgAndOrgAddresses
    {

        public string category;
        
          public string orgName;
        
  
        public List<OrganizationSectorRelation> sectroOrgRelations { get; set; }


        public List<SupplierAddress> SupplierAddresses { get; set; }
    }
} 