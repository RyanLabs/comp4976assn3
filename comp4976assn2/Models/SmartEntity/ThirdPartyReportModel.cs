﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class ThirdPartyReportModel
    {
        [Key]
        public int ThirdPartyReportId { get; set; }
        public String ThirdPartyReport { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}