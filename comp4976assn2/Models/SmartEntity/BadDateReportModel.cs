﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class BadDateReportModel
    {
        [Key]
        public int BadDateReportId { get; set; }
        public String BadDateReport { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}