﻿namespace BIID.Areas.Admin.Models
{
    public class UserLogModelForReport
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Activity { get; set; }
        public string UserName { get; set; }
        public System.DateTime DateTime { get; set; }
    }
} 