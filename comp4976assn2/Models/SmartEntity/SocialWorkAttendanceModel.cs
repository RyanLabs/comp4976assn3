using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models.SmartEntity
{
    public class SocialWorkAttendanceModel
    {
        [Key]
        public int SocialWorkAttendanceId { get; set; }
        public String SocialWorkAttendance { get; set; }

        public List<SmartModel> Smart { get; set; }
    }
}