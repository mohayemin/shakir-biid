﻿using BIID.Entities;

namespace BIID.Models
{
    public class DbBaseClass:BIIDFinalEntities
    {
        BIIDFinalEntities _db = new BIIDFinalEntities();
    }
} 