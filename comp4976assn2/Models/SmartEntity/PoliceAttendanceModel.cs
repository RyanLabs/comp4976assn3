﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class PoliceAttendanceModel
    {
        [Key]
        public int PoliceAttendanceId { get; set; }
        public String PoliceAttendance { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}