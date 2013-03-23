﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BIID.Entities;
using Content = System.Web.UI.WebControls.Content;

namespace BIID.Areas.AgriInfo.Models
{
    public class CustomModelForSearch
    {

        public Sector sector { get; set; }
        public Category category { get; set; }
        public Item item { get; set; }
        public Content content { get; set; }
    }
} 