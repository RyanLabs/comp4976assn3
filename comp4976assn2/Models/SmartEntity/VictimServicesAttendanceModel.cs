using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class VictimServicesAttendanceModel
    {
        [Key]
        public int VictimServicesAttendanceId { get; set; }
        public String VictimServicesAttendance { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}